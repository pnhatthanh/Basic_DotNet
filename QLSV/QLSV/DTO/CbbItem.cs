using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.DTO
{
    public class CbbItem
    {
        public int value {  get; set; } 
        public string name { get; set; }
        public override string ToString()
        {
            return name;
        }
    }
}
