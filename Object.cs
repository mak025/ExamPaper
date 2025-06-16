using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPaper
{
    public class Object
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public string description { get; set; }

        public Object(int id, string name, string description)
        {
            ID = id;
            Name = name;
            this.description = description;
        }
    }
}
