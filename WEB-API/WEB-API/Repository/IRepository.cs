using System.Linq.Expressions;

namespace WEB_API.Repository
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// This function will receive an object as parameter and should add it to the database.
        /// </summary>
        /// <param name="entity">The entity object to be added.</param>
        void Add(T entity);

        /// <summary>
        /// This function will receive an object as parameter and should update it in the database.
        /// </summary>
        /// <param name="entity">The entity object to be updated.</param>
        void Update(T entity);

        /// <summary>
        /// This function will receive an object as parameter and should remove it from the database.
        /// </summary>
        /// <param name="entity">The entity object to be removed.</param>
        void Remove(T entity);

        /// <summary>
        /// This function won't receive parameter and should return all registers found in this entity.
        /// </summary>
        /// <returns>Returns all registers found in this entity.</returns>
        IList<T> GetAll();

        /// <summary>
        /// This function will receive the "ID" as parameter and should return the object found.
        /// </summary>
        /// <param name="id">The ID value to be used on the search.</param>
        /// <returns>Returns the object found</returns>
        T GetById(int? id);

        /// <summary>
        /// This function will receive the "Name" as parameter and should return the object found.
        /// </summary>
        /// <param name="name">The Name value to be used on the search.</param>
        /// <returns>Returns the object found</returns>
        T GetByName(string name);

        /// <summary>
        /// This function will receive an expression as parameter and should return results from the execute.
        /// </summary>
        /// <param name="filter">The filter expression to be used on the search.</param>
        /// <returns>Returns a list with the objects found on the execution.</returns>
        IList<T> Query(Expression<Func<T, bool>> filter);
    }
}
