using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ASimpleRepository.Interface;

namespace ASimpleRepository.Repository
{
    /// <summary>
    /// The unit of work implements <see cref="IUnitOfWork"/> interface which will control the transactions done using repository.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DbContext _entities = null;

        /// <summary>
        /// The list of repository in the the instance.
        /// </summary>
        public readonly Dictionary<Type, object> Repositories = new Dictionary<Type, object>();

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="connectionStringProvider">Connection string provider</param>
        public UnitOfWork(DbContext entities)
        {
            _entities = entities;
        }

        /// <summary>
        /// Get an instance of repository.
        /// </summary>
        /// <typeparam name="T">
        /// The entity
        /// </typeparam>
        /// <returns>
        /// The instance of repository for the entity.
        /// </returns>
        public IRepository<T> Repository<T>() where T : class
        {
            if (Repositories.Keys.Contains(typeof(T)))
            {
                return Repositories[typeof(T)] as IRepository<T>;
            }

            IRepository<T> repository = new Repository<T>(_entities);
            Repositories.Add(typeof(T), repository);
            return repository;
        }


        /// <summary>
        /// Save the changes in repository.
        /// </summary>
        public void SaveChanges()
        {
            _entities.SaveChanges();
        }
       
    }
}