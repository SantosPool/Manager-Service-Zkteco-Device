using ManagerService.Database.NHibernate.Implementation;
using ManagerService.Entities.Entities;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;

namespace ManagerService.Repositories.Impl
{
    public class UserDAOImpl : NHGenericDAOImpl<User, Int64>, IUserDAO
    {
        public IList<object> GetUsers()
        {
            //ICriteria criteria = Session.CreateCriteria(typeof(User));
            ////IList<DataMCI> result = Session.CreateSQLQuery("exec [dbo].[InformationMCI]")
            ////.SetParameter("param1", id, NHibernateUtil.Int32)
            ////.SetParameter("param2", fromDate, NHibernateUtil.DateTime)
            ////.SetParameter("param3", toDate, NHibernateUtil.DateTime)
            ////.SetResultTransformer(Transformers.AliasToBean<DataMCI>()).List<DataMCI>();
            //return criteria.List<object>();
            ICriteria criteria = Session.CreateCriteria(typeof(User));
            criteria.SetProjection(Projections.ProjectionList()
                    .Add(Projections.Property("Username"))
                    .Add(Projections.Property("Id")));
            return criteria.List<object>();
        }
    }
}
