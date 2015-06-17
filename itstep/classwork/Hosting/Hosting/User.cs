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
            
            List<User> users = new List<User>();
            using (ServiceAuthEntities3 context = new ServiceAuthEntities3())
            {
                Random rnd = new Random();
                // generate token

                
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
                //temp_user.pass = hash;
                //temp_user.salt = salt_str;
                // save changes
                context.Entry(temp_user).State = EntityState.Modified;
                try
                {
                    // Your code...
                    // Could also be before try if you know the exception occurs in SaveChanges

                    context.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }

                var temp_user = context.UserInfo.FirstOrDefault(t => t.login == login && t.pass == pass);
                temp_user.token = rnd.Next(0, 55555) + "tset" + DateTime.Now.ToString();

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
                }
                
            }

            User cur_user = users.FirstOrDefault(t => t.login == login && t.pass == pass);
            var json_user = JsonConvert.SerializeObject(cur_user.token);

            return json_user;
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
    }
}
