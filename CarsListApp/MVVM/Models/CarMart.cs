namespace CarsListApp.MVVM.Models;

public class CarMart
{
   public CarMart()
   {
      Cars = new List<Car>();
   }

   public int Id { get; set; }

   public List<Car> Cars { get; set; }
}
