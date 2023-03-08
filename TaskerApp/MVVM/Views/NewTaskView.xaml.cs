using TaskerApp.MVVM.Models;
using TaskerApp.MVVM.ViewModels;

namespace TaskerApp.MVVM.Views;

public partial class NewTaskView : ContentPage
{
	public NewTaskView()
	{
		InitializeComponent();
	}

	private async void AddTaskClicked(object sender, EventArgs e)
	{
		var newTaskViewModel = BindingContext as NewTaskViewModel;

		var selectedCategory = newTaskViewModel.Categories.Where(c => c.IsSelected).FirstOrDefault();

		if (selectedCategory is not null)
		{
			var task = new MyTask
			{
				TaskName = newTaskViewModel.Task,
				CategoryId = selectedCategory.Id,
			};

			newTaskViewModel.Tasks.Add(task);
			await Navigation.PopAsync();
		}
		else
		{
			await DisplayAlert("Invalid Selection", "You must select a category", "Ok");
		}
	}

	private async void AddCategoryClicked(object sender, EventArgs e)
	{
		var newTaskViewModel = BindingContext as NewTaskViewModel;

		string category = await DisplayPromptAsync("New Category", "Write the new category name", maxLength: 15, keyboard: Keyboard.Text);

		var random = new Random();

		if (!string.IsNullOrEmpty(category))
		{
			newTaskViewModel.Categories.Add(new Category
			{
				Id = newTaskViewModel.Categories.Max(x => x.Id) + 1,
				Color = Color.FromRgb(random.Next(255), random.Next(255), random.Next(255)).ToHex(),
				CategoryName = category
			});
		}
	}
}