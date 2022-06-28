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

        public Payroll_Model(string Name, double Salary, DateTime Start_Date, string Gender, int Phone, string Address,
                string Department, double Bassic_Pay, double Deduction, double Taxable_Pay, double Net_Pay)
        {
            this.NAME = Name;
            this.SALARY = Salary;
            this.START_DATE = Start_Date;
            this.GENDER = Gender;
            this.PHONE = Phone;
            this.ADDRESS = Address;
            this.DEPARTMENT = Department;
            this.BASIC_PAY = Bassic_Pay;
            this.DEDUCTIONS = Deduction;
            this.TAXABLE_PAY = Taxable_Pay;
            this.NET_PAY = Net_Pay;
        }
    }
}
