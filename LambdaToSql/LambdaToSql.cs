#region License
/**
 * Copyright (c) 2018, 张强 (943620963@qq.com).
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * without warranties or conditions of any kind, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#endregion

using System;
using System.Linq.Expressions;

namespace LambdaToSql
{
    /// <summary>
    /// LambdaToSql
    /// </summary>
	public static class LambdaToSql
    {
        #region 新增
        /// <summary>
        /// Insert
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <param name="DatabaseType"></param>
        /// <returns></returns>
        public static LambdaToSqlCore<T> Insert<T>(Expression<Func<object>> expression = null, DatabaseType DatabaseType = DatabaseType.SQLServer)
        {
            return new LambdaToSqlCore<T>(DatabaseType).Insert(expression);
        }
        #endregion

        #region 删除
        /// <summary>
        /// Delete
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="DatabaseType"></param>
        /// <returns></returns>
        public static LambdaToSqlCore<T> Delete<T>(DatabaseType DatabaseType = DatabaseType.SQLServer)
        {
            return new LambdaToSqlCore<T>(DatabaseType).Delete();
        }
        #endregion

        #region 更新
        /// <summary>
        /// Update
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <param name="DatabaseType"></param>
        /// <returns></returns>
        public static LambdaToSqlCore<T> Update<T>(Expression<Func<object>> expression = null, DatabaseType DatabaseType = DatabaseType.SQLServer)
        {
            return new LambdaToSqlCore<T>(DatabaseType).Update(expression);
        }
        #endregion

        #region 查询
        /// <summary>
        /// Select
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <param name="DatabaseType"></param>
        /// <returns></returns>
        public static LambdaToSqlCore<T> Select<T>(Expression<Func<T, object>> expression = null, DatabaseType DatabaseType = DatabaseType.SQLServer)
        {
            return new LambdaToSqlCore<T>(DatabaseType).Select(expression);
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="expression"></param>
        /// <param name="DatabaseType"></param>
        /// <returns></returns>
        public static LambdaToSqlCore<T> Select<T, T2>(Expression<Func<T, T2, object>> expression = null, DatabaseType DatabaseType = DatabaseType.SQLServer)
        {
            return new LambdaToSqlCore<T>(DatabaseType).Select(expression);
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="expression"></param>
        /// <param name="DatabaseType"></param>
        /// <returns></returns>
        public static LambdaToSqlCore<T> Select<T, T2, T3>(Expression<Func<T, T2, T3, object>> expression = null, DatabaseType DatabaseType = DatabaseType.SQLServer)
        {
            return new LambdaToSqlCore<T>(DatabaseType).Select(expression);
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="expression"></param>
        /// <param name="DatabaseType"></param>
        /// <returns></returns>
        public static LambdaToSqlCore<T> Select<T, T2, T3, T4>(Expression<Func<T, T2, T3, T4, object>> expression = null, DatabaseType DatabaseType = DatabaseType.SQLServer)
        {
            return new LambdaToSqlCore<T>(DatabaseType).Select(expression);
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="expression"></param>
        /// <param name="DatabaseType"></param>
        /// <returns></returns>
        public static LambdaToSqlCore<T> Select<T, T2, T3, T4, T5>(Expression<Func<T, T2, T3, T4, T5, object>> expression = null, DatabaseType DatabaseType = DatabaseType.SQLServer)
        {
            return new LambdaToSqlCore<T>(DatabaseType).Select(expression);
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <param name="expression"></param>
        /// <param name="DatabaseType"></param>
        /// <returns></returns>
        public static LambdaToSqlCore<T> Select<T, T2, T3, T4, T5, T6>(Expression<Func<T, T2, T3, T4, T5, T6, object>> expression = null, DatabaseType DatabaseType = DatabaseType.SQLServer)
        {
            return new LambdaToSqlCore<T>(DatabaseType).Select(expression);
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <param name="expression"></param>
        /// <param name="DatabaseType"></param>
        /// <returns></returns>
        public static LambdaToSqlCore<T> Select<T, T2, T3, T4, T5, T6, T7>(Expression<Func<T, T2, T3, T4, T5, T6, T7, object>> expression = null, DatabaseType DatabaseType = DatabaseType.SQLServer)
        {
            return new LambdaToSqlCore<T>(DatabaseType).Select(expression);
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <param name="expression"></param>
        /// <param name="DatabaseType"></param>
        /// <returns></returns>
        public static LambdaToSqlCore<T> Select<T, T2, T3, T4, T5, T6, T7, T8>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, object>> expression = null, DatabaseType DatabaseType = DatabaseType.SQLServer)
        {
            return new LambdaToSqlCore<T>(DatabaseType).Select(expression);
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <param name="expression"></param>
        /// <param name="DatabaseType"></param>
        /// <returns></returns>
        public static LambdaToSqlCore<T> Select<T, T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, object>> expression = null, DatabaseType DatabaseType = DatabaseType.SQLServer)
        {
            return new LambdaToSqlCore<T>(DatabaseType).Select(expression);
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T10"></typeparam>
        /// <param name="expression"></param>
        /// <param name="DatabaseType"></param>
        /// <returns></returns>
        public static LambdaToSqlCore<T> Select<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>> expression = null, DatabaseType DatabaseType = DatabaseType.SQLServer)
        {
            return new LambdaToSqlCore<T>(DatabaseType).Select(expression);
        }
        #endregion

        #region 最大值
        /// <summary>
        /// Max
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <param name="DatabaseType"></param>
        /// <returns></returns>
        public static LambdaToSqlCore<T> Max<T>(Expression<Func<T, object>> expression, DatabaseType DatabaseType = DatabaseType.SQLServer)
        {
            return new LambdaToSqlCore<T>(DatabaseType).Max(expression);
        }
        #endregion

        #region 最小值
        /// <summary>
        /// Min
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <param name="DatabaseType"></param>
        /// <returns></returns>
        public static LambdaToSqlCore<T> Min<T>(Expression<Func<T, object>> expression, DatabaseType DatabaseType = DatabaseType.SQLServer)
        {
            return new LambdaToSqlCore<T>(DatabaseType).Min(expression);
        }
        #endregion

        #region 平均值
        /// <summary>
        /// Avg
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <param name="DatabaseType"></param>
        /// <returns></returns>
        public static LambdaToSqlCore<T> Avg<T>(Expression<Func<T, object>> expression, DatabaseType DatabaseType = DatabaseType.SQLServer)
        {
            return new LambdaToSqlCore<T>(DatabaseType).Avg(expression);
        }
        #endregion

        #region 计数
        /// <summary>
        /// Count
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <param name="DatabaseType"></param>
        /// <returns></returns>
        public static LambdaToSqlCore<T> Count<T>(Expression<Func<T, object>> expression = null, DatabaseType DatabaseType = DatabaseType.SQLServer)
        {
            return new LambdaToSqlCore<T>(DatabaseType).Count(expression);
        }
        #endregion

        #region 求和
        /// <summary>
        /// Sum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <param name="DatabaseType"></param>
        /// <returns></returns>
        public static LambdaToSqlCore<T> Sum<T>(Expression<Func<T, object>> expression, DatabaseType DatabaseType = DatabaseType.SQLServer)
        {
            return new LambdaToSqlCore<T>(DatabaseType).Sum(expression);
        }
        #endregion
    }
}
