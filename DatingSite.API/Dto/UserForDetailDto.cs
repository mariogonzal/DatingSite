using System;
using System.Collections.Generic;
using DatingSite.API.Models;

namespace DatingSite.API.Dto
{
    public class UserForDetailDto : DataEntityModelBase
    {
        
        public string UserName { get; set; }        
        public string Gender { get; set; }
        public int Age { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interest { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string PhotoUrl { get; set; }
        public ICollection<PhotoForDto> Photos { get; set; }
    }
}