using System;
using DatingSite.API.Models;

namespace DatingSite.API.Dto
{
    public class UserForListDto: DataEntityModelBase
    {
        public string UserName { get; set; }        
        public string Gender { get; set; }
        public int Age { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }        
        public string City { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; }
    }
}