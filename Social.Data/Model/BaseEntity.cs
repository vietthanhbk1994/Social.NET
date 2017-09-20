using System;
using System.ComponentModel.DataAnnotations;

namespace Social.Data.Model
{
    public abstract class BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(255)]
        public string UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
