using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using MvcJsonWebAPI.Models;
using MvcJsonWebAPI.Helpers;


namespace MvcJsonWebAPI.Controllers
{
    public class CarApiController : ApiController
    {
        List<CarSales> CarSalesNumber;
        public CarApiController()
        {
            //以亂數產生1-12月數據
            Utility util = new Utility();
            var random1 = util.getNumbers(12);
            var random2 = util.getNumbers(12);

            CarSalesNumber = new List<CarSales>
            {
                new CarSales { Id = 1, Car = "BMW", Salesdata = random1 },
                new CarSales { Id = 2, Car = "BENZ", Salesdata = random2 }
            };
        }

        //url pattern : api/cars
        [AcceptVerbs("GET", "POST")]
        public IEnumerable<CarSales> getCarSalesNumber()
        {
            return CarSalesNumber;
        }

        //url pattern : api/cars/2
        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult getSingleCar(int id)
        {
            var car = CarSalesNumber.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }
    }
}
