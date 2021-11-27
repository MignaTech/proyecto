******************************************************
Func<Employee, bool> predicate = emp =>
{
	return emp.LastName.Contains("sm");
};
var employees = context.Employees.Where (predicate);
foreach(var e in employees){
	Console.WriteLine(e.FirstName);
}
Console.ReadKey();
------------------------------------------------------
var employees = context.Employees.Where(
	emp => emp.LastName.Contains("sm"));
foreach(var e in employees){
	Console.WriteLine(e.FirstName);
}
Console.ReadKey();
******************************************************
++++++++++++++++++++++++++++++++++++++++++++++++++++++
******************************************************
//SELECT * FROM employees WHERE last_name LIKE '%sm%';
Func<Employee, string> selector = emp =>
{
	return $"{emp.FirstName} {emp.LastName}";
};
var employees = context.Employees.Where(
	emp => emp.LastName.Contains("sm").Select(selector));
foreach(var e in employees){
	Console.WriteLine(e);
}
Console.ReadKey();
------------------------------------------------------
var employees = context.Employees.Where(
	emp => emp.LastName.Contains("sm")
	.Select(emp => 
		$"{emp.FirstName} {emp.LastName}"));
foreach(var e in employees){
	Console.WriteLine(e);
}
Console.ReadKey();
------------------------------------------------------
var employees = from employee
				in context.Employees
				where employee.LastName.Contains("sm")
				select new
				{
					key = employee.EmpNo,
					FullName = $"{emp.FirstName} {emp.LastName}"
				};
foreach(var e in employees){
	Console.WriteLine(e);
}
Console.ReadKey();
******************************************************
++++++++++++++++++++++++++++++++++++++++++++++++++++++
******************************************************
var employee = context.Employees.Where(
	emp => emp.EmpNo==499615).FirstOrDefault();
Console.WriteLine($"{employee.EmpNo} {employee.FirstName}");
Console.ReadKey();
------------------------------------------------------
var employee = (from e in context.Employees
	where e.EmpNo == 999 select e).FirstOrDefault();
******************************************************
++++++++++++++++++++++++++++++++++++++++++++++++++++++
******************************************************
context.Employees.Add(
	new Employee()
	{
		EmpNo = 10,
		BirthDate = new DateTime(1980,12,12),
		FirstName = "AAA",
		LastName = "BBB",
		Gender = "M",
		HireDate = DateTime.Now,

		Titles = List<Title>(){
			new Title(){
				EmpNo=10,
				Title1="Senior Developer",
				FromDAte = DateTime.Now,
				ToDate=DateTime.Now.AddDays(365)
			}
		},
		Salaries = List<Salary>(){
			new Salary(){
				EmpNo=10,
				Salary=1000,
				FromDAte = DateTime.Now,
				ToDate=DateTime.Now.AddDays(365)
			}
		},
		DeptEmps = List<DeptEmp>(){
			new DeptEmp(){
				EmpNo=10,
				DeptEmp="1111",//depto.DeptNo,
				FromDAte = DateTime.Now,
				ToDate=DateTime.Now.AddDays(365)
			}
		},
		DeptManagers = List<DeptManager>(){
			new DeptManager(){
				EmpNo=10,
				DeptNo=="1111",//depto.DeptNo,
				FromDAte = DateTime.Now,
				ToDate=DateTime.Now.AddDays(365)
			}
		}
	});
context.SaveChanges();
Console.WriteLine("OK");
Console.ReadKey();
------------------------------------------------------
var transaction=context.Database.BeginTransaction();
try
{
	var d=new Departament();
	d.DeptNo="5555";
	d.DeptName="Math";
	context.Departaments.Add(d);

	context.Employees.Add(
		new Employee
		{
			EmpNo=40,
			FirstName="KAR",
			LastName="TRIN",
			Gender="F",
			BirthDate=DateTime.Now,
			HireDate=DateTime.Now
		}
	);

	context.DeptEmps.Add(
		new DeptEmp
		{
			DepNo="5555",
			EmpNo=30,
			FromDAte=DateTime.Now,
			ToDate=DateTime.Now
		}
	);

	context.SaveChanges();
	transaction.Commit();
	Console.WriteLine("Informacion Almacenada");
}catch(Exception ex)
{
	Console.WriteLine("Error ocurrido");
	Console.WriteLine(ex.InnerException.Message);
}
transaction.Dispose();
******************************************************
++++++++++++++++++++++++++++++++++++++++++++++++++++++
******************************************************
var resultado = from e in context.Employees
				join dm in context.DeptManagers
				on e.EmpNo equals dm.EmpNo
				join t in context.Titles
				on e.EmpNo equals t.EmpNo
				select new
				{
					HireOn=e.HireDate,
					FullName=e.FirstName+" "+e.LastName,
					Depto=dm.DeptNo,
					t.Title1
				};
foreach(var item in resultado)
{
	Console.WriteLine
	("{0} encontrado en {1} bajo el titulo {2} departamento{3}",
		item.FullName,item.HireOn,item.Title1,item.DeptNo);
}
Console.ReadLine();
------------------------------------------------------
******************************************************
++++++++++++++++++++++++++++++++++++++++++++++++++++++
******************************************************
------------------------------------------------------
******************************************************
++++++++++++++++++++++++++++++++++++++++++++++++++++++
******************************************************
------------------------------------------------------
******************************************************
++++++++++++++++++++++++++++++++++++++++++++++++++++++

