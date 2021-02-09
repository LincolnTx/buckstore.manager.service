﻿using buckstore.manager.service.domain.SeedWork;

namespace buckstore.manager.service.domain.Aggregates.ProductAggregate
{
    public class Product : Entity, IAggregateRoot
    {
        private string _name;
        public string Name => _name;
        private string _description;
        public string Description => _description;
        private double _price;
        public double Price => _price;
        private int _stockQuantity;
        public int Stock => _stockQuantity;
        private int _categoryId;
        public ProductCategory Category { get; private set; }
        
        protected Product() { }

        public Product(string name, string description, double price, int stock, int categoryId)
        {
            _name = name;
            _description = description;
            _price = price;
            _stockQuantity = stock;
            _categoryId = categoryId;
        }

        public void AddStock(int quantity)
        {
            _stockQuantity += quantity;
        }

        public void DeductStock(int quantity)
        {
            _stockQuantity -= quantity;
        }

        public bool CheckAvailability()
        {
            return _stockQuantity > 0;
        }

        public void ChangeProductPrice(double newPrice)
        {
            _price = newPrice;
        }
        
    }
}