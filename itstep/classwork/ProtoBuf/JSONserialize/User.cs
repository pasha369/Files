using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProtoBuf;

namespace JSONserialize
{
    [ProtoContract]
    class User
    {
        [ProtoMember(1)]
        public string _name;
        [ProtoMember(2)]
        public string _password;
        [ProtoMember(3)]
        public int _age;
        [ProtoMember(4)]
        public string[] _subjects;
        [ProtoMember(5)]
        public string _some;
        public  User()
        {
            
        }
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
