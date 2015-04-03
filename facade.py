class TC1(object):
    def run(self):
        print("test1")
        print('test 1 complited')

class TC2(object):
    def run(self):
        print("test2")
        print('test 2 complited')

class TC3(object):
    def run(self):
        print("test3")
        print('test 3 complited')

def FasadeDecorator(*method):
    tests = [TC1(), TC2(), TC3()]
    def ClassWraper(cls):
        """Class Fasade decorator"""
        class FClass(cls):
            def Run(self):
                [i.run for i in tests]
        return ClassWraper
    return ClassWraper
@FasadeDecorator
class Facade(object):
    def __init__(self):
        self.t1 = TC1()
        self.t2 = TC2()
        self.t3 = TC3()
        self.tests = [i for i in (self.t1, self.t2, self.t3)]

    def Run(self):
        print("last")

fs = Facade()
