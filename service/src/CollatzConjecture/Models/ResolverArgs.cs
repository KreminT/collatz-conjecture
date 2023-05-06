using CollatzConjecture.Math.Model;
using System.ComponentModel.DataAnnotations;

namespace CollatzConjecture.Models
{
    public class ResolverArgs : IResolverArgs
    {
        [Required]
        public string Value { get; set; }
        [Required]
        public int Multiplier { get; set; }
        public int MaxIteration { get; set; }

        public bool IsSubtraction { get; set; }
        public int StartInterval { get; set; }
        public int EndInterval { get; set; }
    }
}
