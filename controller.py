#!/usr/bin/env python

from app.models import AdminModel


class AdminController(object):

    """docstring for AdminController"""

    def __init__(self, **data):
        self.data = data
        self.model = AdminModel()
        self.view = View()

    def validate_on_submite(self, **kwargs):
        """correct = true else false"""
        self.message = ''
        # regex pattern
        email_pattern = """^[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}$"""
        # check data
        if not kwargs.get('fname'):
            self.message += '\nInvalid name'
        if not kwargs.get('lname'):
            self.message += '\nInvalid name'
        if not kwargs.get('role'):
            self.message += '\nInvalid role'
        if not kwargs.get('password'):
            self.message += '\nInvalid password'
        if not kwargs.get('login'):
            self.message += '\nInvalid login'
        if not kwargs.get('school'):
            self.message += '\nInvalid school'
        if not re.match(email_pattern, email):
            self.message += '\nInvalid email address'
        # If validate return true
        if self.message: 
            return False
        else: 
            return True
    
    def get_index():
        return self.view.get_index()

    def get_view_add_get(self):
        """view => add.html get"""
        return self.view.add()
    
    def get_view_add_post(self, **kwargs):
        """view => user_add.html post"""
        self.data = kwargs
        if submit_on_validate(data):
            self.model.set(data)
            return self.view.ok()
        else:
            return self.view.error()

    def get_view_all():
        """view => user_add.html get"""
        self.data = self.model.get_all()
        return self.view.get_all()

