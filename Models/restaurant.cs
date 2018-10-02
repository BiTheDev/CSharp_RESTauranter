using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter.Models
{
    public class restaurant{

        [Key]
        public long Id {get; set;}

        [Required(ErrorMessage = "The Review Name is required")]
        public string ReviewName{get; set;}

        [Required(ErrorMessage = "The Restaurant Name is required")]
        public string RestName{get; set;}

        [Required(ErrorMessage = "Please give some review")]
        [MinLength(10)]
        public string Review{get; set;}

        [Required]
        public int Star{get; set;}

        [Required(ErrorMessage = "When do you visit?")]
        public DateTime VisitDate{get; set;}

        public DateTime created_at{get;set;}

        public DateTime updated_at{get; set;}

        
    }
}