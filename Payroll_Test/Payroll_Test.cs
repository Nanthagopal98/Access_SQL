using Access_SQL_ADO.NET;

namespace Payroll_Test
{
    [TestClass]
    public class Payroll_Test
    {
        Employee_Repo employee_repo = new Employee_Repo();
        [TestMethod]
        public void GivenEmployee_WhenAddedtoList_ShouldMatchWithEntity()
        {
            List<Payroll_Model> model = new List<Payroll_Model>();
            model.Add(new Payroll_Model("SUBASH", 50000, DateTime.Now, "M", 886622445, "SUBASH ADDRESS", "DEVELOPER", 50000, 1000, 1000, 48000));
            model.Add(new Payroll_Model("ARAVIND", 60000, DateTime.Now, "M", 775869523, "ARAVIND ADDRESS", "DESIGN", 60000, 1000, 1000, 58000));
            model.Add(new Payroll_Model("HARI", 45000, DateTime.Now, "M", 956324895, "HARI ADDRESS", "MAINTENANCE", 45000, 1000, 1000, 43000));
            model.Add(new Payroll_Model("GOWTHAM", 55000, DateTime.Now, "M", 689547125, "GOWTHAM ADDRESS", "DEVELOPER", 55000, 1000, 1000, 53000));
            model.Add(new Payroll_Model("PRABHU", 51000, DateTime.Now, "M", 758120358, "PRABHU ADDRESS", "MAINTENANCE", 51000, 1000, 1000, 49000));
            DateTime startTime = DateTime.Now;
            employee_repo.AddEmployeePayroll(model);
            DateTime endTime = DateTime.Now;
            Console.WriteLine("Elapsed Time Without Thread : " + (endTime - startTime));

            DateTime threadstartTime = DateTime.Now;
            employee_repo.AddEmployeePayrollWithThread(model);
            DateTime threadEndTime = DateTime.Now;
            Console.WriteLine("Elapsed Time Using Thread : " + (threadEndTime - threadstartTime));
        }
    }
}