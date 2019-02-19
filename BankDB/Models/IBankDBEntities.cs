namespace BankDB.Models
{
    using System;
    using System.Data.Entity;

    public interface IBankDBEntities: IDisposable
    {
        DbSet<Bank> Banks { get; }
        DbSet<Branch> Branches { get; }
        DbSet<Rating> Ratings { get; }
        DbSet<User> Users { get; }

        int SaveChanges();

        int proc_SaveBank(Nullable<int> id, string routingNumber, string name, string street, string zipCode, Nullable<int> userId);
        int proc_SaveBranch(Nullable<int> id, Nullable<int> bankId, string name, string street, string zipCode, Nullable<int> userId);
        int proc_SaveRating(Nullable<int> id, Nullable<int> branchId, Nullable<int> value, string description, Nullable<int> userId);
        int proc_SaveUsers(Nullable<int> id, string name, string email, string password);
    }
}