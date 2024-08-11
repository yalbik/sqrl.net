using Microsoft.SqlServer.Management.Smo;
using System.Collections.Generic;

namespace sqrl.net.domain.db_interface
{
    public interface ITable
    {
        string Name { get; }
        IEnumerable<IColumn> Columns { get; }
    }

    public interface IColumn
    {
        string Name { get; }
        string DataType { get; }
    }
}