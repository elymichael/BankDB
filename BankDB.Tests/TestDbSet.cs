namespace BankDB.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Linq;
    using BankDB.Models;

    public class TestDbSet<T> : DbSet<T>, IQueryable, IEnumerable<T>
        where T : class
    {
        ObservableCollection<T> _data;
        IQueryable _query;

        public TestDbSet()
        {
            _data = new ObservableCollection<T>();
            _query = _data.AsQueryable();
        }

        public override T Add(T item)
        {
            _data.Add(item);
            return item;
        }

        public override T Remove(T item)
        {
            _data.Remove(item);
            return item;
        }

        public override T Attach(T item)
        {
            _data.Add(item);
            return item;
        }

        public override T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public override TDerivedEntity Create<TDerivedEntity>()
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public override ObservableCollection<T> Local
        {
            get { return new ObservableCollection<T>(_data); }
        }

        Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return _query.Provider; }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }
    }

    class TestRatingDbSet : TestDbSet<Rating>
    {
        public override Rating Find(params object[] keyValues)
        {
            return this.SingleOrDefault(rating => rating.Id == (int)keyValues.Single());
        }
    }

    class TestBankDbSet : TestDbSet<Bank>
    {
        public override Bank Find(params object[] keyValues)
        {
            return this.SingleOrDefault(bank => bank.Id == (int)keyValues.Single());
        }
    }

    class TestBranchDbSet : TestDbSet<Branch>
    {
        public override Branch Find(params object[] keyValues)
        {
            return this.SingleOrDefault(branch => branch.Id == (int)keyValues.Single());
        }
    }

    class TestUserDbSet : TestDbSet<User>
    {
        public override User Find(params object[] keyValues)
        {
            return this.SingleOrDefault(user => user.Id == (int)keyValues.Single());
        }
    }
}
