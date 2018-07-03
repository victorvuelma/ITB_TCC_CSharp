﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace SQL_POWERUP
{
    public class sqlInsert : sqlCommand
    {

        private sqlHelperValue _insert;
        private bool _output = false;

        public sqlInsert table(String table)
        {
            Table = table;
            return this;
        }

        public sqlHelperValue Insert
        {
            get
            {
                if (_insert == null)
                    return _insert = new sqlHelperValue();
                return _insert;
            }
        }

        protected override String generateCommand()
        {
            StringBuilder commandBuilder = new StringBuilder();
            commandBuilder.Append("INSERT INTO ").Append(Table);
            if (_insert != null)
                _insert.generateInsert(commandBuilder, _output);

            return commandBuilder.ToString();
        }

        private int insert(sqlDatabase db, bool output)
        {
            _output = output;

            SqlCommand cmd = db.getCommand(generateCommand());
            if (_insert != null)
                _insert.prepare(cmd);

            if (output)
            {
                return Convert.ToInt32(db.executeScalar(cmd));
            }
            else
            {
                return db.execute(cmd);
            }
        }

        public int executeWithOutput(sqlDatabase db) => insert(db, true);

        public int execute(sqlDatabase db) => insert(db, false);

    }
}