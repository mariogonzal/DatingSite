using System.Collections.Generic;
using DatingSite.API.Models;
using Newtonsoft.Json;

namespace DatingSite.API.Data
{
    public static class Seed
    {
        public static void SeedData(DataContext context)
        {
            var jsonData=System.IO.File.ReadAllText("Data/UserSeedData.Json");
            var Users=JsonConvert.DeserializeObject<List<User>>(jsonData);
            foreach(var user in Users)            
            {
                var password="password";
                byte [] passwordHash, passwordSalt;
                CreatePassword( password, out  passwordHash, out  passwordSalt);
                user.PasswordHash=passwordHash;
                user.PasswordSalt=passwordSalt;
                user.UserName=user.UserName.ToLower();
                context.Users.Add(user);
            }
            context.SaveChanges();            
        }

         private static void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac= new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt=hmac.Key;
                passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }
    }
}