namespace Social.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserProfile
    {
        [Key]
        public string UserId { get; set; }

        public string Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool? Gender { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public double? ZipCode { get; set; }

        public double? ContactNo { get; set; }

        [Required]
        [StringLength(255)]
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(255)]
        public string UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
