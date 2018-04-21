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
    /// 表示具有二进制运算符的表达式
    /// </summary>
	public class BinaryExpressionToSql : BaseLambdaToSql<BinaryExpression>
    {
        #region 私有方法
        /// <summary>
        /// OperatorParser
        /// </summary>
        /// <param name="expressionNodeType"></param>
        /// <param name="operatorIndex"></param>
        /// <param name="sqlPack"></param>
        /// <param name="useIs"></param>
        private void OperatorParser(ExpressionType expressionNodeType, int operatorIndex, SqlPack sqlPack, bool useIs = false)
        {
            switch (expressionNodeType)
            {
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                    sqlPack.Sql.Insert(operatorIndex, "\nAND");
                    break;
                case ExpressionType.Equal:
                    if (useIs)
                    {
                        sqlPack.Sql.Insert(operatorIndex, " IS ");
                    }
                    else
                    {
                        sqlPack.Sql.Insert(operatorIndex, " = ");
                    }
                    break;
                case ExpressionType.GreaterThan:
                    sqlPack.Sql.Insert(operatorIndex, " > ");
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    sqlPack.Sql.Insert(operatorIndex, " >= ");
                    break;
                case ExpressionType.NotEqual:
                    if (useIs)
                    {
                        sqlPack.Sql.Insert(operatorIndex, " IS NOT ");
                    }
                    else
                    {
                        sqlPack.Sql.Insert(operatorIndex, " <> ");
                    }
                    break;
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                    sqlPack.Sql.Insert(operatorIndex, "\nOR ");
                    break;
                case ExpressionType.LessThan:
                    sqlPack.Sql.Insert(operatorIndex, " < ");
                    break;
                case ExpressionType.LessThanOrEqual:
                    sqlPack.Sql.Insert(operatorIndex, " <= ");
                    break;
                case ExpressionType.Add:
                    sqlPack.Sql.Insert(operatorIndex, " + ");
                    break;
                case ExpressionType.Subtract:
                    sqlPack.Sql.Insert(operatorIndex, " - ");
                    break;
                case ExpressionType.Multiply:
                    sqlPack.Sql.Insert(operatorIndex, " * ");
                    break;
                case ExpressionType.Divide:
                    sqlPack.Sql.Insert(operatorIndex, " / ");
                    break;
                case ExpressionType.Modulo:
                    sqlPack.Sql.Insert(operatorIndex, " % ");
                    break;
                default:
                    throw new NotImplementedException("未实现的节点类型" + expressionNodeType);
            }
        }
        #endregion

        #region 基类方法重写
        /// <summary>
        /// Join
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public override SqlPack Join(BinaryExpression expression, SqlPack sqlPack)
        {
            LambdaToSqlProvider.Join(expression.Left, sqlPack);
            var operatorIndex = sqlPack.Sql.Length;
            //嵌套条件
            var flag = false;            
            if (expression.Right is BinaryExpression binaryExpression && (binaryExpression.Right as BinaryExpression) != null)
            {
                flag = true;
                sqlPack += "(";
            }
            LambdaToSqlProvider.Where(expression.Right, sqlPack);
            if (flag)
            {
                sqlPack += ")";
            }
            var sqlLength = sqlPack.Sql.Length;
            if (sqlLength - operatorIndex == 5 && sqlPack.ToString().ToUpper().EndsWith("NULL"))
            {
                OperatorParser(expression.NodeType, operatorIndex, sqlPack, true);
            }
            else
            {
                OperatorParser(expression.NodeType, operatorIndex, sqlPack);
            }
            return sqlPack;
        }

        /// <summary>
        /// Where
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
		public override SqlPack Where(BinaryExpression expression, SqlPack sqlPack)
        {
            LambdaToSqlProvider.Where(expression.Left, sqlPack);
            var signIndex = sqlPack.Length;
            //嵌套条件
            var flag = false;           
            if (expression.Right is BinaryExpression binaryExpression && (binaryExpression.Right as BinaryExpression) != null)
            {
                flag = true;
                sqlPack += "(";
            }
            LambdaToSqlProvider.Where(expression.Right, sqlPack);
            if (flag)
            {
                sqlPack += ")";
            }
            var sqlLength = sqlPack.Length;
            if (sqlLength - signIndex == 5 && sqlPack.ToString().ToUpper().EndsWith("NULL"))
            {
                OperatorParser(expression.NodeType, signIndex, sqlPack, true);
            }
            else
            {
                OperatorParser(expression.NodeType, signIndex, sqlPack);
            }
            return sqlPack;
        }
        #endregion
    }
}