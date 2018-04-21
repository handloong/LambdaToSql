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
using System.Linq;
using System.Text;

namespace LambdaToSql
{
    /// <summary>
    /// SqlPack
    /// </summary>
	public class SqlPack
    {
        /// <summary>
        /// S_listEnglishWords
        /// </summary>
        private static readonly List<string> S_listEnglishWords = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", };

        /// <summary>
        /// _dicTableName
        /// </summary>
        private Dictionary<string, string> _dicTableName = new Dictionary<string, string>();

        /// <summary>
        /// _queueEnglishWords
        /// </summary>
        private Queue<string> _queueEnglishWords = new Queue<string>(S_listEnglishWords);

        /// <summary>
        /// IsSingleTable
        /// </summary>
        public bool IsSingleTable { get; set; }

        /// <summary>
        /// SelectFields
        /// </summary>
        public List<string> SelectFields { get; set; }

        /// <summary>
        /// SelectFieldsStr
        /// </summary>
        public string SelectFieldsStr
        {
            get
            {
                return string.Join(",", this.SelectFields);
            }
        }

        /// <summary>
        /// Length
        /// </summary>
        public int Length
        {
            get
            {
                return this.Sql.Length;
            }
        }

        /// <summary>
        /// Sql
        /// </summary>
        public StringBuilder Sql { get; set; }

        /// <summary>
        /// DatabaseType
        /// </summary>
        public DatabaseType DatabaseType { get; set; }

        /// <summary>
        /// DbParams
        /// </summary>
        public Dictionary<string, object> DbParams { get; set; }

        /// <summary>
        /// DbParamPrefix
        /// </summary>
        private string DbParamPrefix
        {
            get
            {
                switch (this.DatabaseType)
                {
                    case DatabaseType.SQLite: return "@";
                    case DatabaseType.SQLServer: return "@";
                    case DatabaseType.MySQL: return "@";
                    case DatabaseType.Oracle: return "@";
                    default: return "";
                }
            }
        }

        /// <summary>
        /// this
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public char this[int index]
        {
            get
            {
                return this.Sql[index];
            }
        }

        /// <summary>
        /// SqlPack
        /// </summary>
        public SqlPack()
        {
            this.DbParams = new Dictionary<string, object>();
            this.Sql = new StringBuilder();
            this.SelectFields = new List<string>();
        }

        /// <summary>
        /// +
        /// </summary>
        /// <param name="sqlPack"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlPack operator +(SqlPack sqlPack, string sql)
        {
            sqlPack.Sql.Append(sql);
            return sqlPack;
        }

        /// <summary>
        /// Clear
        /// </summary>
        public void Clear()
        {
            this.SelectFields.Clear();
            this.Sql.Clear();
            this.DbParams.Clear();
            this._dicTableName.Clear();
            this._queueEnglishWords = new Queue<string>(S_listEnglishWords);
        }

        /// <summary>
        /// AddDbParameter
        /// </summary>
        /// <param name="parameterValue"></param>
        public void AddDbParameter(object parameterValue)
        {
            if (parameterValue == null || parameterValue == DBNull.Value)
            {
                this.Sql.Append(" NULL");
            }
            else
            {
                string name = this.DbParamPrefix + "param" + this.DbParams.Count;
                this.DbParams.Add(name, parameterValue);
                this.Sql.Append(name);
            }
        }

        /// <summary>
        /// SetTableAlias
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool SetTableAlias(string tableName)
        {
            if (!this._dicTableName.Keys.Contains(tableName))
            {
                this._dicTableName.Add(tableName, this._queueEnglishWords.Dequeue());
                return true;
            }
            return false;
        }

        /// <summary>
        /// GetTableAlias
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public string GetTableAlias(string tableName)
        {
            if (!this.IsSingleTable && this._dicTableName.Keys.Contains(tableName))
            {
                return this._dicTableName[tableName];
            }
            return "";
        }

        /// <summary>
        /// GetTableName
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public string GetTableName(Type type)
        {
            var tableName = type.Name;
            if (type.GetCustomAttributes(typeof(TableAttribute), false).FirstOrDefault() is TableAttribute tableAttribute)
            {
                tableName = tableAttribute.Table;
            }
            return tableName;
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Sql.ToString();
        }
    }
}