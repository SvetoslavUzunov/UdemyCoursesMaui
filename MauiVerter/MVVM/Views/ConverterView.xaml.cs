using MauiVerter.MVVM.ViewModels;

namespace MauiVerter.MVVM.Views;

public partial class ConverterView : ContentPage
{
	public ConverterView()
	{
		InitializeComponent();
	}

	private void PickerSelectedIndexChanged(object sender, EventArgs e)
	{
		var viewModel = (ConverterViewModel)BindingContext;
		viewModel.Convert();
	}
}