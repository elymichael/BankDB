namespace BankDB.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;

    public class Branch
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }

        public DateTime CreatedOn { get; set; }
        [Required]
        public int UserId { get; set; }
    }

    public class BranchDBContext : DbContext
    {
        public BranchDBContext() : base("name=BranchDBContext")
        {
        }

        public System.Data.Entity.DbSet<BankDB.Models.User> Users { get; set; }
    }
}