using System;
using System.Collections.Generic;
using System.Linq;

namespace Technical.Extentions
{
    /// <summary>
    /// Classe d’extention pour les types ICollection
    /// </summary>
    static class ICollectionExtention
    {
        /// <summary>
        /// Clone d’une liste de type <see cref="ICollection{T}"/>
        /// </summary>
        public static ICollection<T> Clone<T>(this ICollection<T> list) where T : ICloneable
        {
            return list.Select(i => (T)i.Clone()).ToList();
        }

        /// <summary>
        /// Clone d’une liste de type <see cref="IEnumerable{T}"/>
        /// </summary>
        public static IEnumerable<T> Clone<T>(this IEnumerable<T> list) where T : ICloneable
        {
            return list.Select(i => (T)i.Clone()).ToList();
        }

        /// <summary>
        /// Clone d’une liste de type <see cref="IList{T}"/>
        /// </summary>
        public static IList<T> Clone<T>(this IList<T> list) where T : ICloneable
        {
            return list.Select(i => (T)i.Clone()).ToList();
        }

        /// <summary>
        /// Clone d’une liste de type <see cref="List{T}"/>
        /// </summary>
        public static List<T> Clone<T>(this List<T> list) where T : ICloneable
        {
            return list.Select(i => (T)i.Clone()).ToList();
        }
    }
}