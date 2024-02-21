using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Projekt.Models
{
    public class Category {

        [Key]
        public int Id { get; set;}
        [Required]
           [DisplayName("Namn")]
        public string Name { get; set;}
        [DisplayName("Ordning")]
        public int DisplayOrder { get; set;}


    }
}