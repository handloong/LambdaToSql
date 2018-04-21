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
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LambdaToSql
{
    /// <summary>
    /// LambdaToSqlCore
    /// </summary>
    /// <typeparam name="T"></typeparam>
	public class LambdaToSqlCore<T>
    {
        #region 私有字段
        /// <summary>
        /// _sqlPack
        /// </summary>
        private SqlPack _sqlPack = new SqlPack();
        #endregion

        #region 公有属性
        /// <summary>
        /// SqlStr
        /// </summary>
        public string SqlStr
        {
            get
            {
                return this._sqlPack.ToString();
            }
        }

        /// <summary>
        /// DbParams
        /// </summary>
        public Dictionary<string, object> DbParams
        {
            get
            {
                return this._sqlPack.DbParams;
            }
        }
        #endregion

        #region 构造函数
        /// <summary>
        /// LambdaToSqlCore
        /// </summary>
        /// <param name="dbType"></param>
        public LambdaToSqlCore(DatabaseType dbType)
        {
            this._sqlPack.DatabaseType = dbType;
        }
        #endregion

        #region Clear
        /// <summary>
        /// Clear
        /// </summary>
        public void Clear()
        {
            this._sqlPack.Clear();
        }
        #endregion

        #region Select
        /// <summary>
        /// SelectParser
        /// </summary>
        /// <param name="ary"></param>
        /// <returns></returns>
        private string SelectParser(params Type[] ary)
        {
            this._sqlPack.Clear();
            this._sqlPack.IsSingleTable = false;
            foreach (var item in ary)
            {
                var tableName = this._sqlPack.GetTableName(item);
                this._sqlPack.SetTableAlias(tableName);
            }
            var _tableName = this._sqlPack.GetTableName(typeof(T));
            return "SELECT {0}\nFROM " + _tableName + " AS " + this._sqlPack.GetTableAlias(_tableName);
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> Select(Expression<Func<T, object>> expression = null)
        {
            var sql = SelectParser(typeof(T));
            if (expression == null)
            {
                this._sqlPack.Sql.AppendFormat(sql, "*");
            }
            else
            {
                LambdaToSqlProvider.Select(expression.Body, this._sqlPack);
                this._sqlPack.Sql.AppendFormat(sql, this._sqlPack.SelectFieldsStr);
            }
            return this;
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> Select<T2>(Expression<Func<T, T2, object>> expression = null)
        {
            var sql = SelectParser(typeof(T), typeof(T2));
            if (expression == null)
            {
                this._sqlPack.Sql.AppendFormat(sql, "*");
            }
            else
            {
                LambdaToSqlProvider.Select(expression.Body, this._sqlPack);
                this._sqlPack.Sql.AppendFormat(sql, this._sqlPack.SelectFieldsStr);
            }
            return this;
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> Select<T2, T3>(Expression<Func<T, T2, T3, object>> expression = null)
        {
            var sql = SelectParser(typeof(T), typeof(T2), typeof(T3));
            if (expression == null)
            {
                this._sqlPack.Sql.AppendFormat(sql, "*");
            }
            else
            {
                LambdaToSqlProvider.Select(expression.Body, this._sqlPack);
                this._sqlPack.Sql.AppendFormat(sql, this._sqlPack.SelectFieldsStr);
            }
            return this;
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> Select<T2, T3, T4>(Expression<Func<T, T2, T3, T4, object>> expression = null)
        {
            var sql = SelectParser(typeof(T), typeof(T2), typeof(T3), typeof(T4));
            if (expression == null)
            {
                this._sqlPack.Sql.AppendFormat(sql, "*");
            }
            else
            {
                LambdaToSqlProvider.Select(expression.Body, this._sqlPack);
                this._sqlPack.Sql.AppendFormat(sql, this._sqlPack.SelectFieldsStr);
            }
            return this;
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> Select<T2, T3, T4, T5>(Expression<Func<T, T2, T3, T4, T5, object>> expression = null)
        {
            var sql = SelectParser(typeof(T), typeof(T2), typeof(T3), typeof(T4), typeof(T5));
            if (expression == null)
            {
                this._sqlPack.Sql.AppendFormat(sql, "*");
            }
            else
            {
                LambdaToSqlProvider.Select(expression.Body, this._sqlPack);
                this._sqlPack.Sql.AppendFormat(sql, this._sqlPack.SelectFieldsStr);
            }
            return this;
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> Select<T2, T3, T4, T5, T6>(Expression<Func<T, T2, T3, T4, T5, T6, object>> expression = null)
        {
            var sql = SelectParser(typeof(T), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6));
            if (expression == null)
            {
                this._sqlPack.Sql.AppendFormat(sql, "*");
            }
            else
            {
                LambdaToSqlProvider.Select(expression.Body, this._sqlPack);
                this._sqlPack.Sql.AppendFormat(sql, this._sqlPack.SelectFieldsStr);
            }
            return this;
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> Select<T2, T3, T4, T5, T6, T7>(Expression<Func<T, T2, T3, T4, T5, T6, T7, object>> expression = null)
        {
            var sql = SelectParser(typeof(T), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7));
            if (expression == null)
            {
                this._sqlPack.Sql.AppendFormat(sql, "*");
            }
            else
            {
                LambdaToSqlProvider.Select(expression.Body, this._sqlPack);
                this._sqlPack.Sql.AppendFormat(sql, this._sqlPack.SelectFieldsStr);
            }
            return this;
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> Select<T2, T3, T4, T5, T6, T7, T8>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, object>> expression = null)
        {
            var sql = SelectParser(typeof(T), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8));
            if (expression == null)
            {
                this._sqlPack.Sql.AppendFormat(sql, "*");
            }
            else
            {
                LambdaToSqlProvider.Select(expression.Body, this._sqlPack);
                this._sqlPack.Sql.AppendFormat(sql, this._sqlPack.SelectFieldsStr);
            }
            return this;
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> Select<T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, object>> expression = null)
        {
            var sql = SelectParser(typeof(T), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9));
            if (expression == null)
            {
                this._sqlPack.Sql.AppendFormat(sql, "*");
            }
            else
            {
                LambdaToSqlProvider.Select(expression.Body, this._sqlPack);
                this._sqlPack.Sql.AppendFormat(sql, this._sqlPack.SelectFieldsStr);
            }
            return this;
        }

        /// <summary>
        /// Select
        /// </summary>
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
        /// <returns></returns>
        public LambdaToSqlCore<T> Select<T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>> expression = null)
        {
            var sql = SelectParser(typeof(T), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10));
            if (expression == null)
            {
                this._sqlPack.Sql.AppendFormat(sql, "*");
            }
            else
            {
                LambdaToSqlProvider.Select(expression.Body, this._sqlPack);
                this._sqlPack.Sql.AppendFormat(sql, this._sqlPack.SelectFieldsStr);
            }
            return this;
        }
        #endregion

        #region Join
        /// <summary>
        /// JoinParser
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <param name="expression"></param>
        /// <param name="leftOrRightJoin"></param>
        /// <returns></returns>
        private LambdaToSqlCore<T> JoinParser<T2>(Expression<Func<T, T2, bool>> expression, string leftOrRightJoin = "")
        {
            string joinTableName = this._sqlPack.GetTableName(typeof(T2));
            this._sqlPack.SetTableAlias(joinTableName);
            this._sqlPack.Sql.AppendFormat("\n{0}JOIN {1} ON", leftOrRightJoin, joinTableName + " AS " + this._sqlPack.GetTableAlias(joinTableName));
            LambdaToSqlProvider.Join(expression.Body, this._sqlPack);
            return this;
        }

        /// <summary>
        /// JoinParser2
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="expression"></param>
        /// <param name="leftOrRightJoin"></param>
        /// <returns></returns>
        private LambdaToSqlCore<T> JoinParser2<T2, T3>(Expression<Func<T2, T3, bool>> expression, string leftOrRightJoin = "")
        {
            string joinTableName = this._sqlPack.GetTableName(typeof(T3));
            this._sqlPack.SetTableAlias(joinTableName);
            this._sqlPack.Sql.AppendFormat("\n{0}JOIN {1} ON", leftOrRightJoin, joinTableName + " AS " + this._sqlPack.GetTableAlias(joinTableName));
            LambdaToSqlProvider.Join(expression.Body, this._sqlPack);
            return this;
        }

        /// <summary>
        /// Join
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> Join<T2>(Expression<Func<T, T2, bool>> expression)
        {
            return JoinParser(expression);
        }

        /// <summary>
        /// Join
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> Join<T2, T3>(Expression<Func<T2, T3, bool>> expression)
        {
            return JoinParser2(expression);
        }

        /// <summary>
        /// InnerJoin
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> InnerJoin<T2>(Expression<Func<T, T2, bool>> expression)
        {
            return JoinParser(expression, "INNER ");
        }

        /// <summary>
        /// InnerJoin
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> InnerJoin<T2, T3>(Expression<Func<T2, T3, bool>> expression)
        {
            return JoinParser2(expression, "INNER ");
        }

        /// <summary>
        /// LeftJoin
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> LeftJoin<T2>(Expression<Func<T, T2, bool>> expression)
        {
            return JoinParser(expression, "LEFT ");
        }

        /// <summary>
        /// LeftJoin
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> LeftJoin<T2, T3>(Expression<Func<T2, T3, bool>> expression)
        {
            return JoinParser2(expression, "LEFT ");
        }

        /// <summary>
        /// RightJoin
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> RightJoin<T2>(Expression<Func<T, T2, bool>> expression)
        {
            return JoinParser(expression, "RIGHT ");
        }

        /// <summary>
        /// RightJoin
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> RightJoin<T2, T3>(Expression<Func<T2, T3, bool>> expression)
        {
            return JoinParser2(expression, "RIGHT ");
        }

        /// <summary>
        /// FullJoin
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> FullJoin<T2>(Expression<Func<T, T2, bool>> expression)
        {
            return JoinParser(expression, "FULL ");
        }

        /// <summary>
        /// FullJoin
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> FullJoin<T2, T3>(Expression<Func<T2, T3, bool>> expression)
        {
            return JoinParser2(expression, "FULL ");
        }
        #endregion

        #region Where
        /// <summary>
        /// Where
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> Where(Expression<Func<T, bool>> expression)
        {
            this._sqlPack += "\nWHERE";
            LambdaToSqlProvider.Where(expression.Body, this._sqlPack);
            return this;
        }
        #endregion

        #region GroupBy
        /// <summary>
        /// GroupBy
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> GroupBy(Expression<Func<T, object>> expression)
        {
            this._sqlPack += "\nGROUP BY ";
            LambdaToSqlProvider.GroupBy(expression.Body, this._sqlPack);
            return this;
        }
        #endregion

        #region OrderBy
        /// <summary>
        /// OrderBy
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> OrderBy(Expression<Func<T, object>> expression, params OrderType[] orders)
        {
            this._sqlPack += "\nORDER BY ";
            LambdaToSqlProvider.OrderBy(expression.Body, this._sqlPack, orders);
            return this;
        }
        #endregion

        #region Max
        /// <summary>
        /// Max
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> Max(Expression<Func<T, object>> expression)
        {
            this._sqlPack.Clear();
            this._sqlPack.IsSingleTable = true;
            LambdaToSqlProvider.Max(expression.Body, this._sqlPack);
            return this;
        }
        #endregion

        #region Min
        /// <summary>
        /// Min
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> Min(Expression<Func<T, object>> expression)
        {
            this._sqlPack.Clear();
            this._sqlPack.IsSingleTable = true;
            LambdaToSqlProvider.Min(expression.Body, this._sqlPack);
            return this;
        }
        #endregion

        #region Avg
        /// <summary>
        /// Avg
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> Avg(Expression<Func<T, object>> expression)
        {
            this._sqlPack.Clear();
            this._sqlPack.IsSingleTable = true;
            LambdaToSqlProvider.Avg(expression.Body, this._sqlPack);
            return this;
        }
        #endregion

        #region Count
        /// <summary>
        /// Count
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> Count(Expression<Func<T, object>> expression = null)
        {
            this._sqlPack.Clear();
            this._sqlPack.IsSingleTable = true;
            if (expression == null)
            {
                this._sqlPack.Sql.AppendFormat("SELECT COUNT(*) FROM {0}", this._sqlPack.GetTableName(typeof(T)));
            }
            else
            {
                LambdaToSqlProvider.Count(expression.Body, this._sqlPack);
            }
            return this;
        }
        #endregion

        #region Sum
        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> Sum(Expression<Func<T, object>> expression)
        {
            this._sqlPack.Clear();
            this._sqlPack.IsSingleTable = true;
            LambdaToSqlProvider.Sum(expression.Body, this._sqlPack);
            return this;
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete
        /// </summary>
        /// <returns></returns>
        public LambdaToSqlCore<T> Delete()
        {
            this._sqlPack.Clear();
            this._sqlPack.IsSingleTable = true;
            this._sqlPack += "DELETE " + this._sqlPack.GetTableName(typeof(T));
            return this;
        }
        #endregion

        #region Update
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> Update(Expression<Func<object>> expression = null)
        {
            this._sqlPack.Clear();
            this._sqlPack.IsSingleTable = true;
            this._sqlPack += "UPDATE " + this._sqlPack.GetTableName(typeof(T)) + " SET ";
            LambdaToSqlProvider.Update(expression.Body, this._sqlPack);
            return this;
        }
        #endregion

        #region Insert
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> Insert(Expression<Func<object>> expression = null)
        {
            this._sqlPack.Clear();
            this._sqlPack.IsSingleTable = true;
            this._sqlPack += "INSERT INTO " + this._sqlPack.GetTableName(typeof(T)) + "({0}) VALUES (";
            LambdaToSqlProvider.Insert(expression.Body, this._sqlPack);
            return this;
        }
        #endregion

        #region Page
        /// <summary>
        /// Page
        /// </summary>
        /// <param name="pageRows"></param>
        /// <param name="pageIndex"></param>
        /// <param name="orderBy"></param>
        /// <param name="sql"></param>
        /// <param name="dbParams"></param>
        /// <returns></returns>
        public LambdaToSqlCore<T> Page(int pageRows, int pageIndex, string orderBy, string sql = null, Dictionary<string, object> dbParams = null)
        {
            var sb = new StringBuilder();
            sql = string.IsNullOrEmpty(sql) ? this._sqlPack.Sql.ToString() : sql;
            //SQLServer、Oracle
            if (this._sqlPack.DatabaseType == DatabaseType.SQLServer || this._sqlPack.DatabaseType == DatabaseType.Oracle)
            {
                sb.Append($@"
    SELECT COUNT(1) AS Records FROM ({sql}) AS T;
    SELECT * FROM (
	    SELECT ROW_NUMBER() OVER (ORDER BY X.{orderBy}) AS RowNumber,X.* FROM ({sql}) AS X
    ) AS T WHERE T.RowNumber BETWEEN {(pageRows * (pageIndex - 1) + 1)} AND {(pageRows * pageIndex)}; ");
            }
            //MySQL
            if (this._sqlPack.DatabaseType == DatabaseType.MySQL)
            {
                sb.Append($@"
    SELECT COUNT(1) AS Records FROM ({sql}) AS T;
    SELECT * FROM ({sql}) AS X ORDER BY X.{orderBy} LIMIT {pageRows} OFFSET {(pageRows * (pageIndex - 1))}; ");
            }
            if (dbParams != null)
            {
                this._sqlPack.DbParams.Clear();
                this._sqlPack.DbParams = dbParams;
            }
            this._sqlPack.Sql.Clear().Append(sb);
            return this;
        }
        #endregion
    }
}
