﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace SQL_POWERUP
{
    public class sqlHelperValue
    {

        private Dictionary<String, object> _values = new Dictionary<string, object>();

        public Dictionary<string, object> Values { get => _values; set => _values = value; }

        public sqlHelperValue val(String column, object val)
        {
            column = column.ToUpper();
            if (Values.ContainsKey(column))
            {
                Values.Remove(column);
            }
            Values.Add(column, val);
            return this;
        }

        public sqlHelperValue val(KeyValuePair<String, object> columnValue)
        {
            return val(columnValue.Key, columnValue.Value);
        }

        internal void generateInsert(StringBuilder builder, bool outputId)
        {
            if (Values.Count > 0)
            {
                StringBuilder valuesBuilder = new StringBuilder();

                int paramIndex = 1;
                foreach (KeyValuePair<String, object> columnValue in Values)
                {
                    if (valuesBuilder.Length > 0)
                    {
                        valuesBuilder.Append(", ");
                    }
                    if (columnValue.Value != null)
                    {
                        valuesBuilder.Append("@val_").Append(paramIndex);
                        paramIndex++;
                    }
                    else
                    {
                        valuesBuilder.Append("null");
                    }
                }
                builder.Append(" (");
                sqlUtil.separeWithComma(builder, Values.Keys.ToList());
                builder.Append(')');
                if (outputId)
                    builder.Append(" OUTPUT INSERTED.ID");
                builder.Append(" VALUES (").Append(valuesBuilder).Append(')');
            }
        }

        internal void generateSet(StringBuilder builder)
        {
            if (Values.Count > 0)
            {
                StringBuilder setBuilder = new StringBuilder();
                int paramIndex = 1;
                foreach (KeyValuePair<string, object> columnValue in Values)
                {
                    if (setBuilder.Length > 0)
                    {
                        setBuilder.Append(", ");
                    }
                    setBuilder.Append(columnValue.Key).Append(" = ");
                    if (columnValue.Value != null)
                    {
                        setBuilder.Append("@val_").Append(paramIndex);
                        paramIndex++;
                    }
                    else
                    {
                        setBuilder.Append("null");
                    }
                }

                builder.Append(" SET ").Append(setBuilder);
            }
        }

        internal void prepare(SqlCommand cmd)
        {
            int paramIndex = 1;
            foreach (KeyValuePair<String, object> columnValue in Values)
            {
                if (columnValue.Value != null)
                {
                    cmd.Parameters.AddWithValue("@val_" + paramIndex, columnValue.Value);
                    paramIndex++; 
                }
            }
        }

    }
}
