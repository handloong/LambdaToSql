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
    /// 表示调用构造函数并初始化新对象的一个或多个成员
    /// </summary>
    public class MemberInitExpressionToSql : BaseLambdaToSql<MemberInitExpression>
    {
        #region 基类方法重写
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public override SqlPack Insert(MemberInitExpression expression, SqlPack sqlPack)
        {
            var fields = new List<string>();
            foreach (MemberAssignment m in expression.Bindings)
            {
                sqlPack.AddDbParameter((m.Expression as ConstantExpression)?.Value);
                fields.Add(m.Member.Name);
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
        public override SqlPack Update(MemberInitExpression expression, SqlPack sqlPack)
        {
            foreach (MemberAssignment m in expression.Bindings)
            {
                sqlPack += m.Member.Name + " =";
                sqlPack.AddDbParameter((m.Expression as ConstantExpression)?.Value);
                sqlPack += ",";
            }
            if (sqlPack[sqlPack.Length - 1] == ',')
            {
                sqlPack.Sql.Remove(sqlPack.Length - 1, 1);
            }
            return sqlPack;
        }
        #endregion
    }
}
