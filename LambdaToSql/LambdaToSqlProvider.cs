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
    /// LambdaToSqlProvider
    /// </summary>
	public class LambdaToSqlProvider
    {
        #region 私有静态方法
        /// <summary>
        /// GetLambdaToSql
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private static ILambdaToSql GetLambdaToSql(Expression expression)
        {
            #region 已实现表达式
            //null
            if (expression == null)
            {
                throw new ArgumentNullException("expression", "不能为null");
            }
            //表示具有常数值的表达式
            if (expression is ConstantExpression)
            {
                return new ConstantExpressionToSql();
            }
            //表示具有二进制运算符的表达式
            if (expression is BinaryExpression)
            {
                return new BinaryExpressionToSql();
            }
            //表示访问字段或属性
            if (expression is MemberExpression)
            {
                return new MemberExpressionToSql();
            }
            //表示对静态方法或实例方法的调用
            if (expression is MethodCallExpression)
            {
                return new MethodCallExpressionToSql();
            }
            //表示创建一个新数组，并可能初始化该新数组的元素
            if (expression is NewArrayExpression)
            {
                return new NewArrayExpressionToSql();
            }
            //表示一个构造函数调用
            if (expression is NewExpression)
            {
                return new NewExpressionToSql();
            }
            //表示具有一元运算符的表达式
            if (expression is UnaryExpression)
            {
                return new UnaryExpressionToSql();
            }
            //表示调用构造函数并初始化新对象的一个或多个成员
            if (expression is MemberInitExpression)
            {
                return new MemberInitExpressionToSql();
            }
            #endregion

            #region 未实现表达式
            if (expression is BlockExpression)
            {
                throw new NotImplementedException("未实现的BlockExpression2Sql");
            }
            if (expression is ConditionalExpression)
            {
                throw new NotImplementedException("未实现的ConditionalExpression2Sql");
            }
            if (expression is DebugInfoExpression)
            {
                throw new NotImplementedException("未实现的DebugInfoExpression2Sql");
            }
            if (expression is DefaultExpression)
            {
                throw new NotImplementedException("未实现的DefaultExpression2Sql");
            }
            if (expression is DynamicExpression)
            {
                throw new NotImplementedException("未实现的DynamicExpression2Sql");
            }
            if (expression is GotoExpression)
            {
                throw new NotImplementedException("未实现的GotoExpression2Sql");
            }
            if (expression is IndexExpression)
            {
                throw new NotImplementedException("未实现的IndexExpression2Sql");
            }
            if (expression is InvocationExpression)
            {
                throw new NotImplementedException("未实现的InvocationExpression2Sql");
            }
            if (expression is LabelExpression)
            {
                throw new NotImplementedException("未实现的LabelExpression2Sql");
            }
            if (expression is LambdaExpression)
            {
                throw new NotImplementedException("未实现的LambdaExpression2Sql");
            }
            if (expression is ListInitExpression)
            {
                throw new NotImplementedException("未实现的ListInitExpression2Sql");
            }
            if (expression is LoopExpression)
            {
                throw new NotImplementedException("未实现的LoopExpression2Sql");
            }

            if (expression is ParameterExpression)
            {
                throw new NotImplementedException("未实现的ParameterExpression2Sql");
            }
            if (expression is RuntimeVariablesExpression)
            {
                throw new NotImplementedException("未实现的RuntimeVariablesExpression2Sql");
            }
            if (expression is SwitchExpression)
            {
                throw new NotImplementedException("未实现的SwitchExpression2Sql");
            }
            if (expression is TryExpression)
            {
                throw new NotImplementedException("未实现的TryExpression2Sql");
            }
            if (expression is TypeBinaryExpression)
            {
                throw new NotImplementedException("未实现的TypeBinaryExpression2Sql");
            }
            throw new NotImplementedException("未实现的Expression2Sql");
            #endregion
        }
        #endregion

        #region 公有静态方法
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        public static void Update(Expression expression, SqlPack sqlPack)
        {
            GetLambdaToSql(expression).Update(expression, sqlPack);
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        public static void Insert(Expression expression, SqlPack sqlPack)
        {
            GetLambdaToSql(expression).Insert(expression, sqlPack);
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        public static void Select(Expression expression, SqlPack sqlPack)
        {
            GetLambdaToSql(expression).Select(expression, sqlPack);
        }

        /// <summary>
        /// Join
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        public static void Join(Expression expression, SqlPack sqlPack)
        {
            GetLambdaToSql(expression).Join(expression, sqlPack);
        }

        /// <summary>
        /// Where
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        public static void Where(Expression expression, SqlPack sqlPack)
        {
            GetLambdaToSql(expression).Where(expression, sqlPack);
        }

        /// <summary>
        /// In
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        public static void In(Expression expression, SqlPack sqlPack)
        {
            GetLambdaToSql(expression).In(expression, sqlPack);
        }

        /// <summary>
        /// GroupBy
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        public static void GroupBy(Expression expression, SqlPack sqlPack)
        {
            GetLambdaToSql(expression).GroupBy(expression, sqlPack);
        }

        /// <summary>
        /// OrderBy
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <param name="orders"></param>
        public static void OrderBy(Expression expression, SqlPack sqlPack, params OrderType[] orders)
        {
            GetLambdaToSql(expression).OrderBy(expression, sqlPack, orders);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        public static void Max(Expression expression, SqlPack sqlPack)
        {
            GetLambdaToSql(expression).Max(expression, sqlPack);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        public static void Min(Expression expression, SqlPack sqlPack)
        {
            GetLambdaToSql(expression).Min(expression, sqlPack);
        }

        /// <summary>
        /// Avg
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        public static void Avg(Expression expression, SqlPack sqlPack)
        {
            GetLambdaToSql(expression).Avg(expression, sqlPack);
        }

        /// <summary>
        /// Count
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        public static void Count(Expression expression, SqlPack sqlPack)
        {
            GetLambdaToSql(expression).Count(expression, sqlPack);
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        public static void Sum(Expression expression, SqlPack sqlPack)
        {
            GetLambdaToSql(expression).Sum(expression, sqlPack);
        }
        #endregion
    }
}
