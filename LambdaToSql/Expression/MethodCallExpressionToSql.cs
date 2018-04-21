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

namespace LambdaToSql
{
    /// <summary>
    /// 表示对静态方法或实例方法的调用
    /// </summary>
	public class MethodCallExpressionToSql : BaseLambdaToSql<MethodCallExpression>
    {
        #region 私有静态方法
        /// <summary>
        /// _Methods
        /// </summary>
        private static Dictionary<string, Action<MethodCallExpression, SqlPack>> _Methods = new Dictionary<string, Action<MethodCallExpression, SqlPack>>
        {
            ["Like"] = Like,
            ["LikeLeft"] = LikeLeft,
            ["LikeRight"] = LikeRight,
            ["NotLike"] = NotLike,
            ["In"] = In,
            ["NotIn"] = NotIn
        };

        /// <summary>
        /// In
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        private static new void In(MethodCallExpression expression, SqlPack sqlPack)
        {
            LambdaToSqlProvider.Where(expression.Arguments[0], sqlPack);
            sqlPack += " IN ";
            LambdaToSqlProvider.In(expression.Arguments[1], sqlPack);
        }

        /// <summary>
        /// Not In
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        private static void NotIn(MethodCallExpression expression, SqlPack sqlPack)
        {
            LambdaToSqlProvider.Where(expression.Arguments[0], sqlPack);
            sqlPack += " NOT IN ";
            LambdaToSqlProvider.In(expression.Arguments[1], sqlPack);
        }

        /// <summary>
        /// Like
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        private static void Like(MethodCallExpression expression, SqlPack sqlPack)
        {
            if (expression.Object != null)
            {
                LambdaToSqlProvider.Where(expression.Object, sqlPack);
            }
            LambdaToSqlProvider.Where(expression.Arguments[0], sqlPack);
            sqlPack += " LIKE '%' + ";
            LambdaToSqlProvider.Where(expression.Arguments[1], sqlPack);
            sqlPack += " + '%'";
        }

        /// <summary>
        /// LikeLeft
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        private static void LikeLeft(MethodCallExpression expression, SqlPack sqlPack)
        {
            if (expression.Object != null)
            {
                LambdaToSqlProvider.Where(expression.Object, sqlPack);
            }
            LambdaToSqlProvider.Where(expression.Arguments[0], sqlPack);
            sqlPack += " LIKE '%' + ";
            LambdaToSqlProvider.Where(expression.Arguments[1], sqlPack);
        }

        /// <summary>
        /// LikeRight
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        private static void LikeRight(MethodCallExpression expression, SqlPack sqlPack)
        {
            if (expression.Object != null)
            {
                LambdaToSqlProvider.Where(expression.Object, sqlPack);
            }
            LambdaToSqlProvider.Where(expression.Arguments[0], sqlPack);
            sqlPack += " LIKE ";
            LambdaToSqlProvider.Where(expression.Arguments[1], sqlPack);
            sqlPack += " + '%'";
        }

        /// <summary>
        /// NotLike
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        private static void NotLike(MethodCallExpression expression, SqlPack sqlPack)
        {
            if (expression.Object != null)
            {
                LambdaToSqlProvider.Where(expression.Object, sqlPack);
            }
            LambdaToSqlProvider.Where(expression.Arguments[0], sqlPack);
            sqlPack += " NOT LIKE ";
            LambdaToSqlProvider.Where(expression.Arguments[1], sqlPack);
        }
        #endregion

        #region 基类方法重写
        /// <summary>
        /// Where
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public override SqlPack Where(MethodCallExpression expression, SqlPack sqlPack)
        {
            var key = expression.Method;
            if (key.IsGenericMethod)
            {
                key = key.GetGenericMethodDefinition();
            }
            if (_Methods.TryGetValue(key.Name, out Action<MethodCallExpression, SqlPack> action))
            {
                action(expression, sqlPack);
                return sqlPack;
            }
            throw new NotImplementedException("无法解析方法" + expression.Method);
        }
        #endregion
    }
}