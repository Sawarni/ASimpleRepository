using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ASimpleRepository.Interface
{
    /// <summary>
    /// The generic interface to implement respository pattern.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The generic entity.
    /// </typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// This method gets all the enitity set which matches the record.
        /// </summary>
        /// <param name="predicate">
        /// The condition to get the records. If no predicate is set, it will return all the records.
        /// </param>
        /// <returns>
        /// The collection of elements
        /// </returns>
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// This method gets a certain element from the list. If no element is present then a null value is returned.
        /// </summary>
        /// <param name="predicate">
        /// The predicate to match the condition.
        /// </param>
        /// <returns>
        /// An element from the list.
        /// </returns>
        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Add a new element to the list
        /// </summary>
        /// <param name="entity">the element to be added.</param>
        void AddOrUpdate(TEntity entity);

        /// <summary>
        /// Delete an element from the list
        /// </summary>
        /// <param name="entity">
        /// The element to be deleted.
        /// </param>
        void Delete(TEntity entity);

        /// <summary>
        /// Checks whether any element matching the condition is present or not.
        /// </summary>
        /// <param name="predicate">
        /// The condition.
        /// </param>
        /// <returns>
        /// A boolean value indicating whether the element matching the condition is present or not.
        /// </returns>
        bool Any(Expression<Func<TEntity, bool>> predicate);

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
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] navigationProperties);
    }
}