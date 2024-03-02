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
namespace Projekt.Models
{
   public class Product
   {
      [Key]
      public int Id { get; set; }

      [Required(ErrorMessage = "Fältet \"Titel\" är obligatoriskt.")]
      public string? Title { get; set; }

      [Required(ErrorMessage = "Fältet \"Titel\" är obligatoriskt.")]
      public string? Description { get; set; }
      [Required(ErrorMessage = "Fältet \"Författare\" är obligatoriskt.")]
      public string? Author { get; set; }

      [Required]
      [Display(Name = "Pris")]
      [Range(10, 10000)]
      public double? Price { get; set; }


      [Required]
      [Display(Name = "Pris för 1-50st")]
      [Range(10, 10000)]
      public double? ListPrice { get; set; }


      [Required]
      [Display(Name = "Pris för 50-100st")]
      [Range(10, 10000)]
      public double? Price50 { get; set; }


      [Required]
      [Display(Name = "Pris för 100+")]
      [Range(10, 10000)]
      public double? Price100 { get; set; }

      public int CategoryId { get; set; }

      [ForeignKey("CategoryId")]
      [ValidateNever]
      public Category? Category { get; set; }

      [ValidateNever]
      public List<ProductImage> ProductImages { get; set; }
   }


}


