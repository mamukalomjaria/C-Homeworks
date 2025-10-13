using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using static Program;
internal class Program
{
    interface IAnimal
    {
        void MakeSound();
    }

    public class Dog: IAnimal
    {
        public void MakeSound()
        {
            Console.WriteLine("Woof!");
        }
    }

    public class Cat : IAnimal
    {
        public void MakeSound()
        {
            Console.WriteLine("Meow");
        }
    }

    public interface IVehicle
    {
        public string Model { get; set; }
        public int Year { get; set; }
        public void start();
    }

    public class Car : IVehicle
    {
        public string Model { get; set; }
        public int Year { get; set; }

        public void start()
        {
            Console.WriteLine($"Car model: {Model}, Year: {Year} startet..");
        }
    }


    public interface IReadable
    {
        void Read();
    }

    public interface IWritable
    {
        void Write();
    }

    public class Document : IReadable, IWritable
    {
        public void Read()
        {
            Console.WriteLine("Reading mode");
        }

        public void Write()
        {
            Console.WriteLine("Writting mode");
        }
    }


    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);
    }

    public class CreditCardPayment : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Payement amount: {amount} succesfull...");
        }
    }

    public class PayPalPayment : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Payement amount: {amount} succesfull...");
        }
    }

    public interface ILogger
    {
        void Log(string message); 
        void LogWithTime(string message)
        {
            Console.WriteLine($"{DateTime.Now}:{message}");
        }
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public interface IShape
    {
        double GerArea();
    }

    public class Rectangle: IShape
    {
        public double a { get; set; }
        public double b { get; set; }

        public Rectangle (double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public double GerArea()
        {
            return a * b;
        }
    }

    public class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle( double radius)
        {
            Radius = radius;
        }

        public double GerArea() { 
        return Radius*Radius*Math.PI;
        }

    }
    static void Main(string[] args)
    {
        List<IAnimal> animals = new List<IAnimal>() { 
        new Dog(),
        new Cat()};

        foreach (IAnimal animal in animals)
        {
            animal.MakeSound();
        }

        Car toyota = new Car();
        toyota.Model = "Prius";
        toyota.Year = 2016;

        toyota.start();


        Document sheet = new Document();

        sheet.Write();
        sheet.Read();

        Console.WriteLine("Select a payment method:");
        Console.WriteLine("1. Credit Card");
        Console.WriteLine("2. PayPal");

        string choice = Console.ReadLine();
        IPaymentProcessor paymentProcessor = null;
        switch (choice)
        {
            case "1":
                paymentProcessor = new CreditCardPayment();
                break;
            case "2":
                paymentProcessor = new PayPalPayment();
                break;
            default:
                Console.WriteLine("Invalid choice. Exiting program.");
                return;
        }
        Console.Write("Enter payment amount: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            paymentProcessor.ProcessPayment(amount);
        }
        else
        {
            Console.WriteLine("Invalid amount entered.");
        }

        ILogger logger = new ConsoleLogger();

        logger.Log("My message");

        logger.LogWithTime("My message");

        Console.ReadLine();
        List<IShape> shapes = new List<IShape>() {
            new Rectangle(4, 5),
            new Circle(3),
            new Rectangle(2.5, 6),
            new Circle(1.5)
        };

    }

    
   
}