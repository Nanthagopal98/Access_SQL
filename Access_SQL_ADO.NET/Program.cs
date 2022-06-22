using Access_SQL_ADO.NET;

Employee_Repo select = new Employee_Repo();
Payroll_Model model = new Payroll_Model();
Console.WriteLine("1 - Establish Connectivity");
Console.WriteLine("2 - Retrieve or Add Data to DataBase");
Console.WriteLine("3 - Retrieve or Add Data to DataBase");
Console.WriteLine("4 - Update Salary");
Console.WriteLine("5 - Delete Salary");
int option = Convert.ToInt32(Console.ReadLine());
switch(option)
{
    case 1:
        select.GetPayroll();
        break;
    case 2:
        select.GetAllEmployees();
        break;
    case 3:
        model.NAME = "Ansari";
        model.SALARY = 45000;
        model.START_DATE = DateTime.Now;
        model.GENDER = "M";
        model.PHONE = 987542310;
        model.ADDRESS = "13C";
        model.DEPARTMENT = "HR";
        model.BASIC_PAY = 45000;
        model.DEDUCTIONS = 200;
        model.TAXABLE_PAY = 300;
        model.NET_PAY = 44500;
        select.AddEmployee(model);
        break;
    case 4:
        select.UpdateValue();
        break;
    case 5:
        Console.WriteLine("Enter Name");
        string NAME = Console.ReadLine();
        select.DeleteEmployee(NAME);
        break;

}