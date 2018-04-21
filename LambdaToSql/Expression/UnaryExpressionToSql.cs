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

using System.Linq.Expressions;

namespace LambdaToSql
{
    /// <summary>
    /// 表示具有一元运算符的表达式
    /// </summary>
	public class UnaryExpressionToSql : BaseLambdaToSql<UnaryExpression>
    {
        #region 基类方法重写
        /// <summary>
        /// Select
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public override SqlPack Select(UnaryExpression expression, SqlPack sqlPack)
        {
            LambdaToSqlProvider.Select(expression.Operand, sqlPack);
            return sqlPack;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public override SqlPack Insert(UnaryExpression expression, SqlPack sqlPack)
        {
            LambdaToSqlProvider.Insert(expression.Operand, sqlPack);
            return sqlPack;
        }

        /// <summary>
        /// Where
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public override SqlPack Where(UnaryExpression expression, SqlPack sqlPack)
        {
            LambdaToSqlProvider.Where(expression.Operand, sqlPack);
            return sqlPack;
        }

        /// <summary>
        /// GroupBy
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public override SqlPack GroupBy(UnaryExpression expression, SqlPack sqlPack)
        {
            LambdaToSqlProvider.GroupBy(expression.Operand, sqlPack);
            return sqlPack;
        }

        /// <summary>
        /// OrderBy
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
        public override SqlPack OrderBy(UnaryExpression expression, SqlPack sqlPack, params OrderType[] orders)
        {
            LambdaToSqlProvider.OrderBy(expression.Operand, sqlPack, orders);
            return sqlPack;
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public override SqlPack Max(UnaryExpression expression, SqlPack sqlPack)
        {
            LambdaToSqlProvider.Max(expression.Operand, sqlPack);
            return sqlPack;
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public override SqlPack Min(UnaryExpression expression, SqlPack sqlPack)
        {
            LambdaToSqlProvider.Min(expression.Operand, sqlPack);
            return sqlPack;
        }

        /// <summary>
        /// Avg
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public override SqlPack Avg(UnaryExpression expression, SqlPack sqlPack)
        {
            LambdaToSqlProvider.Avg(expression.Operand, sqlPack);
            return sqlPack;
        }

        /// <summary>
        /// Count
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public override SqlPack Count(UnaryExpression expression, SqlPack sqlPack)
        {
            LambdaToSqlProvider.Count(expression.Operand, sqlPack);
            return sqlPack;
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public override SqlPack Sum(UnaryExpression expression, SqlPack sqlPack)
        {
            LambdaToSqlProvider.Sum(expression.Operand, sqlPack);
            return sqlPack;
        }

        /// <summary>
        /// Join
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public override SqlPack Join(UnaryExpression expression, SqlPack sqlPack)
        {
            LambdaToSqlProvider.Join(expression.Operand, sqlPack);
            return sqlPack;
        }
        #endregion
    }
}
