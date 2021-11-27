--
-- VER TODOS LOS AUTORES
--
from a in autor
select new
{
	a.IdAutor,
	a.Nombre,
	Estado = a.Estado == 1 ? "Activo" : "Inactivo"
}

--
-- VER AUTOR
--
from a in autor
where a.IdAutor == 1
select new
{
	a.IdAutor,
	a.Nombre,
	Estado = a.Estado == 1 ? "Activo" : "Inactivo"
}

--
-- VER TODAS LAS CATEGORIAS
--
from c in categoria
select new
{
	c.IdCategoria,
	c.Nombre,
	Estado = c.Estado == 1 ? "Activo" : "Inactivo"
}

--
-- VER CATEGORIA
--
from c in categoria
where c.IdCategoria == 1
select new
{
	c.IdCategoria,
	c.Nombre,
	Estado = c.Estado == 1 ? "Activo" : "Inactivo"
}

--
-- VER TODAS LAS EDITORIALES 
--
from e in editorial
select new
{
	e.IdEditorial,
	e.Nombre,
	Estado = e.Estado == 1 ? "Activo" : "Inactivo"
}

--
-- VER EDITORIAL
--
from e in editorial
where e.IdEditorial == 1
select new
{
	e.IdEditorial,
	e.Nombre,
	Estado = e.Estado == 1 ? "Activo" : "Inactivo"
}

--
-- VER TODAS LAS ENTRADAS 
--
from e in entradaproduc
join l in libro on e.IdLibro equals l.IdLibro
select new
{
	IdProd = e.IdProd,
	Fecha = e.Fecha,
	Titulo = l.Titulo,
	Cantidad = e.Cantidad
}

--
-- VER ENTRADA
--
from e in entradaproduc
join l in libro on e.IdLibro equals l.IdLibro
where e.IdProd == 1
select new
{
	IdProd = e.IdProd,
	Fecha = e.Fecha,
	Titulo = l.Titulo,
	Cantidad = e.Cantidad
}

--
-- VER TODOS LOS LIBROS
--
from l in libro
join a in autor on l.IdAutor equals a.IdAutor
join c in categoria on l.IdCategoria equals c.IdCategoria
join e in editorial on l.IdEditorial equals e.IdEditorial
orderby l.IdLibro
select new
{
	IdLibro = l.IdLibro,
	Titulo = l.Titulo,
	Autor = a.Nombre,
	Categoria = c.Nombre,
	Editorial = e.Nombre,
	Ubicacion = l.Ubicacion,
	Ejemplares = l.Ejemplares,
	Estado = l.Estado == 1 ? "Activo" : "Inactivo",
	FechaPublicacion = l.FechaPublicacion,
	Costo = l.Costo,
	Precio = l.Precio
}

--
-- VER LIBRO
--
var escuela = 
from l in libro
join a in autor on l.IdAutor equals a.IdAutor
join c in categoria on l.IdCategoria equals c.IdCategoria
join e in editorial on l.IdEditorial equals e.IdEditorial
where l.IdLibro == 1
select new
{
	IdLibro = l.IdLibro,
	Titulo = l.Titulo,
	Autor = a.Nombre,
	Categoria = c.Nombre,
	Editorial = e.Nombre,
	Ubicacion = l.Ubicacion,
	Ejemplares = l.Ejemplares,
	Estado = l.Estado == 1 ? "Activo" : "Inactivo",
	FechaPublicacion = l.FechaPublicacion,
	Costo = l.Costo,
	Precio = l.Precio
};
var res = escuela.ToList();

--
-- VER TODAS LAS PERSONAS
--
from per in persona
join nivel in nivel_user on per.IdNivel equals nivel.IdNivelUser
select new
{
	IdPersona = per.IdPersona,
	Nombre = per.Nombre,
	Apellido = per.Apellido,
	Direccion = per.Direccion,
	Telefono = per.Telefono,
	Correo = per.Correo,
	Usuario = per.Usuario,
	Nivel = nivel.Nombre,
	Estado = per.Estado == 1 ? "Activo" : "Inactivo"
}

--
-- VER PERSONA
--
from per in persona
join nivel in nivel_user on per.IdNivel equals nivel.IdNivelUser
where per.IdPersona == 1
select new
{
	IdPersona = per.IdPersona,
	Nombre = per.Nombre,
	Apellido = per.Apellido,
	Direccion = per.Direccion,
	Telefono = per.Telefono,
	Correo = per.Correo,
	Usuario = per.Usuario,
	Nivel = nivel.Nombre,
	Estado = per.Estado == 1 ? "Activo" : "Inactivo"
}

****************************************************************************************************
****************************************************************************************************
****************************************************************************************************
var onlineOrders = context.SalesOrderHeaders
.Where(order => order.OnlineOrderFlag == true)
.Select(s => new { s.SalesOrderID, s.OrderDate, s.SalesOrderNumber });
foreach (var onlineOrder in onlineOrders)
{
	Console.WriteLine("Order ID: {0} Order date: {1:d} Order number: {2}",
	onlineOrder.SalesOrderID,
	onlineOrder.OrderDate,
	onlineOrder.SalesOrderNumber);
}
****************************************************************************************************
var query = context.SalesOrderDetails
.Where(order => order.OrderQty > orderQtyMin && order.OrderQty < orderQtyMax)
.Select(s => new { s.SalesOrderID, s.OrderQty });
foreach (var order in query)
{
	Console.WriteLine("Order ID: {0} Order quantity: {1}",order.SalesOrderID, order.OrderQty);
}
****************************************************************************************************
String color = "Red";
var query = context.Products
.Where(product => product.Color == color)
.Select(p => new { p.Name, p.ProductNumber, p.ListPrice });
foreach (var product in query)
{
	Console.WriteLine("Name: {0}", product.Name);
	Console.WriteLine("Product number: {0}", product.ProductNumber);
	Console.WriteLine("List price: ${0}", product.ListPrice);
	Console.WriteLine("");
}
****************************************************************************************************
var query = from product in products
group product by product.Style into g
select new
{
	Style = g.Key,
	AverageListPrice = g.Average(product => product.ListPrice)
};
foreach (var product in query)
{
	Console.WriteLine("Product style: {0} Average list price: {1}",
		product.Style, product.AverageListPrice);
}
****************************************************************************************************
****************************************************************************************************
IdLibro = libros.IdLibro,
Titulo = libros.Titulo,
Imagen = libros.Imagen,
Autor = libros.Autor,
Categoria = libros.Categoria,
Editorial = libros.Editorial,
Ubicacion = libros.Ubicacion,
Ejemplares = libros.Ejemplares,
Estado = libros.Estado,
FechaPublicacion = libros.FechaPublicacion,
Costo = libros.Costo,
Precio = libros.Precio
****************************************************************************************************
****************************************************************************************************
****************************************************************************************************
Entidad.cs
class Customer
{
	public String CustomerID { get; set; }1
	public String Contacto { get; set; }
	public String Company { get; set; }
	public List<Order> Orders { get; set; }2
}
class Order
{
	public int OrderID { get; set; }
	public String CustomerID { get; set; }1
	public Date OrderDate { get; set; }
	public Customer Customer { get; set; }2
}

MainClass
static void Main()
{
	var resultado =
	from c in DB.Customers
	join o in DB.Orders
	on c.CustomerID equals o.CustomerID
	select new { c.Contacto, o.OrderDate };
	foreach (var pair in resultado.Take(6))
		Console.WriteLine(pair);
}
****************************************************************************************************
****************************************************************************************************
***CONSULTA***
using(SampleDbEntities db = new SampleDbEntities())
{
	var employees = from e in db.Employees
	where e.LastName == "Tendulkar"
	select e;
}

***METODO***
var employees = db.Employees
	.Where(employee => employee.LastName == "Tendulkar");
foreach (Employee e in employees )
{
	Console.WriteLine(e.FirstName + ' ' + e.LastName + ' ' + e.Title);
}

***CONSULTA***
var result = (from m1 in db.model1
	join m2 in db.model2
	on new { m1.field1 , m1.field2 } equals new {m2.field1, m2.field2 }
	where m1.FirstName == "KEN"
	select new
	{
		field1 = m1.field1,
		field2 = m1.field2,
		someField = m2.someField
	}).ToList();

***METODO***
var result = db.model1
	.Join(db.model2,									//Tabla interior para unirse
		p => new { p1 = p.field1, p2 = p.field2 } ,     //Condición de la tabla exterior
		e => new { p1 = e.fld1, p2 = e.fld2 },          //Condición de la tabla interior
		(p, e) => new {                                 //Resultado
			field1 = p.fld1,
			field2 = p.fld2,
			someField = e.someField
		}).ToList();

***CONSULTA***
var person = (from e in db.Employees
	join p in db.People on e.BusinessEntityID equals p.BusinessEntityID
	join s in db.SalesPersons on e.BusinessEntityID equals s.BusinessEntityID
	join t in db.SalesTerritories on s.TerritoryID equals t.TerritoryID 
	where t.CountryRegionCode == "CA"
	select new
	{
		ID = e.BusinessEntityID,
		FirstName = p.FirstName,
		MiddleName = p.MiddleName,
		LastName = p.LastName,
		Region = t.CountryRegionCode	
	}).ToList();

***METODO***
var person = db.Employees
	.Join(db.People, emp=> emp.BusinessEntityID, per=> per.BusinessEntityID, (emp,per) => new {emp,per})
	.Join(db.SalesPersons, o => o.emp.BusinessEntityID, sal=> sal.BusinessEntityID, (emp1,sal) => new {emp1,sal})
	.Join(db.SalesTerritories, o=> o.sal.TerritoryID, ter=>ter.TerritoryID, (emp2,ter) => new {emp2,ter})
	.Where(z => z.ter.CountryRegionCode=="CA")
	.Select(z => new
	{
		ID = z.emp2.emp1.per.BusinessEntityID,
		FirstName=z.emp2.emp1.per.FirstName,
		MiddleName=z.emp2.emp1.per.MiddleName,
		LastName=z.emp2.emp1.per.LastName,
		Region=z.ter.CountryRegionCode
	}).ToList();

***CONSULTA***

***METODO***

***CONSULTA***

***METODO***
****************************************************************************************************
****************************************************************************************************
****************************************************************************************************
****************************************************************************************************
****************************************************************************************************
****************************************************************************************************
****************************************************************************************************
****************************************************************************************************
****************************************************************************************************
****************************************************************************************************
****************************************************************************************************
****************************************************************************************************
****************************************************************************************************
****************************************************************************************************
****************************************************************************************************

