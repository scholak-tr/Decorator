using System;

abstract class Drink
{
    protected string description = "Unknown Drink";

    public virtual string GetDescription()
    {
        return description;
    }

    public abstract double Cost();
}

class Tea : Drink
{
    public Tea()
    {
        description = "Tea";
    }

    public override double Cost()
    {
        return 1.0;
    }
}

class Coffee : Drink
{
    public Coffee()
    {
        description = "Coffee";
    }

    public override double Cost()
    {
        return 1.5;
    }
}

class Juice : Drink
{
    public Juice()
    {
        description = "Juice";
    }

    public override double Cost()
    {
        return 2.0;
    }
}

abstract class AddonDecorator : Drink
{
    public abstract override string GetDescription();
}

class Sugar : AddonDecorator
{
    Drink drink;

    public Sugar(Drink drink)
    {
        this.drink = drink;
        Console.WriteLine(" Добавлен сахар к " + drink.GetDescription());
    }

    public override string GetDescription()
    {
        return drink.GetDescription() + ", Sugar";
    }

    public override double Cost()
    {
        return drink.Cost() + 0.2;
    }
}

class Milk : AddonDecorator
{
    Drink drink;

    public Milk(Drink drink)
    {
        this.drink = drink;
        Console.WriteLine("Добавлено молоко к " + drink.GetDescription());
    }

    public override string GetDescription()
    {
        return drink.GetDescription() + ", Milk";
    }

    public override double Cost()
    {
        return drink.Cost() + 0.3;
    }
}

class Program
{
    static void Main()
    {
        Drink myDrink = null;
        Console.WriteLine("Выберите напиток:");
        Console.WriteLine("1 - Tea (1.0$)");
        Console.WriteLine("2 - Coffee (1.5$)");
        Console.WriteLine("3 - Juice (2.0$)");
        Console.Write("Ваш выбор: ");
        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                myDrink = new Tea();
                break;
            case "2":
                myDrink = new Coffee();
                break;
            case "3":
                myDrink = new Juice();
                break;
            default:
                Console.WriteLine("Неверный выбор, по умолчанию — Tea");
                myDrink = new Tea();
                break;
        }

        Console.WriteLine($"\n {myDrink.GetDescription()} — {myDrink.Cost()}$");

        while (true)
        {
            Console.WriteLine("\nДобавьте что-нибудь:");
            Console.WriteLine("1 - Добавить сахар (+0.2$)");
            Console.WriteLine("2 - Добавить молоко (+0.3$)");
            Console.WriteLine("0 - Завершить заказ");
            Console.Write("Ваш выбор: ");
            string addOn = Console.ReadLine();

            if (addOn == "1")
            {
                myDrink = new Sugar(myDrink);
            }
            else if (addOn == "2")
            {
                myDrink = new Milk(myDrink);
            }
            else if (addOn == "0")
            {
                break;
            }
            else
            {
                Console.WriteLine("Неверный выбор. Попробуйте снова.");
            }

            Console.WriteLine($"{myDrink.GetDescription()} — {myDrink.Cost()}$");
        }

        Console.WriteLine("\nВаш заказ:");
        Console.WriteLine($"Напиток: {myDrink.GetDescription()}");
        Console.WriteLine($"Итоговая стоимость: {myDrink.Cost()}$");
        Console.ReadKey();
    }
}
