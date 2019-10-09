using System;
using System.Collections.Generic;

namespace Framework.Patterns.Container
{
    /// <summary>
    /// Extension methods for <see cref="IEnumerable{T}"/>
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Runs a for each loop on each item of an <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="T">Type in the container</typeparam>
        /// <param name="container">Container</param>
        /// <param name="action">lambda to perform on each object of <see cref="container"/></param>
        public static void ForEach<T>(this IEnumerable<T> container, Action<T> action)
        {
            foreach(var item in container)
            {
                action(item);
            }
        }
    }
}
