using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Projekt.Models
{
    public class Category {

        [Key]
        public int Id { get; set;}
        
        [Required(ErrorMessage = "Fältet Namn är obligatoriskt.")]
        [MaxLength(30, ErrorMessage = "Namnet får inte vara längre än 30 tecken.")]
        [DisplayName("Namn")]
        public string Name { get; set;}
        
        [DisplayName("Ordning")]
        [Range(1,100, ErrorMessage ="Värdet på ordning måste vara mellan 1-100.")]
        public int DisplayOrder { get; set;}
    


    }
}