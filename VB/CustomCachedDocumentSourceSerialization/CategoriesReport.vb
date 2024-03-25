Imports System
Imports System.Collections.Generic
Imports DevExpress.XtraReports.UI

Namespace CustomCachedDocumentSourceSerialization

    Public Partial Class CategoriesReport
        Inherits XtraReport

        Private pageAdditionalData As Dictionary(Of Integer, List(Of Integer)) = New Dictionary(Of Integer, List(Of Integer))()

        Public Sub New()
            InitializeComponent()
            AddHandler PrintingSystem.XlSheetCreated, AddressOf PrintingSystem_XlSheetCreated
            PrintingSystem.AddService(GetType(CustomPageDataService), New CustomPageDataService(pageAdditionalData))
        End Sub

        Private Sub PrintingSystem_XlSheetCreated(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.XlSheetCreatedEventArgs)
            Dim serviceProvider = TryCast(PrintingSystem, IServiceProvider)
            Dim customPageDataService As CustomPageDataService = Nothing
            If serviceProvider IsNot Nothing AndAlso (CSharpImpl.__Assign(customPageDataService, TryCast(serviceProvider.GetService(GetType(CustomPageDataService)), CustomPageDataService))) IsNot Nothing Then
                customPageDataService.PrintingSystem_XlSheetCreated(sender, e)
            End If
        End Sub

        Private Sub CategoryId_PrintOnPage(ByVal sender As Object, ByVal e As PrintOnPageEventArgs)
            Dim cell = TryCast(sender, XRTableCell)
            Dim categoryNumber As Integer
            If cell IsNot Nothing AndAlso Integer.TryParse(cell.Text, categoryNumber) Then
                If Not pageAdditionalData.ContainsKey(e.PageIndex) Then
                    pageAdditionalData(e.PageIndex) = New List(Of Integer)()
                End If

                pageAdditionalData(e.PageIndex).Add(categoryNumber)
            End If
        End Sub

        Private Class CSharpImpl

            <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class
End Namespace
