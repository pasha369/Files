from app_service import app, db
from app_service.models.models import User, Role


class UserCreator(object):

    """Controller for adding new user into db"""

    def __init__(self):
        '''Init new connection to db'''
        self.db = db

    def add_user(self, f_name, l_name, role, login, email):
        '''Add new user'''
        self.user = User(
            first_name=f_name,
            last_name=l_name,
            role=role,
            login=login,
            email=email
        )

    def save(self):
        '''Save into users'''
        self.db.session.add(self.user)
        self.db.session.commit()

    def load(self):
        '''Load from users'''
        self.users = (db.session.query(User)
                        .join(Role)
                        .values(User.first_name,
                                User.last_name,
                                Role.role_name,
                                User.login,
                                User.email))
        return self.users

    def __del__():
        '''Close connection'''
        self.db.session.close()
