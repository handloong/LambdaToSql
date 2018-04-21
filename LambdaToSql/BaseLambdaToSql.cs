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
    /// 抽象基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
	public abstract class BaseLambdaToSql<T> : ILambdaToSql where T : Expression
    {
        #region 抽象类型虚方法,须要被继承类override才能调用
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public virtual SqlPack Update(T expression, SqlPack sqlPack)
        {
            throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Update方法");
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public virtual SqlPack Insert(T expression, SqlPack sqlPack)
        {
            throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Insert方法");
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public virtual SqlPack Select(T expression, SqlPack sqlPack)
        {
            throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Select方法");
        }

        /// <summary>
        /// Join
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public virtual SqlPack Join(T expression, SqlPack sqlPack)
        {
            throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Join方法");
        }

        /// <summary>
        /// Where
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public virtual SqlPack Where(T expression, SqlPack sqlPack)
        {
            throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Where方法");
        }

        /// <summary>
        /// In
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public virtual SqlPack In(T expression, SqlPack sqlPack)
        {
            throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.In方法");
        }

        /// <summary>
        /// GroupBy
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public virtual SqlPack GroupBy(T expression, SqlPack sqlPack)
        {
            throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.GroupBy方法");
        }

        /// <summary>
        /// OrderBy
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
        public virtual SqlPack OrderBy(T expression, SqlPack sqlPack, params OrderType[] orders)
        {
            throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.OrderBy方法");
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public virtual SqlPack Max(T expression, SqlPack sqlPack)
        {
            throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Max方法");
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public virtual SqlPack Min(T expression, SqlPack sqlPack)
        {
            throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Min方法");
        }

        /// <summary>
        /// Avg
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public virtual SqlPack Avg(T expression, SqlPack sqlPack)
        {
            throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Avg方法");
        }

        /// <summary>
        /// Count
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public virtual SqlPack Count(T expression, SqlPack sqlPack)
        {
            throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Count方法");
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public virtual SqlPack Sum(T expression, SqlPack sqlPack)
        {
            throw new NotImplementedException("未实现" + typeof(T).Name + "2Sql.Sum方法");
        }
        #endregion

        #region 实现ILambdaToSql接口
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public SqlPack Update(Expression expression, SqlPack sqlPack)
        {
            return Update((T)expression, sqlPack);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public SqlPack Insert(Expression expression, SqlPack sqlPack)
        {
            return Insert((T)expression, sqlPack);
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public SqlPack Select(Expression expression, SqlPack sqlPack)
        {
            return Select((T)expression, sqlPack);
        }

        /// <summary>
        /// Join
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public SqlPack Join(Expression expression, SqlPack sqlPack)
        {
            return Join((T)expression, sqlPack);
        }

        /// <summary>
        /// Where
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public SqlPack Where(Expression expression, SqlPack sqlPack)
        {
            return Where((T)expression, sqlPack);
        }

        /// <summary>
        /// In
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public SqlPack In(Expression expression, SqlPack sqlPack)
        {
            return In((T)expression, sqlPack);
        }

        /// <summary>
        /// GroupBy
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public SqlPack GroupBy(Expression expression, SqlPack sqlPack)
        {
            return GroupBy((T)expression, sqlPack);
        }

        /// <summary>
        /// OrderBy
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
        public SqlPack OrderBy(Expression expression, SqlPack sqlPack, params OrderType[] orders)
        {
            return OrderBy((T)expression, sqlPack, orders);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public SqlPack Max(Expression expression, SqlPack sqlPack)
        {
            return Max((T)expression, sqlPack);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public SqlPack Min(Expression expression, SqlPack sqlPack)
        {
            return Min((T)expression, sqlPack);
        }

        /// <summary>
        /// Avg
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public SqlPack Avg(Expression expression, SqlPack sqlPack)
        {
            return Avg((T)expression, sqlPack);
        }

        /// <summary>
        /// Count
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public SqlPack Count(Expression expression, SqlPack sqlPack)
        {
            return Count((T)expression, sqlPack);
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="sqlPack"></param>
        /// <returns></returns>
        public SqlPack Sum(Expression expression, SqlPack sqlPack)
        {
            return Sum((T)expression, sqlPack);
        }
        #endregion
    }
}
