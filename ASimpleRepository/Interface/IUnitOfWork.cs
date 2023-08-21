using System;

namespace ASimpleRepository.Interface
{
    /// <summary>
    /// The unit of work interface which will control the transactions done using repository.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Get an instance of repository.
        /// </summary>
        /// <typeparam name="T">
        /// The entity
        /// </typeparam>
        /// <returns>
        /// The instance of repository for the entity.
        /// </returns>
        IRepository<T> Repository<T>() where T : class;

        /// <summary>
        /// Save the changes in repository.
        /// </summary>
        void SaveChanges();

    }
}