Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace CustomCachedDocumentSourceSerialization

    Public Class CustomPageDataService

        Private _PageAdditionalData As Dictionary(Of Integer, System.Collections.Generic.List(Of Integer)), _SheetNames As Dictionary(Of Integer, String)

        Public Const Key As String = "customPageData"

        Public Property PageAdditionalData As Dictionary(Of Integer, List(Of Integer))
            Get
                Return _PageAdditionalData
            End Get

            Private Set(ByVal value As Dictionary(Of Integer, List(Of Integer)))
                _PageAdditionalData = value
            End Set
        End Property

        Public Property SheetNames As Dictionary(Of Integer, String)
            Get
                Return _SheetNames
            End Get

            Private Set(ByVal value As Dictionary(Of Integer, String))
                _SheetNames = value
            End Set
        End Property

        Public Sub New(ByVal pageAdditionalData As Dictionary(Of Integer, List(Of Integer)))
            If pageAdditionalData Is Nothing Then Throw New ArgumentNullException("pageAdditionalData")
            Me.PageAdditionalData = pageAdditionalData
        End Sub

        Public Sub PrintingSystem_XlSheetCreated(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.XlSheetCreatedEventArgs)
            If PageAdditionalData.ContainsKey(e.Index) Then
                Dim min As Integer = PageAdditionalData(e.Index).Min()
                Dim max As Integer = PageAdditionalData(e.Index).Max()
                e.SheetName = String.Format("Categories_{0}-{1}", min, max)
            End If
        End Sub
    End Class
End Namespace
