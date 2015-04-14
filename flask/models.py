from flask import Flask
from flask.ext.sqlalchemy import SQLAlchemy

app = Flask(__name__)
app.config['SQLALCHEMY_DATABASE_URI'] = 'mysql+pymysql://root:123456@localhost/db_users'
db = SQLAlchemy(app)

class Role(db.Model):
  """Table Role"""
  __tablename__='roles'
  id = db.Column(db.Integer, primary_key=True)
  role_name = db.Column(db.String(120), unique=True)

  def __init__(self, name):
    """Init new role"""
    self.role_name = name


class User(db.Model):
  """Table users"""
  __tablename__ = 'users'
  id = db.Column(db.Integer, primary_key=True)
  first_name = db.Column(db.String(120))
  last_name = db.Column(db.String(120))
  login = db.Column(db.String(120))
  email = db.Column(db.String(120))
  role_id = db.Column(db.Integer, db.ForeignKey(Role.id))

  def __init__(self, first_name, last_name, login, email, role):
    """Init new user"""
    self.first_name = first_name
    self.last_name = last_name
    self.login = login
    self.email = email
    if role == 'teacher': self.role_id = 1
    elif role == 'manager': self.role_id = 2
    else: self.role_id = 3
