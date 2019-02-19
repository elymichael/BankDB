namespace BankDB.Tests
{
    using System;
    using System.Data.Entity;
    using BankDB.Models;

    public class TestBankDBContext : IBankDBEntities
    {
        public TestBankDBContext()
        {
            this.Ratings = new TestRatingDbSet();
            this.Banks = new TestBankDbSet();
            this.Branches = new TestBranchDbSet();
            this.Users = new TestUserDbSet();
        }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Bank> Banks { get; set; }

        public DbSet<Branch> Branches { get; set; }

        public DbSet<User> Users { get; set; }

        public int SaveChanges()
        {
            return 0;
        }
        
        public void Dispose() { }

        public int proc_SaveBank(int? id, string routingNumber, string name, string street, string zipCode, int? userId)
        {
            return 1;
        }

        public int proc_SaveBranch(int? id, int? bankId, string name, string street, string zipCode, int? userId)
        {
            return 1;
        }

        public int proc_SaveRating(int? id, int? branchId, int? value, string description, int? userId)
        {
            return 1;
        }

        public int proc_SaveUsers(int? id, string name, string email, string password)
        {
            return 1;
        }
    }
}
