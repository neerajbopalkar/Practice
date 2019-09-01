using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant
                {
                    ID = 1,
                    Name = "Neer's Pizza",
                    Location ="Vallabhnagar",
                    Cuisine = CuisineType.Italin
                },
                   new Restaurant
                {
                    ID = 2,
                    Name = "Neer's Buritos",
                    Location ="Barshi",
                    Cuisine = CuisineType.Mexican
                },
                      new Restaurant
                {
                    ID = 3,
                    Name = "Neer's Pav Bhaji",
                    Location ="Sangli",
                    Cuisine = CuisineType.Indian
                }
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
           
            return restaurants.OrderBy(item => item.Name);
        }
    }
}
