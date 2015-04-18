from flask import Flask, render_template, request
from app_service import app, conn
from app_service.controllers.controller import UserCreator
from app_service.forms.form import CreateUserForm

@app.route("/")
def main_page():
    """load base.html"""
    return render_template('index.html')


@app.route("/mysql", methods=['GET'])
def page_to_mysql_get():
    """load mysql.html"""
    user_creator = UserCreator()
    users = user_creator.load()
    return render_template('mysql.html', users=users)


@app.route("/mysql", methods=['POST'])
def page_to_mysql_post():
    """Add new User into mysql table users"""
    form = CreateUserForm(request.form)
    user_creator = UserCreator()
    print '-'*100
    print form.validate()
    print '-'*100
    user_creator.add_user(request.form['usernm'],
                          request.form['usersnm'],
                          request.form['role'],
                          request.form['login'],
                          request.form['email'])
    user_creator.save()
    client = app.test_client()
    response = client.get('/mysql', headers=list(request.headers))
    return response


@app.route("/mongo", methods=['GET'])
def page_to_mongo_get():
    """load mongo.html"""
    conn.Connect('test')
    users = conn.GetAllDocument('users')
    return render_template('mongo.html', users=users)


@app.route("/mongo", methods=['POST'])
def page_to_mongo_post():
    """Add new User into mongo collection users"""
    conn.Connect('test')

    conn.InsertNewDoc('users',
                      fname=request.form['usernm'],
                      sname=request.form['usersnm'],
                      role=request.form.getlist("roles"),
                      login=request.form['login'],
                      email=request.form['email']
                      )
    print request.form['usernm']
    client = app.test_client()
    response = client.get('/mongo', headers=list(request.headers))
    return response
