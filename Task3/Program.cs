using System;
using System.Collections.Generic;


namespace Task3
{
    class Program
    {
        public static void Main()
        {            
            var items = new List<Item>
        {

            //items contains all the items to buy
            //add the table, paddle and balls with the provided quantity
            new Table()
        };

            for (int i = 0; i < 4; i++)
            {
                items.Add(new Paddle());
            }

            for (int i = 0; i < 20; i++)
            {
                items.Add(new Balls());
            }

            //Display the price of each item
            items.ForEach(item => Console.WriteLine(item));

            // Add items to Cart
            Cart cart = new Cart();
            items.ForEach(item => item.Accept(cart));
            Console.WriteLine(cart);
        }
    }


    public interface IVisitor
    {
        void Visit(Item item);
    }

    public interface IVisitable
    {
        void Accept(IVisitor v);
    }

    public class Cart : IVisitor
    {
        private float totalPrice;
        private float totalWeight;

        public float TotalPrice { get { return totalPrice; } }
        public float TotalWeight { get { return totalWeight; } }

        public void Visit(Item item)
        {
            var fullPrice = item.GetFullPrice();

            this.totalPrice += (item is Table) ? fullPrice * 1.1f
                            : (item is Paddle) ? fullPrice * 0.5f
                            : fullPrice;
            this.totalWeight += item.Weight;
        }

        public override string ToString()
        {
            return $"The cart has a total cost of {this.totalPrice} $ and weighs {this.totalWeight} kg.";
        }
    }


    public abstract class Item : IVisitable
    {
        protected int price;
        protected float weight;
        abstract public float GetFullPrice();
        public float Weight { get { return weight; } }

        public override string ToString()
        {
            return $"({this.GetType().Name.ToLower()}) {this.GetFullPrice()} $ {this.weight} kg";
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Table : Item
    {
        public Table()
        {
            this.price = 100;
            this.weight = 100f;
        }
        public override float GetFullPrice()
        {
            return this.price;
        }
    }

    public class Paddle : Item
    {
        public Paddle()
        {
            this.price = 25;
            this.weight = 0.5f;
        }
        public override float GetFullPrice()
        {
            return this.price + (this.price * 0.15f);
        }
    }

    public class Balls : Item
    {
        public Balls()
        {
            this.price = 1;
            this.weight = 0.01f;
        }
        public override float GetFullPrice()
        {
            return this.price + (this.price * 0.1f);
        }
    }
}
