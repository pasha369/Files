import re
from wtforms import Form, BooleanField, TextField, PasswordField, validators

class CreateUserForm(Form):
    """docstring for RegistrationFom"""
    
    first = TextField('usernm',
        [validators.Regexp(r'^\w+$', message='error name')])
    last = TextField('usersnm',
        [validators.Regexp(r'^\w+$', message='error name')])
    role = TextField('role',
        [validators.Regexp(r'^\w+$', message='error role')])
    login = TextField('login',
        [validators.Regexp(r'^\w+$',
        message='error login')])
    email = TextField('email',
        [validators.Regexp(r'^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$', 
        message='error email')])

if __name__ == '__main__':
    print validate_role('')
