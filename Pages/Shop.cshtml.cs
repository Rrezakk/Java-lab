using Java.Contexts;
using Java.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Java.Pages
{
    public class ShopModel : PageModel
    {
        public ApplicationContext ApplicationContext { get; set; }
        public readonly IHttpContextAccessor HttpContextAccessor;

        public ShopModel(ApplicationContext applicationContext, IHttpContextAccessor httpContextAccessor)
        {
            ApplicationContext = applicationContext;
            HttpContextAccessor = httpContextAccessor;
        }
        public void OnGet()
        {

        }

        public void OnPostRentCar(int carId,int days)
        {
            var id = HttpContextAccessor.HttpContext?.Session.GetInt32("UserId")??-1;

            var rented = ApplicationContext.Rents.AsQueryable().FirstOrDefault(x => x.CarId == carId);

            if (rented != null) return;
            ApplicationContext.Rents.Add(new RentModel(id, carId, days));
            ApplicationContext.SaveChanges();
            System.Diagnostics.Debug.WriteLine($"Rented a car");
        }

        public void OnPostEndRentCar(int carId)
        {
            var entity = ApplicationContext.Rents.AsQueryable().FirstOrDefault(x => x.CarId == carId);
            if (entity != null)
                ApplicationContext.Rents.Remove(entity);
            ApplicationContext.SaveChanges();
        }

        public void OnPostDeleteCar(int carId)
        {
            var entity = ApplicationContext.Cars.AsQueryable().FirstOrDefault(x => x.Id == carId);
            if (entity != null)
                ApplicationContext.Cars.Remove(entity);
            ApplicationContext.SaveChanges();
        }
        public void OnPostAddCar(string name,string color,string serial,string state,int price)
        {
            var Car = new CarModel(name, color, serial, state, price);
            ApplicationContext.Cars.Add(Car);
            ApplicationContext.SaveChanges();
        }
    }
}
