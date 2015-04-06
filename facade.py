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

