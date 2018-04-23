
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports MyMvpvmApplication.ViewModels
Imports DevExpress.Mvvm.POCO
Imports MyMvpvmApplication.Model
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base

Namespace MyMvpvmApplication.Views
    Partial Public Class TaskCollectionView
        Inherits UserControl
        Public Sub New()
            InitializeComponent()
            viewModelCore = ViewModelSource.Create(Of TaskCollectionViewModel)()
            presenterCore = New TaskCollectionPresenter(gridControl1, ViewModel)
            BindCommands()
        End Sub
        Private viewModelCore As TaskCollectionViewModel
        Public ReadOnly Property ViewModel() As TaskCollectionViewModel
            Get
                Return viewModelCore
            End Get
        End Property
        Private presenterCore As TaskCollectionPresenter
        Public ReadOnly Property Presenter() As TaskCollectionPresenter
            Get
                Return presenterCore
            End Get
        End Property
        Private Sub BindCommands()
            biAddTask.BindCommand(Sub() ViewModel.AddTask(), ViewModel)
            biDeleteTask.BindCommand(Sub() ViewModel.DeleteTask(Nothing), ViewModel, Function() ViewModel.SelectedTask)
        End Sub
    End Class

    Public Class TaskCollectionPresenter
        Public Sub New(grid As GridControl, viewModel__1 As TaskCollectionViewModel)
            viewModelCore = viewModel__1
            AddHandler DirectCast(grid.MainView, ColumnView).FocusedRowObjectChanged, AddressOf gridView1_FocusedRowObjectChanged
            TryCast(grid.DataSource, BindingSource).DataSource = ViewModel.Tasks
        End Sub
        Private Sub gridView1_FocusedRowObjectChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs)
            ViewModel.SelectedTask = TryCast(e.Row, Task)
        End Sub

        Private viewModelCore As TaskCollectionViewModel
        Public ReadOnly Property ViewModel() As TaskCollectionViewModel
            Get
                Return viewModelCore
            End Get
        End Property
    End Class
End Namespace