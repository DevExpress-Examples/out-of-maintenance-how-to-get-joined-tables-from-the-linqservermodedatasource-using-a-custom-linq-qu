using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    protected void LinqServerModeDataSource1_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e)
    {
        DataClassesDataContext db = new DataClassesDataContext();
        e.KeyExpression = "EmployeeID";
        e.QueryableSource = from employee in db.Employees
                            join order in db.Orders on employee.EmployeeID equals order.EmployeeID
                select new {
                    employee.EmployeeID, employee.FirstName, employee.LastName, order.OrderID, order.OrderDate
                };
    }
}