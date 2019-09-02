using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Restaurant Restaurant { get; set; }

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        /// <summary>
        /// the param is passed by ASP.NET core routing mechanism, from anchor tag from List.cshtml
        /// asp-route-restaurantId="@restaurant.ID"
        /// </summary>
        /// <param name="restaurantId"></param>
        public IActionResult OnGet(int restaurantId)
        {/*
            //To avoid null reference error
            Restaurant = new Restaurant();
            //To show on view
            Restaurant.ID = restaurantId;

            */

            Restaurant = restaurantData.GetById(restaurantId);

            if(Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}