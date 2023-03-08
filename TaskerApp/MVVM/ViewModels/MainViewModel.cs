using System.Collections.ObjectModel;
using PropertyChanged;
using TaskerApp.MVVM.Models;

namespace TaskerApp.MVVM.ViewModels;

[AddINotifyPropertyChangedInterface]
public class MainViewModel
{
	public MainViewModel()
	{
		FillData();
		Tasks.CollectionChanged += TasksCollectionChanged;
	}

	public ObservableCollection<Category> Categories { get; set; }

	public ObservableCollection<MyTask> Tasks { get; set; }

	public void UpdateData()
	{
		foreach (var category in Categories)
		{
			var tasks = from t in Tasks
						where t.CategoryId == category.Id
						select t;

			var completed = from t in tasks
							where t.Completed == true
							select t;

			var notCompleted = from t in tasks
							   where t.Completed == false
							   select t;

			category.PendingTasks = notCompleted.Count();
			category.Percentage = (float)completed.Count() / (float)tasks.Count();
		}

		foreach (var task in Tasks)
		{
			var catColor =
				 (from c in Categories
				  where c.Id == task.CategoryId
				  select c.Color).FirstOrDefault();
			task.TaskColor = catColor;
		}
	}

	private void FillData()
	{
		Categories = new ObservableCollection<Category>
		{
			new Category
			{
				Id = 1,
				CategoryName = ".NET MAUI Course",
				Color = "#CF14DF"
			},
			new Category
			{
				Id = 2,
				CategoryName = "Tutorials",
				Color = "#DF6F14"
			},
			new Category
			{
				Id = 3,
				CategoryName = "Shopping",
				Color = "#14DF80"
			}
		};

		Tasks = new ObservableCollection<MyTask>
		{
			new MyTask
			{
				TaskName = "Plan next course",
				Completed = false,
				CategoryId = 1,
			}
		};

		UpdateData();
	}

	private void TasksCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
	{
		UpdateData();
	}
}
