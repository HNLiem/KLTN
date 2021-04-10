﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class Address : BaseEntity
    {
        [Required]
        public int Id { get; set; }
    }
}
