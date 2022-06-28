using Access_SQL_ADO.NET;

Employee_Repo select = new Employee_Repo();
Payroll_Model model = new Payroll_Model(Name: null, Salary: 0, Start_Date: DateTime.Now, Gender: null, Phone: 0, Address: null,
                Department: null, Bassic_Pay: 0, Deduction: 0, Taxable_Pay: 0, Net_Pay: 0);
Console.WriteLine("1 - Establish Connectivity");
Console.WriteLine("2 - Retrieve Data From DataBase");
Console.WriteLine("3 - Add Data to DataBase");
Console.WriteLine("4 - Update Salary");
Console.WriteLine("5 - Delete Salary");
Console.WriteLine("6 - Add Employee Payroll Without Thread");
Console.WriteLine("7 - Add Employee Payroll Using Thread");
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
        select.GetAllEmployees();
        break;
    case 4:
        select.UpdateValue();
        break;
    case 5:
        Console.WriteLine("Enter Name");
        string NAME = Console.ReadLine();
        select.DeleteEmployee(NAME);
        break;
    case 6:
        //select.AddEmployeePayroll(model);
        break;
    case 7:
        //select.AddEmployeePayroll(model);
        break;
}