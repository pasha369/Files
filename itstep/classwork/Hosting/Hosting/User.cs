using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Hosting
{
    [ServiceContract]
    public  interface IAutorize
    {
        [OperationContract]
        string SignIn(string login, string pass);

        [OperationContract]
        string SignUp(string login, string pass);

        [OperationContract]
        string GetInfo(string token);
    }


    [DataContract]
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


   
    public class Autorize : IAutorize
    {
        
        public string SignIn(string login, string pass)
        {
            //get all users
            bool isCorrect = false;
            List<User> users = new List<User>();

            using (ServiceAuthEntities3 context = new ServiceAuthEntities3())
            {
                Random rnd = new Random();
                // generate token

                var temp_user = context.UserInfo.FirstOrDefault(t => t.login == login && t.pass == pass);
                temp_user.token = rnd.Next(0, 55555) + "tset" + DateTime.Now.ToString();
                
                // generate salt
                byte[] salt = new byte[8];
                System.Buffer.BlockCopy(temp_user.salt.ToCharArray(), 0, salt, 0, salt.Length);

                //generate hash
                byte[] pass_buffer = Encoding.UTF8.GetBytes(pass);
                SHA256 sha256 = SHA256Managed.Create();
                byte[] hash_value;
                byte[] rv = new byte[pass_buffer.Length + salt.Length];
                System.Buffer.BlockCopy(pass_buffer, 0, rv, 0, pass_buffer.Length);
                System.Buffer.BlockCopy(salt, 0, rv, pass_buffer.Length, salt.Length);

                hash_value = sha256.ComputeHash(rv);

                // hash and salt convert to string
                var hash = BitConverter.ToString(hash_value);

                if (hash == temp_user.pass)
                    isCorrect = true;

                foreach (var user in context.UserInfo.ToList())
                {
                    users.Add(new User()
                    {
                        ID = user.id,
                        user_name = user.user_name,
                        login = user.login,
                        pass = user.pass,
                        token = user.token

                    });

                context.Entry(temp_user).State = EntityState.Modified;
                context.SaveChanges();
              

  
                }
                
            }

            User cur_user = users.FirstOrDefault(t => t.login == login && t.pass == pass);
            var json_user = JsonConvert.SerializeObject(cur_user.token);
            if(isCorrect)
            {
                return json_user;
            }
            else
            {
                return "";
            }
        }



        public string GetInfo(string token)
        {
            string info;
            var final_token = JsonConvert.DeserializeObject(token);
            using (ServiceAuthEntities1 context = new ServiceAuthEntities1())
            {

                var obj_info = context.UserInfo.FirstOrDefault(t => t.token == final_token.ToString());
                info = JsonConvert.SerializeObject(obj_info);
            }
            return info;
        }


        public string SignUp(string login, string pass)
        {
            using (ServiceAuthEntities3 context = new ServiceAuthEntities3())
            {
                Random rnd = new Random();
                // generate salt
                byte[] salt = new byte[8];
                rnd.NextBytes(salt);

                //generate hash
                byte[] pass_buffer = Encoding.UTF8.GetBytes(pass);
                SHA256 sha256 = SHA256Managed.Create();
                byte[] hash_value;
                byte[] rv = new byte[pass_buffer.Length + salt.Length];
                System.Buffer.BlockCopy(pass_buffer, 0, rv, 0, pass_buffer.Length);
                System.Buffer.BlockCopy(salt, 0, rv, pass_buffer.Length, salt.Length);

                hash_value = sha256.ComputeHash(rv);

                // hash and salt convert to string
                var hash = BitConverter.ToString(hash_value);
                var salt_str = BitConverter.ToString(salt);

                var temp_user = new UserInfo();
                temp_user.login = login;
                temp_user.user_name = "Test";
                temp_user.pass = hash;
                temp_user.salt = salt_str;

                temp_user.token = rnd.Next(0, 55555) + "tset" + DateTime.Now.ToString();

                context.Entry(temp_user).State = EntityState.Added;

                context.SaveChanges();
            }
        }
    }
}
