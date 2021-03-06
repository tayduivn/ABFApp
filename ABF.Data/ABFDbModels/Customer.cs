﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABF.Data.ABFDbModels
{
    public class Customer
    {
        public string Id { get; set; }

        [Display(Name="User ID")]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

      
        [Display(Name ="House No/Name")]
        public string Address1 { get; set; }

        
        [Display(Name="Street Name")]
        public string Address2 { get; set; }

        
        [Display(Name="Town/City")]
        public string Address3 { get; set; }

        
        [Display(Name="Post Code")]
        [DataType(DataType.PostalCode)]
        public string PostCode { get; set; }

       
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]        
        public string PhoneNumber { get; set; }

        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }

        [Display(Name="Date Joined As Member")]
        public DateTime? DateJoined { get; set; }

        public virtual MembershipType MembershipType { get; set; }
        public virtual IList<Ticket> Tickets { get; set; }
        public virtual IList<Order> Orders { get; set; }
    }
}
