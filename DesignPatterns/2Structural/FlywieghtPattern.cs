using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural
{
    class FlywieghtPattern
    {

        public FlywieghtPattern()
        {
            InventorySystem _inventorySystem = new InventorySystem();

            _inventorySystem.TakeOrder(1,"Chair");
            _inventorySystem.TakeOrder(2, "Table");
            _inventorySystem.TakeOrder(3, "Board");
            _inventorySystem.TakeOrder(4, "Chair");
            _inventorySystem.TakeOrder(5, "Chair");
            _inventorySystem.TakeOrder(6, "Table");

            _inventorySystem.ProcessOrder();

            _inventorySystem.report();
        }
    }

    class Item
    {
        private readonly string name;

        public Item(string name)
        {
            this.name = name;
        }

        public string toString()
        {
            return name;
        }
    }

    class Order
    {
        private int orderId;
        private Item item;

        public Order(int orderId, Item item)
        {
            this.orderId = orderId;
            this.item = item;
        }

        public void processOrder()
        {
            Console.WriteLine("Order processed Id : "+orderId + " Item name : "+item.toString());
        }

    }

    //Factory to maintain/return items
    class Catalog
    {
        Dictionary<string, Item> catalog = new Dictionary<string,Item>();

        public Item LookupItem(string name)
        {
            if (!catalog.ContainsKey(name))
            {
                catalog.Add(name,new Item(name));
                return catalog[name];
            }

            return catalog[name];
        }


        public int TotalItems()
        {
            return catalog.Count;
        }

    }


    class InventorySystem
    {
        private Catalog catalog = new Catalog();
        List<Order> orders = new List<Order>();

        public void TakeOrder(int orderId, string name)
        {
            var existingItem = catalog.LookupItem(name);
            Order order = new Order(orderId, existingItem);
            orders.Add(order);
        }

        public void ProcessOrder()
        {
            List<Order> ordersList = orders.ToList();

            foreach (var order in ordersList)
            {
                order.processOrder();
                orders.Remove(order);
            }
            
        }

        public void report()
        {
            Console.WriteLine("total items made : "+catalog.TotalItems());
        }


    }
}
