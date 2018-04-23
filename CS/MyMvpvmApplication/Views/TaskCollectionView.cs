using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyMvpvmApplication.ViewModels;
using DevExpress.Mvvm.POCO;
using MyMvpvmApplication.Model;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;

namespace MyMvpvmApplication.Views {
    public partial class TaskCollectionView : UserControl {
        public TaskCollectionView() {
            InitializeComponent();
            viewModelCore = ViewModelSource.Create<TaskCollectionViewModel>();
            presenterCore = new TaskCollectionPresenter(gridControl1, ViewModel);
            BindCommands();
        }
        TaskCollectionViewModel viewModelCore;
        public TaskCollectionViewModel ViewModel {
            get { return viewModelCore; }
        }
        TaskCollectionPresenter presenterCore;
        public TaskCollectionPresenter Presenter {
            get { return presenterCore; }
        }
        void BindCommands() {
            biAddTask.BindCommand(() => ViewModel.AddTask(), ViewModel);
            biDeleteTask.BindCommand(() => ViewModel.DeleteTask(null), ViewModel, () => ViewModel.SelectedTask);
        }
    }

    public class TaskCollectionPresenter {
        public TaskCollectionPresenter(GridControl grid, TaskCollectionViewModel viewModel) {
            viewModelCore = viewModel;
            ((ColumnView)grid.MainView).FocusedRowObjectChanged += gridView1_FocusedRowObjectChanged;
            (grid.DataSource as BindingSource).DataSource = ViewModel.Tasks;
        }
        void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e) {
            ViewModel.SelectedTask = e.Row as Task;
        }

        TaskCollectionViewModel viewModelCore;
        public TaskCollectionViewModel ViewModel {
            get { return viewModelCore; }
        }
    }
}
