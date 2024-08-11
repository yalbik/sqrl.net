using System.Collections.Generic;
using System.Text;

namespace sqrl.net.domain.db_objects
{
    public class SqrlTable : SqrlDbObject
    {
        public List<SqrlColumn> Columns { get; set; }

        public SqrlTable(string name) : base(name)
        {
            Columns = new List<SqrlColumn>();
        }

        public void AddColumn(SqrlColumn column)
        {
            Columns.Add(column);
        }

        public string ToSql()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CREATE TABLE [{Name}] (");

            for (int i = 0; i < Columns.Count; i++)
            {
                sb.Append($"    {Columns[i].ToSql()}");
                if (i < Columns.Count - 1)
                {
                    sb.Append(",");
                }
                sb.AppendLine();
            }

            sb.AppendLine(");");
            return sb.ToString().TrimEnd();
        }
    }
}