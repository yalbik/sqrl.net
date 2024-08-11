using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqrl.net.domain.db_objects
{
    public class SqrlColumn : SqrlDbObject
    {
        public string DataType { get; set; }

        public SqrlColumn(string name, string dataType) : base(name)
        {
            DataType = dataType;
        }

        public override string ToString()
        {
            return $"{Name}:{DataType}";
        }

        public string ToSql()
        {
            return $"[{Name}] {DataType}";
        }
    }
}
