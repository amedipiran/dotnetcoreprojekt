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
    public class Company  {
        public int Id {get; set;}
        [Required]
        public string Name {get; set;}
        public string? StreetAddress {get; set;}
        public string? City {get; set;}
        public string? State {get; set;}
        public string? PostalCode {get; set;}
        public string? PhoneNumber {get; set;}



    }
}