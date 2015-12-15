using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SafeEats.Models
{
    public class RecipeType
    {
        public string TypeName { get; set; }
        [Key]
        public int TypeId { get; set; }
        public int TypeType { get; set; }
    }
}