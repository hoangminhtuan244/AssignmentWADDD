using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace AssignmentWAD.Models
{
    public class Cart
        {
        public Dictionary<int, CartItem> Items { get; set; }
        public double TotalPrice => Items.Values.Sum(items => items.TotalItemPrice);
        public int TotalQuantity => Items.Count();

        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }

        public void Add(Product product, int quantity = 1)
        {
            var exitsKey = Items.ContainsKey(product.ProductId);
            if (exitsKey)
            {
                Items[product.ProductId].Quantity += quantity;
            }
            else
            {
                var cartItem = new CartItem()
                {
                    ProId = product.ProductId,
                    ProCode = product.ProductCode,
                    ProName = product.ProductName,          
                    ProPrice = product.ProductPrice,
                    ProDescription = product.ProductDescription,
                    ProThumbnail = product.ProductThumnail,
                    Quantity = quantity
                };
                Items.Add(product.ProductId, cartItem);
            }
        }
        public void Update(int id, int quantity)
        {
            var exitsKey = Items.ContainsKey(id);
            if (exitsKey)
            {
                Items[id].Quantity = quantity;
            }
        }
        public void Remove(int id)
        {
            if (Items.ContainsKey(id))
            {
                Items.Remove(id);
            }
        }
        public void Clear()
        {
            Items.Clear();
        }

    }
    public class CartItem
        {
            public int ProId { get; set; }
            public string ProCode { get; set; }
            public string ProName { get; set; }
            public double ProPrice { get; set; }
            public string ProDescription { get; set; }
            public string ProThumbnail { get; set; }
            public double TotalItemPrice => ProPrice * Quantity;
            public int Quantity { get; set; }
        }
    }
