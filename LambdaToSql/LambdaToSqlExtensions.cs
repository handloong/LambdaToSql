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

namespace LambdaToSql
{
    /// <summary>
    /// 对象扩展类
    /// </summary>
	public static class LambdaToSqlExtensions
    {
        #region 对象扩展方法
        /// <summary>
        /// LIKE
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Like(this object obj, string value) => true;

        /// <summary>
        /// LIKE '% _ _ _'
        /// </summary>
        public static bool LikeLeft(this object obj, string value) => true;

        /// <summary>
        /// LIKE '_ _ _ %'
        /// </summary>
        public static bool LikeRight(this object obj, string value) => true;

        /// <summary>
        /// NOT LIKE
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool NotLike(this object obj, string value) => true;

        /// <summary>
        /// IN
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="ary"></param>
        /// <returns></returns>
        public static bool In<T>(this object obj, params T[] array) => true;

        /// <summary>
        /// NOT IN
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static bool NotIn<T>(this object obj, params T[] array) => true;
        #endregion
    }
}
