using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Identity;

namespace Projekt.Models {
    public class ShoppingCart  {
        public int Id {get; set;}
        public int ProductId {get; set;}
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product {get; set;}
        [Range(1,100, ErrorMessage = "Vänligen välj ett antal mellan 1 och 100.")]
        public int Count {get; set;}
        public string ApplicationUserId {get; set;}
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser {get; set;}


    }
}
