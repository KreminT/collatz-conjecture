using CollatzConjecture.Math.Model;
using System.ComponentModel.DataAnnotations;
using CollatzConjecture.Math.IO.Args;

namespace CollatzConjecture.Models
{
    public class ResolverArgs : IResolverArgs, IFileResultProcessingArgs
    {
        [Required]
        public string Value { get; set; }
        [Required]
        public int Multiplier { get; set; }
        public int MaxIteration { get; set; }

        public bool IsSubtraction { get; set; }
        public int? StartInterval { get; set; }
        public int? EndInterval { get; set; }
        /// <summary>
        /// Add empty line to result file between iteration
        /// </summary>
        public bool AddEmptyLine { get; set; }
    }
}
