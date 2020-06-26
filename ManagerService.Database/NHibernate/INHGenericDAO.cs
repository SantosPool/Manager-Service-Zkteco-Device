using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerService.Database.NHibernate
{
    public interface INHGenericDAO<T, PK> : IDAOGeneric<T, PK> where T : IGenericEntity<PK>
    {
        /// <summary>
        /// Metodo para guardar objetos y regresa la llave primaria asignada en base de datos.
        /// </summary>
        /// <param name="o">Objeto a persistir</param>
        /// <param name="session">Sesion de NHibernate</param>
        /// <returns>Id objeto persistido</returns>
        PK Save(T o, ISession session);

        /// <summary>
        /// Metodo utilizado para recuperar un objeto cuya PK coincida con la enviada
        /// </summary>
        /// <param name="id">ID del objeto</param>
        /// <param name="session">Sesion de NHibernate</param>
        /// <returns>Id objeto persistido</returns>
        T Get(PK id, ISession session);

        /// <summary>
        /// Metodo para actualizar objetos
        /// </summary>
        /// <param name="o">Objeto a actualizar</param>
        /// <param name="session">Sesion de NHibernate</param>
        void Update(T o, ISession session);

        /// <summary>
        /// Metodo para borrar objetos
        /// </summary>
        /// <param name="o">Objeto a borrar</param>
        /// <param name="session">Sesion de NHibernate</param>
        void Delete(T o, ISession session);

        /// <summary>
        /// Metodo utilizado para recuperar todos los objetos de un tipo de clase
        /// </summary>
        /// <param name="session">Sesion de NHibernate</param>
        /// <returns>IList<T>: Lista del tipo de objeto enviado</returns>
        IList<T> FindAll(ISession session);
    }
}
