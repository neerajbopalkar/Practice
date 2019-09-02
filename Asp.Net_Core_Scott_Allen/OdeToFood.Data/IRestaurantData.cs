using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();

        IEnumerable<Restaurant> GetRestaurantByName(string name);
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
                    Name = "A Neer's Pizza",
                    Location ="Vallabhnagar",
                    Cuisine = CuisineType.Italin
                },
                   new Restaurant
                {
                    ID = 2,
                    Name = "B Neer's Buritos",
                    Location ="Barshi",
                    Cuisine = CuisineType.Mexican
                },
                      new Restaurant
                {
                    ID = 3,
                    Name = "C Neer's Pav Bhaji",
                    Location ="Sangli",
                    Cuisine = CuisineType.Indian
                }
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
           
            return restaurants.OrderBy(item => item.Name);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
