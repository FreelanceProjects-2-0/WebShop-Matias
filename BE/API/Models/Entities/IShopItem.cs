using System;

namespace WebShop.API.Models.Entities
{
    public interface IShopItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public int Stock { get; set; }

        public int Bought { get; set; }

        public float Discount { get; set; }
    }
}
