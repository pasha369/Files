#!/usr/bin/env python
from MySQLORM import MySQLORM
from app.models.roles import RolesModel
from app.models.schools import SchoolsModel
from app.models.teachers import TeachersModel
import re

class UserController(object):

    """Controller for add new teacher into db"""

    def __init__(self, table):
        """Init new connection to db"""
        #connect to db
        self.db = MySQLORM()
        self.db.connect('localhost', 'root', '123456', 'Temp')
        self.table = table

    def validate(self, f_name, l_name, password, role, login, email):
        """correct = true else false"""
        self.message = ''
        #regex pattern
        email_pattern = """^[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}$"""
        #check data
        if not f_name:
            self.message += '\nInvalid name'
        if not l_name:
            self.message += '\nInvalid name'
        if not role:
            self.message += '\nInvalid role'
        if not password:
            self.message += '\nInvalid password'
        if not login:
            self.message += '\nInvalid login'
        if not re.match(email_pattern, email):
            self.message += '\nInvalid email address'
        #If validate return true
        if self.message: 
            return False
        else: 
            return True

    def get_message(self):
        """return error message"""
        return self.message;

    def register(self, f_name, l_name, password, role, login, email):
        """Register new user"""
        if self.validate(f_name, l_name, password, role, login, email):
            self.current_user = Teachers(f_name, l_name, password, role, login, email)
            return True
        else: 
            return False

    def change_role(self, role, *users):
        """Change role few users"""
        change = 'role_id = %s'%role
        for user in users:
            condition = 'name = __'
            self.db.update('users', change, condition)

    def save(self):
        """Save current_user into users"""
        self.db.insert(self.table,
            (self.current_user.__dict__.keys(),),
            (self.current_user.__dict__.values(),))

    def load(self):
        """Load all user from users"""
        self.users = self.db.get("""users_test left join roles
            on users_test.role_id = roles.id
            """,
            ('name', 'role_name', 'login', 'email', 'password'))
        return self.users

    def __del__(self):
        """Close connection"""
        self.db.close()


def main():
    us_control = UserController('users_test')
    #validate_on_submite
    print us_control.validate('f_name', 'l_name', 'password', 'role', 'login', 'l@ukrnet')
    print us_control.get_message()
    print us_control.register('f_name', 'l_name', 'password', 'role', 'login', 'email@ukr.net')
    print us_control.get_message()
    #save
    us_control.save()

if __name__ == '__main__':
    main()
