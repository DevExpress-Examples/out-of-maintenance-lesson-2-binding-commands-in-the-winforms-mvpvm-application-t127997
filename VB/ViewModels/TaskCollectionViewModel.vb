
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Text
Imports MyMvpvmApplication.Model
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports DevExpress.Mvvm.DataAnnotations

Namespace MyMvpvmApplication.ViewModels
    Public Class TaskCollectionViewModel
        Private tasksCore As IList(Of Task)

        Public Sub New()
            tasksCore = New BindingList(Of Task)() From { _
                New Task() With { _
                    .Subject = "Test Task", _
                    .Description = "Test Description" _
                } _
            }
        End Sub
        Public ReadOnly Property Tasks() As IList(Of Task)
            Get
                Return tasksCore
            End Get
        End Property

        Public Sub AddTask()
            Tasks.Add(New Task() With { _
                .Subject = "Task " + Tasks.Count.ToString() _
            })
        End Sub

        Public Overridable Property SelectedTask() As Task

        Protected Overridable Sub OnSelectedTaskChanged()
            Me.RaiseCanExecuteChanged(Sub(x) x.DeleteTask(Nothing))
        End Sub
        <Command(UseCommandManager:=False)> _
        Public Sub DeleteTask(task As Task)
            Tasks.Remove(task)
        End Sub
        Public Function CanDeleteTask(task As Task) As Boolean
            Return task IsNot Nothing
        End Function

    End Class
End Namespace