using System.ComponentModel.DataAnnotations;

namespace CollatzConjecture.Models
{
    public class BodyArgs
    {
        [Required]
        public string Value { get; set; }
        [Required]
        public int Multiplier { get; set; }
        public int MaxIteration { get; set; }
    }
}
