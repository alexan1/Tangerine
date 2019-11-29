﻿using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Random rnd = new Random();
        List<Item> items = new List<Item>();

        //items contains all the items to buy
        //add the table, paddle and balls with the provided quantity
        items.Add(new Table());

        for (int i = 0; i < rnd.Next(1, 10); i++)
            items.Add(new Paddle());

        for (int i = 0; i < rnd.Next(1, 10); i++)
            items.Add(new Balls());

        //Display the price of each item
        items.ForEach(item => Console.WriteLine(item));
    }
}


public abstract class Item
{
    protected int price;
    protected float weight;
    abstract public float getFullPrice();
    public float Weight { get { return weight; } }

    public override string ToString()
    {
        return $"({this.GetType().Name.ToLower()}) {this.getFullPrice()} $ {this.weight} kg";
    }
}

public class Table : Item
{
    public Table()
    {
        this.price = 100;
        this.weight = 100f;
    }
    public override float getFullPrice()
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
    public override float getFullPrice()
    {
        return this.price + (this.price * 0.15f);
    }
}

public class Balls : Item
{
    public Balls()
    {
        this.price = 1;
        this.weight = 0.1f;
    }
    public override float getFullPrice()
    {
        return this.price + (this.price * 0.1f);
    }
}
