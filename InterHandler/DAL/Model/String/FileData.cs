using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    abstract public class FileData
    {
        public abstract string[] Verify();
    
        public string ParseToLine()
        {
            string line = string.Empty;

            var type = this.GetType();  
            var properties = type.GetProperties();


            foreach (PropertyInfo property in properties)
            {
                line += "|";
                line += property.GetValue(this, null) != null ? property.GetValue(this, null).ToString() : String.Empty;
            }


            return line.Substring(1);
        }
        public void ReadFromLine(string line)
        {
            var type = this.GetType(); 
            var properties = type.GetProperties();

            var props = line.Split('|');

            int i = 0;

            foreach (PropertyInfo property in properties)
            {
                if (props.Length <= i) break;
                property.SetValue(this, props[i], null);
                i++;
            }
        }
    }
}
