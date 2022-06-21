using Access_SQL_ADO.NET;

Employee_Repo select = new Employee_Repo();
Payroll_Model model = new Payroll_Model();
Console.WriteLine("1 - Establish Connectivity");
int option = Convert.ToInt32(Console.ReadLine());
switch(option)
{
    case 1:
        select.GetPayroll();
        break;
    
}