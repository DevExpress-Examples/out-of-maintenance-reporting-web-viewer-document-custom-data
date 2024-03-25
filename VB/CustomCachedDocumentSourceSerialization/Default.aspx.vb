Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace CustomCachedDocumentSourceSerialization

    Public Partial Class [Default]
        Inherits Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            ASPxWebDocumentViewer1.OpenReport(New CategoriesReport())
        End Sub
    End Class
End Namespace
