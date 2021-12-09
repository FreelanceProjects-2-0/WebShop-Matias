using System;

namespace WebShop.API.ViewModels
{
    public class ShopItemViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public int Stock { get; set; }

        public float Discount { get; set; }

        public string Description { get; set; }

        public int Bought { get; set; }

    }
}
