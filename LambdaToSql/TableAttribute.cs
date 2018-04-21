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

namespace LambdaToSql
{
    /// <summary>
    /// 指定表名
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false)]
    public class TableAttribute : Attribute
    {
        /// <summary>
        /// SQLinqTableAttribute constructor
        /// </summary>
        /// <param name="tableName">The database table/view name to use for this object with SQLinq queries.</param>
        public TableAttribute(string tableName)
        {
            this.Table = tableName;
        }

        /// <summary>
        /// The database table/view name to use for this object with SQLinq queries.
        /// </summary>
        public string Table { get; private set; }
    }
}
