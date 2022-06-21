using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access_SQL_ADO.NET
{
    public class Payroll_Model
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public double SALARY { get; set; }
        public DateTime START_DATE { get; set; }
        public string GENDER { get; set; }
        public int PHONE { get; set; }
        public string ADDRESS { get; set; }
        public string DEPARTMENT { get; set; }
        public double BASIC_PAY { get; set; }
        public double DEDUCTIONS { get; set; }
        public double TAXABLE_PAY { get; set; }
        public double NET_PAY { get; set; }
    }
}
