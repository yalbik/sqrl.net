using System;
using System.Collections.Generic;
using sqrl.net.domain.db_objects;

namespace sqrl.net.domain.db_interface
{
    public class SqlServerRepository
    {
        private IServer _server;
        private IDatabase _database;

        public SqlServerRepository(IServer server, IDatabase database)
        {
            _server = server;
            _database = database;
        }

        public List<SqrlTable> GetTables()
        {
            List<SqrlTable> tables = new List<SqrlTable>();
            foreach (ITable table in _database.Tables)
            {
                SqrlTable sqrlTable = new SqrlTable(table.Name);
                sqrlTable.Name = table.Name;
                sqrlTable.Columns = new List<SqrlColumn>();
                foreach (IColumn column in table.Columns)
                {
                    SqrlColumn sqrlColumn = new SqrlColumn(column.Name, column.DataType);
                    sqrlTable.Columns.Add(sqrlColumn);
                }
                tables.Add(sqrlTable);
            }
            return tables;
        }
    }
}