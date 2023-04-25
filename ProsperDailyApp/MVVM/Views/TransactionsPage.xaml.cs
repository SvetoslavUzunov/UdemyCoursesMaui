using ProsperDailyApp.MVVM.ViewModels;

namespace ProsperDailyApp.MVVM.Views;

public partial class TransactionsPage : ContentPage
{
   public TransactionsPage()
   {
      InitializeComponent();

      BindingContext = new TransactionsViewModel();
   }

   private async void BtnSaveClicked(object sender, EventArgs e)
   {
      var currentViewModel = (TransactionsViewModel)BindingContext;
      var message = currentViewModel.SaveTransaction();
      await DisplayAlert("Info", message, "Ok");
      await Navigation.PopToRootAsync();
   }

   private async void BtnCancelClicked(object sender, EventArgs e)
   {
      await Navigation.PopToRootAsync();
   }
}