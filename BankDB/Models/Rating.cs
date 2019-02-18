namespace BankDB.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;

    public class Rating
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Value { get; set; }
        [Required]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }
    }

    public class RatingDBContext : DbContext
    {
        public RatingDBContext() : base("name=RatingDBContext")
        {
        }

        public System.Data.Entity.DbSet<BankDB.Models.User> Users { get; set; }
    }
}