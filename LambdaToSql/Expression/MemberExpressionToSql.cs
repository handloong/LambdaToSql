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
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LambdaToSql
{
    /// <summary>
    /// 表示访问字段或属性
    /// </summary>
	public class MemberExpressionToSql : BaseLambdaToSql<MemberExpression>
    {
        #region 私有方法
        /// <summary>
        /// 获取对象格式化后的值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private string GetValueFormat(object obj)
        {
            var sql = string.Empty;
            if (obj != null)
            {
                var type = obj.GetType();
                switch (type)
                {
                    //string
                    case Type T when T == typeof(string):
                        sql = $"'{obj.ToString()}'";
                        break;
                    //DateTime
                    case Type T when T == typeof(DateTime):
                        sql = $"'{((DateTime)obj).ToString("yyyy-MM-dd HH:mm:ss fff")}'";
                        break;
                    //int、decimal、double、float
                    case Type T when T == typeof(int) || T == typeof(decimal) || T == typeof(double) || T == typeof(float) || T == typeof(Single):
                        sql = $"{obj.ToString()}";
                        break;
                    //bool
                    case Type T when T == typeof(bool):
                        var x = Convert.ToBoolean(obj);
                        sql = x ? "1" : "0";
                        break;
                }
            }
            return sql;
        }
        #endregion

        #region 基类方法重写
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public override SqlPack Insert(MemberExpression expression, SqlPack sqlPack)
        {
            var lambda = Expression.Lambda<Func<object>>(expression);
            var obj = lambda.Compile().Invoke();
            var properties = obj?.GetType().GetProperties();
            var fields = new List<string>();
            foreach (var item in properties)
            {
                sqlPack.AddDbParameter(item.GetValue(obj, null));
                fields.Add(item.Name);
                sqlPack += ",";
            }
            if (sqlPack[sqlPack.Length - 1] == ',')
            {
                sqlPack.Sql.Remove(sqlPack.Length - 1, 1);
                sqlPack.Sql.Append(")");
            }
            sqlPack.Sql = new StringBuilder(string.Format(sqlPack.ToString(), string.Join(",", fields).TrimEnd(',')));
            return sqlPack;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public override SqlPack Update(MemberExpression expression, SqlPack sqlPack)
        {
            var lambda = Expression.Lambda<Func<object>>(expression);
            var obj = lambda.Compile().Invoke();
            var properties = obj?.GetType().GetProperties();
            foreach (var item in properties)
            {
                sqlPack += item.Name + " =";
                sqlPack.AddDbParameter(item.GetValue(obj, null));
                sqlPack += ",";
            }
            if (sqlPack[sqlPack.Length - 1] == ',')
            {
                sqlPack.Sql.Remove(sqlPack.Length - 1, 1);
            }
            return sqlPack;
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
		public override SqlPack Select(MemberExpression expression, SqlPack sqlPack)
        {
            var tableName = sqlPack.GetTableName(expression.Member.DeclaringType);
            sqlPack.SetTableAlias(tableName);
            string tableAlias = sqlPack.GetTableAlias(tableName);
            if (!string.IsNullOrWhiteSpace(tableAlias))
            {
                tableAlias += ".";
            }
            sqlPack.SelectFields.Add(tableAlias + expression.Member.Name);
            return sqlPack;
        }

        /// <summary>
        /// Join
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
		public override SqlPack Join(MemberExpression expression, SqlPack sqlPack)
        {
            var tableName = sqlPack.GetTableName(expression.Member.DeclaringType);
            sqlPack.SetTableAlias(tableName);
            string tableAlias = sqlPack.GetTableAlias(tableName);
            if (!string.IsNullOrWhiteSpace(tableAlias))
            {
                tableAlias += ".";
            }
            sqlPack += " " + tableAlias + expression.Member.Name;
            return sqlPack;
        }

        /// <summary>
        /// Where
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
		public override SqlPack Where(MemberExpression expression, SqlPack sqlPack)
        {
            if (!expression.Member.DeclaringType.Name.Contains("<>"))
            {
                var tableName = sqlPack.GetTableName(expression.Member.DeclaringType);
                sqlPack.SetTableAlias(tableName);
                string tableAlias = sqlPack.GetTableAlias(tableName);
                if (!string.IsNullOrWhiteSpace(tableAlias))
                {
                    tableAlias += ".";
                }
                sqlPack += " " + tableAlias + expression.Member.Name;
            }
            else
            {
                object obj = null;
                switch (expression.Type.Name)
                {
                    case "Int16":
                        obj = Expression.Lambda<Func<Int16>>(expression).Compile().Invoke();
                        break;
                    case "Int32":
                        obj = Expression.Lambda<Func<Int32>>(expression).Compile().Invoke();
                        break;
                    case "Int64":
                        obj = Expression.Lambda<Func<Int64>>(expression).Compile().Invoke();
                        break;
                    case "Boolean":
                        obj = Expression.Lambda<Func<bool>>(expression).Compile().Invoke();
                        break;
                    default:
                        obj = Expression.Lambda<Func<object>>(expression).Compile().Invoke();
                        break;
                }
                sqlPack.AddDbParameter(obj);
            }
            return sqlPack;
        }

        /// <summary>
        /// In
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
		public override SqlPack In(MemberExpression expression, SqlPack sqlPack)
        {
            var lambda = Expression.Lambda<Func<object>>(expression);
            var obj = lambda.Compile().Invoke();
            if (obj is IEnumerable array)
            {
                string itemJoinStr = "";
                foreach (var item in array)
                {
                    if (obj.GetType().Name == "String[]")
                    {
                        itemJoinStr += string.Format(",'{0}'", item);
                    }
                    else
                    {
                        itemJoinStr += string.Format(",{0}", item);
                    }
                }
                if (itemJoinStr.Length > 0)
                {
                    itemJoinStr = itemJoinStr.Remove(0, 1);
                    itemJoinStr = string.Format("({0})", itemJoinStr);
                    sqlPack += itemJoinStr;
                }
            }
            return sqlPack;
        }

        /// <summary>
        /// GroupBy
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
		public override SqlPack GroupBy(MemberExpression expression, SqlPack sqlPack)
        {
            var tableName = sqlPack.GetTableName(expression.Member.DeclaringType);
            sqlPack.SetTableAlias(tableName);
            sqlPack += sqlPack.GetTableAlias(tableName) + "." + expression.Member.Name + ",";
            return sqlPack;
        }

        /// <summary>
        /// OrderBy
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
		public override SqlPack OrderBy(MemberExpression expression, SqlPack sqlPack, params OrderType[] orders)
        {
            var tableName = sqlPack.GetTableName(expression.Member.DeclaringType);
            sqlPack.SetTableAlias(tableName);
            sqlPack += sqlPack.GetTableAlias(tableName) + "." + expression.Member.Name;
            return sqlPack;
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
		public override SqlPack Max(MemberExpression expression, SqlPack sqlPack)
        {
            sqlPack.Sql.AppendFormat("SELECT MAX({0}) FROM {1}", expression.Member.Name, sqlPack.GetTableName(expression.Member.DeclaringType));
            return sqlPack;
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
		public override SqlPack Min(MemberExpression expression, SqlPack sqlPack)
        {
            sqlPack.Sql.AppendFormat("SELECT MIN({0}) FROM {1}", expression.Member.Name, sqlPack.GetTableName(expression.Member.DeclaringType));
            return sqlPack;
        }

        /// <summary>
        /// Avg
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
		public override SqlPack Avg(MemberExpression expression, SqlPack sqlPack)
        {
            sqlPack.Sql.AppendFormat("SELECT AVG({0}) FROM {1}", expression.Member.Name, sqlPack.GetTableName(expression.Member.DeclaringType));
            return sqlPack;
        }

        /// <summary>
        /// Count
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
		public override SqlPack Count(MemberExpression expression, SqlPack sqlPack)
        {
            sqlPack.Sql.AppendFormat("SELECT COUNT({0}) FROM {1}", expression.Member.Name, sqlPack.GetTableName(expression.Member.DeclaringType));
            return sqlPack;
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
		public override SqlPack Sum(MemberExpression expression, SqlPack sqlPack)
        {
            sqlPack.Sql.AppendFormat("SELECT SUM({0}) FROM {1}", expression.Member.Name, sqlPack.GetTableName(expression.Member.DeclaringType));
            return sqlPack;
        }
        #endregion
    }
}