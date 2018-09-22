using System.ComponentModel.DataAnnotations;

namespace klaravictor.Models
{
    public class RvspModel
    {
        [Key]
        public int RvspId { get; set; }
        [Required(ErrorMessage = "Skriv ditt namn")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ange e-post")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Kommer du?")]
        public bool Attending { get; set; }
        [Required(ErrorMessage = "Ange typ av boende")]
        public string Accommondation { get; set; }
        [Required(ErrorMessage = "Ange antal nätter")]
        public string NumberOfNights { get; set; }
        public string FoodInfo { get; set; }
        public string Comment { get; set; }
    }
}