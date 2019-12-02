namespace DatingSite.API.Models
{
    public class User:DataEntityModelBase
    {        

        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}