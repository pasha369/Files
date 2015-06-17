using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLSerializer
{
    class Person
    {
        public string _first_name;
        public string _last_name;
        public int _age;
        public List<string> _role;
        public string _hobby;

        public Person(string first_name, string last_name, int age, List<string> role, string hobby)
        {
            _first_name = first_name;
            _last_name = last_name;
            _age = age;
            _role = role;
            _hobby = hobby;
        }
    }
}
