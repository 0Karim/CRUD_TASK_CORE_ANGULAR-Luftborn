using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanArch.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public bool IsDeleted { get; set; }


        [ForeignKey("UserAddress")]
        public int? AddressId { get; set; }

        public AddressInfo UserAddress { get; set; }
    }
}
