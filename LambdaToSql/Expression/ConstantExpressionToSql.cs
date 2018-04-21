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
    /// 表示具有常数值的表达式
    /// </summary>
	public class ConstantExpressionToSql : BaseLambdaToSql<ConstantExpression>
    {
        #region 基类方法重写
        /// <summary>
        /// Where
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public override SqlPack Where(ConstantExpression expression, SqlPack sqlPack)
        {
            sqlPack.AddDbParameter(expression.Value);
            return sqlPack;
        }

        /// <summary>
        /// In
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
		public override SqlPack In(ConstantExpression expression, SqlPack sqlPack)
        {
            if (expression.Type.Name == "String")
            {
                sqlPack.Sql.AppendFormat("'{0}',", expression.Value);
            }
            else
            {
                sqlPack.Sql.AppendFormat("{0},", expression.Value);
            }
            return sqlPack;
        }
        #endregion
    }
}