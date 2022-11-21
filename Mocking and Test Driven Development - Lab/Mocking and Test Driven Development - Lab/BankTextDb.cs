namespace Mocking_and_Test_Driven_Development___Lab
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class BankTextDb : IBankIRepository
    {
        private readonly string path = "../../../db.txt";

        public List<User> ReadUsers()
        {
            if (!File.Exists(path))
            {
                return new List<User>();
            }
            string json;
            using (StreamReader reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
            return users;
        }

        public void Update(Bank bank)
        {
            string jsonUsers = JsonConvert.SerializeObject(bank.Users);
            using(StreamWriter writer = new StreamWriter(path, false))
            {
                writer.Write(jsonUsers);
            }
        }
    }
}
