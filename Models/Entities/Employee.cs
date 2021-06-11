﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendUsers.Models.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public float Salary { get; set; }

        public string Email { get; set; }




        //public string PhotoName { get; set; }
        //public string CvName { get; set; }

    }
}
