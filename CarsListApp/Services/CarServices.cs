using CarsListApp.MVVM.Models;

namespace CarsListApp.Services;

public class CarServices
{
   public List<Car> GetCars()
   {
      return new List<Car>
      {
         new Car
         {
            Id = 1,
            Make = "Honda",
            Model = "Fit",
            VIN = "123"
         },
         new Car
         {
            Id = 2,
            Make = "Toyota",
            Model = "Prado",
            VIN = "123"
         },
         new Car
         {
            Id = 3,
            Make = "Honda",
            Model = "Civic",
            VIN = "123"
         },
         new Car
         {
            Id = 4,
            Make = "BMW",
            Model = "M3",
            VIN = "123"
         },
      };
   }
}
