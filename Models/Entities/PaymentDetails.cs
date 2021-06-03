﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendUsers.Models.Entities
{
    public class PaymentDetails
    {
        [Key]
        public int PaymentId { get; set; }
        public string PaymentName { get; set; }
        public double cost { get; set; }
    }
}
