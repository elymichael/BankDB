﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BankDB.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BankDBEntities : DbContext, IBankDBEntities
    {
        public BankDBEntities()
            : base("name=BankDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual int proc_SaveBank(Nullable<int> id, string routingNumber, string name, string street, string zipCode, Nullable<int> userId)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var routingNumberParameter = routingNumber != null ?
                new ObjectParameter("RoutingNumber", routingNumber) :
                new ObjectParameter("RoutingNumber", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var streetParameter = street != null ?
                new ObjectParameter("Street", street) :
                new ObjectParameter("Street", typeof(string));
    
            var zipCodeParameter = zipCode != null ?
                new ObjectParameter("ZipCode", zipCode) :
                new ObjectParameter("ZipCode", typeof(string));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proc_SaveBank", idParameter, routingNumberParameter, nameParameter, streetParameter, zipCodeParameter, userIdParameter);
        }
    
        public virtual int proc_SaveBranch(Nullable<int> id, Nullable<int> bankId, string name, string street, string zipCode, Nullable<int> userId)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var bankIdParameter = bankId.HasValue ?
                new ObjectParameter("BankId", bankId) :
                new ObjectParameter("BankId", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var streetParameter = street != null ?
                new ObjectParameter("Street", street) :
                new ObjectParameter("Street", typeof(string));
    
            var zipCodeParameter = zipCode != null ?
                new ObjectParameter("ZipCode", zipCode) :
                new ObjectParameter("ZipCode", typeof(string));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proc_SaveBranch", idParameter, bankIdParameter, nameParameter, streetParameter, zipCodeParameter, userIdParameter);
        }
    
        public virtual int proc_SaveRating(Nullable<int> id, Nullable<int> branchId, Nullable<int> value, string description, Nullable<int> userId)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var branchIdParameter = branchId.HasValue ?
                new ObjectParameter("BranchId", branchId) :
                new ObjectParameter("BranchId", typeof(int));
    
            var valueParameter = value.HasValue ?
                new ObjectParameter("Value", value) :
                new ObjectParameter("Value", typeof(int));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proc_SaveRating", idParameter, branchIdParameter, valueParameter, descriptionParameter, userIdParameter);
        }
    
        public virtual int proc_SaveUsers(Nullable<int> id, string name, string email, string password)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proc_SaveUsers", idParameter, nameParameter, emailParameter, passwordParameter);
        }
    }
}
