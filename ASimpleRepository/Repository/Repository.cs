using ASimpleRepository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;


namespace ASimpleRepository.Repository
{
    /// <summary>
    /// The repository pattern.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The entity
    /// </typeparam>
    class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        private DbSet<TEntity> objectSet;

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="entities">
        /// The entitiy context.
        /// </param>
        public Repository(DbContext entities)
        {
            objectSet = entities.Set<TEntity>();
        }


        /// <summary>
        /// This method gets all the enitity set which matches the record.
        /// </summary>
        /// <param name="predicate">
        /// The condition to get the records. If no predicate is set, it will return all the records.
        /// </param>
        /// <returns>
        /// The collection of elements
        /// </returns>
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return objectSet.Where(predicate);
            }

            return objectSet.AsEnumerable();
        }


        /// <summary>
        /// This method gets a certain element from the list. If no element is present then a null value is returned.
        /// </summary>
        /// <param name="predicate">
        /// The predicate to match the condition.
        /// </param>
        /// <returns>
        /// An element from the list.
        /// </returns>
        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return objectSet.FirstOrDefault(predicate);
        }

        /// <summary>
        /// Add or update a new element to the list
        /// </summary>
        /// <param name="entity">the element to be added.</param>
        public void AddOrUpdate(TEntity entity)
        {
            objectSet.AddOrUpdate(entity);
        }


        /// <summary>
        /// Delete an element from the list
        /// </summary>
        /// <param name="entity">
        /// The element to be deleted.
        /// </param>
        public void Delete(TEntity entity)
        {
            objectSet.Remove(entity);
        }

        /// <summary>
        /// Checks whether any element matching the condition is present or not.
        /// </summary>
        /// <param name="predicate">
        /// The condition.
        /// </param>
        /// <returns>
        /// A boolean value indicating whether the element matching the condition is present or not.
        /// </returns>
        public bool Any(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return objectSet.Any(predicate);
            }

            return objectSet.Any();
        }

        /// <summary>
        /// This method gets entity with child in navigation properties.
        /// </summary>
        /// <param name="predicate">
        /// The predicate
        /// </param>
        /// <param name="navigationProperties">
        /// The navigation properties.
        /// </param>
        /// <returns>
        /// The list of entity.
        /// </returns>
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] navigationProperties)
        {

            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
            {
                objectSet.Include(navigationProperty);
            }

            return objectSet.Where(predicate);
        }
    }
}
