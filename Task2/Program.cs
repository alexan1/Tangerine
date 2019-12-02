using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Random rnd = new Random();
        List<Item> items = new List<Item>
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
    }
}


public abstract class Item
{
    protected int price;
    protected float weight;
    abstract public float GetFullPrice();
    public float Weight { get { return weight; } }

    public override string ToString()
    {
        return $"({this.GetType().Name.ToLower()}) {this.GetFullPrice()} $ {this.weight} kg";
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

