namespace BankDB.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;

    public class Bank
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

    public class BankDBContext : DbContext
    {
        public BankDBContext() : base("name=BankDBContext")
        {
        }

        public System.Data.Entity.DbSet<BankDB.Models.User> Users { get; set; }
    }
}