using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WEB_API.DataContext;

namespace WEB_API.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Properties

        /// <summary>
        /// ApplicationDbContext object responsible to stablish the connection with database using EntityFramework
        /// </summary>
        private readonly ApplicationDbContext _applicationDbContext;

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Repository constructor create to initialize the "_applicationDbContext" using Dependency Injection.
        /// </summary>
        /// <param name="context">ApplicationDbContext object used to initialize the internal variable using Dependency Injection.</param>
        public Repository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        /// <inheritdoc />
        public void Add(T entity)
        {
            _applicationDbContext.Set<T>().Add(entity);
            SaveChanges();
        }

        /// <inheritdoc />
        public void Update(T entity)
        {
            _applicationDbContext.Entry(entity).State = EntityState.Modified;
            SaveChanges();
        }

        /// <inheritdoc />
        public void Remove(T entity)
        {
            _applicationDbContext.Set<T>().Remove(entity);
            SaveChanges();
        }

        /// <inheritdoc />
        public T GetById(int? id)
        {
            return _applicationDbContext.Set<T>().Find(id);
        }

        /// <inheritdoc />
        public T GetByName(string name)
        {
            return _applicationDbContext.Set<T>().Find(name);
        }

        /// <inheritdoc />
        public IList<T> Query(Expression<Func<T, bool>> filter)
        {
            return _applicationDbContext.Set<T>().Where(filter).ToList();
        }

        /// <inheritdoc />
        public IList<T> GetAll()
        {
            return _applicationDbContext.Set<T>().ToList();
        }

        #endregion Public methods

        #region Private methods

        /// <summary>
        /// This function should be commit the changes on the database.
        /// </summary>
        private void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }

        #endregion Private methods
    }
}
