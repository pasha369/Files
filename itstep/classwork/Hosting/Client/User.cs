using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class User
    {
        [DataMember]
        public int ID;
        [DataMember]
        public string user_name;
        [DataMember]
        public string login;
        [DataMember]
        public string pass;
        [DataMember]
        public string token;
        [DataMember]
        public DateTime expDate;


    }
}
