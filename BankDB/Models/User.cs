namespace BankDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Field {0} must be between {2} and {1} characters length.")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "{0} not valid")]        
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Field {0} must be between {2} and {1} characters length.")]
        public string Password { get; set; }

        public DateTime CreatedOn { get; set; }
    }

    public class UserDBContext : DbContext
    {
        public UserDBContext() : base("name=UserDBContext")
        {
        }

        public System.Data.Entity.DbSet<BankDB.Models.User> Users { get; set; }
    }
}