using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JSONserialize
{
    class User
    {
        public string _name;
        public string _password;
        public int _age;
        [JsonProperty ("subsub")]
        public string[] _subjects;
        public string _some;

        public User(string name, string password, int age)
        {
            this._name = name;
            this._password = password;
            this._age = age;
            this._subjects = new[]
            {
                "sub1",
                "sub1",
                "sub1",
                "sub1"
            };
            this._some = "test";
        }
    }
}
