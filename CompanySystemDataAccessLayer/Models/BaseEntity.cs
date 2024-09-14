﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySystemDataAccessLayer.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]

        public string Name { get; set; }

        public DateTime DateOfCreation { get; set; } = DateTime.Now;
    }
}
