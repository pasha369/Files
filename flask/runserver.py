from flask import Flask, render_template, request

from mongo_ORM import MongodbORM

from flask.ext.sqlalchemy import SQLAlchemy
from models import User, Role

conn = MongodbORM()
app = Flask(__name__)
app.config['SQLALCHEMY_DATABASE_URI'] = 'mysql+pymysql://root:123456@localhost/db_users'
db = SQLAlchemy(app)

@app.route("/")
def Page():
    """load base.html"""
    return render_template('index.html')

@app.route("/mongo", methods = ['GET'])
def MongoPage():
    """load mongo.html"""
    conn.Connect('test')
    users = conn.GetAllDocument('users')
    return render_template('mongo.html', users = users)

@app.route("/mongo", methods = ['POST'])
def AddInDB():
    """Add new User into mongo collection users"""
    conn.Connect('test')
    
    conn.InsertNewDoc('users',
                     fname = request.form['usernm'],
                     sname = request.form['usersnm'],
                     role =  request.form.getlist("roles"),
                     login = request.form['login'],
                     email = request.form['email']
                      )
    print request.form['usernm']
    client = app.test_client()
    response = client.get('/mongo', headers=list(request.headers))
    return response

@app.route("/mysql", methods = ['GET'])
def MysqlPage():
    """load mysql.html"""
    users = (db.session.query(User)
        .join(Role)
        .values(User.first_name, 
            User.last_name,
            Role.role_name,
            User.login,
            User.email))
    

    return render_template('mysql.html', users=users)

@app.route("/mysql", methods = ['POST'])
def AddToMysql():
    """Add new User into mysql table users"""
    new_user = User(first_name = request.form['usernm'],
                     last_name = request.form['usersnm'],
                     role =  request.form['role'],
                     login = request.form['login'],
                     email = request.form['email'])
    db.session.add(new_user) 
    db.session.commit() 
    db.session.close()
    client = app.test_client()
    response = client.get('/mysql', headers=list(request.headers))
    return response

if __name__ == "__main__":
   app.debug = True
   app.run()
