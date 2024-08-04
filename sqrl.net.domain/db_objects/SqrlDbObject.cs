using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace sqrl.net.domain.db_objects
{
    public abstract class SqrlDbObject
    {
        public string Name { get; set; }
        
        protected SqrlDbObject(string name)
        {
            this.Name = name;
        }
        
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
