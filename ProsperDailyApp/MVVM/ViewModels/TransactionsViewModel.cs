using ProsperDailyApp.MVVM.Models;

namespace ProsperDailyApp.MVVM.ViewModels;

public class TransactionsViewModel
{
   public Transaction Transaction { get; set; } = new Transaction()
   {
      OperationDate = DateTime.Now
   };

   public string SaveTransaction()
   {
      App.TransactionRepo.SaveItem(Transaction);

      return App.TransactionRepo.StatusMessage;
   }
}
