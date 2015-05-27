using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Data
{
    public static class SqlExtension
    {

        /// <summary>
        /// Appends a "<paramref name="columnName"/> in (<paramref name="ids"/>)" sql (if <paramref name="ids"/> is not null or empty).
        /// </summary>
        /// <typeparam name="T">Type of the id.</typeparam>
        /// <param name="sqlObj">Sql builder object.</param>
        /// <param name="columnName">Column name (with alias).</param>
        /// <param name="ids">List of ids (can be null).</param>
        public static Sql WhereIn<T>(this Sql sqlObj, string columnName, IEnumerable<T> ids)
        {
            if (ids == null || !ids.Any())
                return sqlObj;

            return sqlObj.Where(columnName + " in (@0)", ids);
        }


        /// <summary>
        /// Appends a "<paramref name="columnName"/> in (<paramref name="ids"/>)" sql (if <paramref name="ids"/> is not null or empty).
        /// </summary>
        /// <param name="sqlObj">Sql builder object.</param>
        /// <param name="columnName">Column name (with alias).</param>
        /// <param name="ids">List of ids (can be null).</param>
        public static Sql WhereIn(this Sql sqlObj, string columnName, IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
                return sqlObj;

            return sqlObj.Where(columnName + " in (" + string.Join(",", ids.Select(x => x.ToString()).ToArray()) + ")");
        }


        /// <summary>
        /// Appends a "<paramref name="columnName"/> in (<paramref name="ids"/>)" sql (if <paramref name="ids"/> is not null or empty).
        /// </summary>
        /// <param name="sqlObj">Sql builder object.</param>
        /// <param name="columnName">Column name (with alias).</param>
        /// <param name="ids">List of ids (can be null).</param>
        public static Sql WhereIn(this Sql sqlObj, string columnName, IEnumerable<long> ids)
        {
            if (ids == null || !ids.Any())
                return sqlObj;

            return sqlObj.Where(columnName + " in (" + string.Join(",", ids.Select(x => x.ToString()).ToArray()) + ")");
        }

        /// <summary>
        /// Appends a "<paramref name="columnName"/> in (<paramref name="ids"/>)" sql (if <paramref name="ids"/> is not null or empty).
        /// </summary>
        /// <typeparam name="T">Type of the id.</typeparam>
        /// <param name="sqlObj">Sql builder object.</param>
        /// <param name="columnName">Column name (with alias).</param>
        /// <param name="ids">List of ids (can be null).</param>
        public static Sql WhereNotIn<T>(this Sql sqlObj, string columnName, IEnumerable<T> ids)
        {
            if (ids == null || !ids.Any())
                return sqlObj;

            return sqlObj.Where(columnName + " not in (@0)", ids);
        }


        /// <summary>
        /// Appends a "<paramref name="columnName"/> in (<paramref name="ids"/>)" sql (if <paramref name="ids"/> is not null or empty).
        /// </summary>
        /// <param name="sqlObj">Sql builder object.</param>
        /// <param name="columnName">Column name (with alias).</param>
        /// <param name="ids">List of ids (can be null).</param>
        public static Sql WhereNotIn(this Sql sqlObj, string columnName, IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
                return sqlObj;

            return sqlObj.Where(columnName + " not in (" + string.Join(",", ids.Select(x => x.ToString()).ToArray()) + ")");
        }


        /// <summary>
        /// Appends a "<paramref name="columnName"/> in (<paramref name="ids"/>)" sql (if <paramref name="ids"/> is not null or empty).
        /// </summary>
        /// <param name="sqlObj">Sql builder object.</param>
        /// <param name="columnName">Column name (with alias).</param>
        /// <param name="ids">List of ids (can be null).</param>
        public static Sql WhereNotIn(this Sql sqlObj, string columnName, IEnumerable<long> ids)
        {
            if (ids == null || !ids.Any())
                return sqlObj;

            return sqlObj.Where(columnName + " not in (" + string.Join(",", ids.Select(x => x.ToString()).ToArray()) + ")");
        }
    }
}
