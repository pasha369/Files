from pymongo import MongoClient

def Singleton(class_):
    """docstring for Singleton"""
    instance = {}
    def Wraper():
        if class_ not in instance:
            instance[class_] = class_()
            return instance[class_]
        return Wraper


class MongodbORM(object):
    """ORM for work with pymongo"""
    def __init__(self):
        self.db = None
        self.CurDoc = None

    def Connect(self, name, host='localhost', port=27017):
        """Connect to db"""
        self.db = name
        self.client = MongoClient(host, port)
        return self.client[self.db]

    def GetAllDocument(self, name):
        """Select all document from db"""
        collection = self.Connect(self.db)[name].find()
        return collection

    def GetDocByPattern(self, name, **pattern):
        """Select doc by pattern"""
        collection = self.Connect(self.db)[name].find({pattern})
        return collection

    def RemoveDoc(self, name):
        """Remove document from db"""
        self.Connect(self.db)[name].remove()

    def InsertNewDoc(self, name, **kwargs):
        """Insert new document into db"""
        self.Connect(self.db)[name].save(kwargs)

    def UpdateDoc(self, name, spec, **kwargs):
        """Update document"""
        self.Connect(self.db)[name].update(spec, kwargs)

    def __del__(self):
        self.client.close()


if __name__ == "__main__":
    conn = MongodbORM()
    conn.Connect('test')
    #conn.InsertNewDoc('books',nam='new book', age=18)
    conn.GetAllDocument('users')
    
    print [i for i in conn.GetAllDocument('users')] 
