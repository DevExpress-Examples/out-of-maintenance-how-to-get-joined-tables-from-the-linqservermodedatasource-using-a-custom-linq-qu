Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub LinqServerModeDataSource1_Selecting(ByVal sender As Object, ByVal e As DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs)
		Dim db As New DataClassesDataContext()
		e.KeyExpression = "EmployeeID"
		e.QueryableSource = _
			From employee In db.Employees _
			Join order In db.Orders On employee.EmployeeID Equals order.EmployeeID _
			Select New With {Key employee.EmployeeID, Key employee.FirstName, Key employee.LastName, Key order.OrderID, Key order.OrderDate}
	End Sub
End Class