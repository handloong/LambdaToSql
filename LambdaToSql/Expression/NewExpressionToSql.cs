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

using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LambdaToSql
{
    /// <summary>
    /// 表示一个构造函数调用
    /// </summary>
	public class NewExpressionToSql : BaseLambdaToSql<NewExpression>
    {
        #region 基类方法重写
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public override SqlPack Update(NewExpression expression, SqlPack sqlPack)
        {
            for (int i = 0; i < expression.Members.Count; i++)
            {
                var m = expression.Members[i];
                var c = expression.Arguments[i] as ConstantExpression;
                sqlPack += m.Name + " =";
                sqlPack.AddDbParameter(c.Value);
                sqlPack += ",";
            }
            if (sqlPack[sqlPack.Length - 1] == ',')
            {
                sqlPack.Sql.Remove(sqlPack.Length - 1, 1);
            }
            return sqlPack;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public override SqlPack Insert(NewExpression expression, SqlPack sqlPack)
        {
            var fields = new List<string>();
            for (int i = 0; i < expression.Members?.Count; i++)
            {
                var m = expression.Members[i];
                var c = expression.Arguments[i] as ConstantExpression;
                sqlPack.AddDbParameter(c.Value);
                fields.Add(m.Name);
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
        /// Select
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public override SqlPack Select(NewExpression expression, SqlPack sqlPack)
        {
            for (var i = 0; i < expression.Members.Count; i++)
            {
                var argument = expression.Arguments[i];
                var member = expression.Members[i];
                LambdaToSqlProvider.Select(argument, sqlPack);
                //添加字段别名
                if ((argument as MemberExpression)?.Member.Name != member.Name)
                {
                    sqlPack.SelectFields[sqlPack.SelectFields.Count - 1] += " AS " + member.Name;
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
        public override SqlPack GroupBy(NewExpression expression, SqlPack sqlPack)
        {
            foreach (Expression item in expression.Arguments)
            {
                LambdaToSqlProvider.GroupBy(item, sqlPack);
            }
            sqlPack.Sql.Remove(sqlPack.Length - 1, 1);
            return sqlPack;
        }

        /// <summary>
        /// OrderBy
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
        public override SqlPack OrderBy(NewExpression expression, SqlPack sqlPack, params OrderType[] orders)
        {
            for (var i = 0; i < expression.Arguments.Count; i++)
            {
                LambdaToSqlProvider.OrderBy(expression.Arguments[i], sqlPack);
                if (i <= orders.Length - 1)
                {
                    sqlPack += $" { (orders[i] == OrderType.Desc ? "DESC" : "ASC")},";
                }
                else
                {
                    sqlPack += " ASC,";
                }
            }
            sqlPack.Sql.Remove(sqlPack.Length - 1, 1);
            return sqlPack;
        }
        #endregion
    }
}
