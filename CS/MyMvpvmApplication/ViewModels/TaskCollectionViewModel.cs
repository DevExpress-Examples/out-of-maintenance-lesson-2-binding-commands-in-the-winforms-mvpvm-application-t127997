using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using MyMvpvmApplication.Model;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataAnnotations;

namespace MyMvpvmApplication.ViewModels {
    public class TaskCollectionViewModel {
        IList<Task> tasksCore;

        public TaskCollectionViewModel() {
            tasksCore = new BindingList<Task> { 
                new Task(){ Subject="Test Task", Description = "Test Description"}
            };
        }
        public IList<Task> Tasks {
            get { return tasksCore; }
        }

        public void AddTask() {
            Tasks.Add(new Task() { Subject = "Task " + Tasks.Count.ToString() });
        }

        public virtual Task SelectedTask {
            get;
            set;
        }
        protected virtual void OnSelectedTaskChanged() {
            this.RaiseCanExecuteChanged(x => x.DeleteTask(null));
        }
        [Command(UseCommandManager = false)]
        public void DeleteTask(Task task) {
            Tasks.Remove(task);
        }
        public bool CanDeleteTask(Task task) {
            return task != null;
        }

    }
}
