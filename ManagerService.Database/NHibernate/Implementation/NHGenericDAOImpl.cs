using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerService.Database.NHibernate.Implementation
{
    public class NHGenericDAOImpl<T, PK> : INHGenericDAO<T, PK> where T : IGenericEntity<PK>
    {
        private ISession _session;
        private ITransaction _transaction;
        private Type _type = typeof(T);
        Object t = null;
        private const string ID = "Id", NAME = "Name";

        public NHGenericDAOImpl() { }

        public ISession Session
        {
            get
            {

                if (_session == null)
                {
                    _session = SessionUtilities.Open();
                }
                lock (_session)
                {
                    if (!_session.IsOpen)
                    {
                        _session = SessionUtilities.Open();
                    }
                }
                return _session;
            }

            set { _session = value; }

        }

        public ITransaction Transaction
        {
            get { return _transaction; }
            set { _transaction = value; }
        }

        public Type Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public void Delete(T o, ISession session)
        {
            try
            {
                session.Delete(o);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual void Delete(PK id)
        {
            Delete(id, null);
        }
        public void Delete(PK id, ISession session)
        {
            Delete(Get(id));
        }
        public void Delete(T o)
        {
            using (Session)
            {
                using (Transaction = Session.BeginTransaction())
                {
                    try
                    {
                        Delete(o, Session);
                        Transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
        }

        public IList<T> FindAll(ISession session)
        {
            if (session == null)
            {
                session = Session;
            }

            try
            {
                ICriteria c = Session.CreateCriteria(Type);
                return c.List<T>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public IList<T> FindAll()
        {
            using (Session)
            {
                try
                {
                    IList<T> l = FindAll(Session);
                    return l;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public T Get(PK id, ISession session)
        {
            try
            {
                return session.Get<T>(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public T Get(PK id)
        {
            using (Session)
            {
                try
                {
                    T o = Get(id, Session);
                    return o;
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }

        public PK Save(T o, ISession session)
        {
            if (o == null || session == null)
            {
                throw new ArgumentNullException();
            }
            try
            {
                return (PK)session.Save(o);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public PK Save(T o)
        {
            using (Session)
            {
                using (Transaction = Session.BeginTransaction())
                {
                    try
                    {
                        PK pk = Save(o, Session);
                        Transaction.Commit();
                        return pk;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
        }

        public void Update(T o, ISession session)
        {
            try
            {
                session.Update(o);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(T o)
        {
            using (Session)
            {
                using (Transaction = Session.BeginTransaction())
                {
                    try
                    {
                        Update(o, Session);
                        Transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
        }
    }
}
