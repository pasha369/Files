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
        self.CurDB = None
        self.CurDoc = None
        print 'Hello'

    def Connect(self, name):
        """Connect to db"""
        self.CurDB = name
        db = MongoClient('mongodb://localhost:27017')
        return db[self.CurDB]

    def GetAllDocument(self, name):
        """Select all document from db"""
        collection = self.Connect(self.CurDB)[name].find()
        return collection

    def GetDocByPattern(self, name, **pattern):
        """Select doc by pattern"""
        collection = self.Connect(self.CurDB)[name].find({pattern})
        return collection

    def RemoveDoc(self, name):
        """Remove document from db"""
        self.Connect(self.CurDB)[name].remove()

    def InsertNewDoc(self, name, **kwargs):
        """Insert new document into db"""
        self.Connect(self.CurDB)[name].save(kwargs)

    def UpdateDoc(self, name, spec, **kwargs):
        """Update document"""
        self.Connect(self.CurDB)[name].update(spec, kwargs)

    def ExistByNone(self, name, property):
        """If property exist => none"""
        collection =  self.GetAllDocument(name)
        for doc in collection:
            print doc
            """self.Connect(self.CurDB)[name].update(
                {},
                {"$set":
                    doc if property in collection else {property:'none1'}
                },
                upsert=True
            )"""


if __name__ == "__main__":
    t = Test()
    conn = mdbORM()
    conn.Connect('test')
    #conn.InsertNewDoc('books',nam='new book', age=18)
    conn.UpdateDoc('books', {'nam':'new book'}, nme='fantasy', age=20)
    conn.ExistByNone('books', 'name')
    print [i for i in conn.Connect('test')['books'].find()]
