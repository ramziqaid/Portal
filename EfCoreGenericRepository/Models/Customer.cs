using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EfCoreGenericRepository.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string Name { get; set; }
    }
}
