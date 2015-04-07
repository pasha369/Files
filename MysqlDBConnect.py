import MySQLdb

def Singleton(class_):
    """docstring for Singleton"""
    instance = {}
    def Wraper():
        if class_ not in instance:
            instance[class_] = class_()
        return instance[class_]
    return Wraper

@Singleton
class MySqlDBConnect(object):
    """docstring for MySqlDBConnect"""
    def __init__(self):
        self.CurTable = None
        self.db = None

    def ConnectToDB(self, User, Pass, CurDB):
        try:
            self.db = MySQLdb.connect(host = 'localhost',
                                  user = User,
                                  passwd = Pass,
                                  db = CurDB)

        except Exception:
            db.close()

    def ExecuteQuery(self, query):
        cursor = self.db.cursor()
        cursor.execute(query)
        return cursor

    def DescribeTable(self, TableName):
        cursor = self.ExecuteQuery('describe %s'%TableName)
        tbNameFields = list()
        for field in cursor.fetchall():
            tbNameFields.append(field[0])
        return tbNameFields

    def CheckTable(self):
        self.ExecuteQuery('show tables')
        return raw_input('Chose table: ')

    def SelectTable(self, TableName):
        cursor = self.ExecuteQuery('select * from %s;' % TableName)
        self.Show(cursor)

    def InsertTable(self, TableName, Id, Surname, Age, Salary):
        query = '''Insert into %s
            (id, surname, age, salary)
            values (%s, '%s', %s, %s); ''' % (TableName, Id, Surname, Age, Salary)
        print query
        self.ExecuteQuery(query)

    def UpdateTable(self, TableName, Id, Surname, Age, Salary):
        try:
            self.ExecuteQuery('''Update %s
                set surname = '%s', age = %s, salary = %s
                where id = %s;'''
                              % (TableName, Surname, Age, Salary, Id))
            self.db.commit()
        except Exception:
            self.db.rollback()

    def DeleteTable(self, TableName, Id):
        try:
            self.ExecuteQuery(
                '''delete from %s where id=%s;'''
                % (TableName, Id))

            self.db.commit()
        except Exception:
            self.db.rollback()

    def Show(self, cursor):
        for row in cursor.fetchall():
            print row

if __name__ == "__main__":
    connectdb = MySqlDBConnect()
    connectdb.ConnectToDB('root', '123456', 'Test')
    connectdb.DescribeTable('Employess')
