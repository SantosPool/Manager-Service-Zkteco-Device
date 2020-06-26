using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerService.Database.NHibernate
{
    public interface IDAOGeneric<T, PK> where T : IGenericEntity<PK>
    {
        /// <summary>
        /// Metodo para guardar cualquier tipo de objeto
        /// </summary>
        /// <param name="o">T: Class del Objeto a guardar</param>
        /// <returns></returns>
        PK Save(T o);

        /// <summary>
        /// Metodo para obtener cualquier objeto
        /// </summary>
        /// <param name="id">PK: id del objeto a recuperar</param>
        /// <returns>T: regresa un objeto dependiendo del tipo de clase</returns>
        T Get(PK id);

        /// <summary>
        /// Metodo para actualizar objetos
        /// </summary>
        /// <param name="o">T: Se envia el objeto a ser actualizado</param>
        void Update(T o);

        /// <summary>
        /// Metodo para eliminar objetos
        /// </summary>
        /// <param name="id">PK: id del objeto a ser eliminado</param>
        void Delete(PK id);

        /// <summary>
        /// Metodo utilizado para recuperar todos los objetos de un tipo de clase
        /// </summary>
        /// <returns> IList<T>: Lista del tipo de objeto enviado </returns>
        IList<T> FindAll();

    }
}
