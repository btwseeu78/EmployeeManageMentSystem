using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeException
{
    public class EmpException:ApplicationException
    {
        public EmpException() : 
            base() { }
        public EmpException(string str) : base(str) { }
    }
}
