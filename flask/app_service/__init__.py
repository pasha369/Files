from flask import Flask, render_template, request
from flask.ext.sqlalchemy import SQLAlchemy
from app_service.utils.mongo_ORM import MongodbORM

app = Flask(__name__)
app.config['SQLALCHEMY_DATABASE_URI'] = 'mysql+pymysql://root:123456@localhost/db_users'
db = SQLAlchemy(app)


conn = MongodbORM()