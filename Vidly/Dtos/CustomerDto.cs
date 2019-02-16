using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public bool isSubscribedToNewsletter { get; set; }       
        public byte MembershipTypeId { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}