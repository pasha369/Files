#!/usr/bin/env python

from MySQLORM import MySQLORM
import re

class UserController(object):

    """Controller for adding new user into db"""

    def __init__(self, table):
        """Init new connection to db"""
        #connect to db
        self.db = MySQLORM()
        self.db.connect('localhost', 'root', '123456', 'Temp')
        self.table = table
        #colums for table
        self.colums = ['name text', 'surname text', 'password text', 'login text', 'email text']
        #create table
        """self.db.mysql_do('drop %s if exists Temp'%table)"""
        self.db.mysql_do('create table %s (%s)'%(table,','.join(self.colums)))  

    def validate(self, f_name, l_name, password, role, login, email):
        """correct = true else false"""
        self.message = ''
        #regex pattern
        email_pattern = """^[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}$"""
        if not f_name:
            self.message += '\nInvalid name address'
        if not l_name:
            self.message += '\nInvalid name address'
        if not role:
            self.message += '\nInvalid role address'
        if not password:
            self.message += '\nInvalid password address'
        if not login:
            self.message += '\nInvalid login address'
        if not re.match(email_pattern, email):
            self.message += '\nInvalid email address'
        #If validate return true
        if self.message: 
            return False
        else: 
            return True

    def get_message(self):
        """return error message else if exist"""
        return self.message;

    def register(self, f_name, l_name, password, role, login, email):
        """Register new user"""
        if self.validate(f_name, l_name, password, role, login, email):
            self.current_user = (f_name, l_name, password, role, login, email)
            return True
        else: 
            return False

    def change_role(self, role, *users):
        """Change role few users"""
        change = 'role = %s'%role
        for user in users:
            condition = 'first_name = __, last_name = __'
            self.db.update('users', change, condition)

    def save(self):
        """Save current_user into users"""
        self.db.insert(self.table,
            ('name', 'surname', 'password', 'login', 'email',),
            ('f_name', 'l_name', 'password', 'login', 'l@ukrnet',))

    def load(self):
        """Load all user from users"""
        self.users = self.db.get()
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
