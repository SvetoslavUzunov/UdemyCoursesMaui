using ProsperDailyApp.MVVM.Models;
using ProsperDailyApp.MVVM.Views;
using ProsperDailyApp.Repositories;

namespace ProsperDailyApp;

public partial class App : Application
{
   public static BaseRepository<Transaction> TransactionRepo { get; private set; }

   public App(BaseRepository<Transaction> transactionRepo)
   {
      InitializeComponent();

      TransactionRepo = transactionRepo;

      MainPage = new TransactionsPage();
   }
}
