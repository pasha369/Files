<<<<<<< HEAD
"""http://dpip.testingperspective.com/?p=26"""

import time

SLEEP = 0.5
"""
def DecFacade(cls):
    tests = []
    def Wraper(*args):
        tests.append(cls(*args))
        def runAll():
            [i.run() for i in tests]

        return runAll()
   return Wraper
"""
tests = []
def DecFacade(cls):
    tests.append(cls())
    print(len(tests))
    class Wraper():
#     tests.append(cls())
        def run(self):
            [i.run() for i in tests]
    return Wraper


@DecFacade
class TC1:
    def run(self):
        print("###### In Test 1 ######")
        time.sleep(SLEEP)
        print("Setting up")
        time.sleep(SLEEP)
        print("Running test")
        time.sleep(SLEEP)
        print("Tearing down")
        time.sleep(SLEEP)
        print("Test Finished\n")

@DecFacade
class TC2:
    def run(self):
        print("###### In Test 2 ######")
        time.sleep(SLEEP)
        print("Setting up")
        time.sleep(SLEEP)
        print("Running test")
        time.sleep(SLEEP)
        print("Tearing down")
        time.sleep(SLEEP)
        print("Test Finished\n")

@DecFacade
class TC3:
    def run(self):
        print("###### In Test 3 ######")
        time.sleep(SLEEP)
        print("Setting up")
        time.sleep(SLEEP)
        print("Running test")
        time.sleep(SLEEP)
        print("Tearing down")
        time.sleep(SLEEP)
        print("Test Finished\n")


# Facade
class TestRunner:
    def __init__(self):
        self.tc1 = TC1()
        self.tc2 = TC2()
        self.tc3 = TC3()
        self.tests = [i for i in (self.tc1, self.tc2, self.tc3)]

    def runAll(self):
        [i.run() for i in self.tests]


# Client
if __name__ == '__main__':
    testrunner = TC1()
    testrunner = TC2()
    testrunner.run()
=======
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
>>>>>>> b99546d430311913741191bc5728ec349b3e0062
