
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== 4 ЗАДАНИЯ ПО C# ===");
        Console.WriteLine("1. Заказы ресторана");
        Console.WriteLine("2. Аренда автомобилей");
        Console.WriteLine("3. Библиотека");
        Console.WriteLine("4. Сотрудники");
        Console.WriteLine("0. Выход");

        Console.Write("Выберите задание: ");
        string choice = Console.ReadLine() ?? "";

        if (choice == "1")
        {
            Order order = new Order("Пицца", 3, 500);
            order.ShowInfo();
        }
        else if (choice == "2")
        {
            Car car = new Car("Toyota", "Camry", 2022, 3000);

            car.ShowInfo();

            Console.Write("Введите количество дней аренды: ");
            if (int.TryParse(Console.ReadLine(), out int days) && days > 0)
            {
                Console.WriteLine(
                    "Общая стоимость аренды: "
                    + car.CalculateRentalCost(days) + " сом");
            }
            else
            {
                Console.WriteLine("Введите корректное количество дней.");
            }
        }
        else if (choice == "3")
{
    Book book = new Book(
        "Преступление и наказание",
        "Фёдор Достоевский",
        true
    );

    book.ShowInfo();

    Console.WriteLine("\n1. Выдать книгу");
    Console.WriteLine("2. Вернуть книгу");
    Console.Write("Выберите действие: ");

    string action = Console.ReadLine() ?? "";

    if (action == "1")
    {
        book.ChangeStatus(false);
    }
    else if (action == "2")
    {
        book.ChangeStatus(true);
    }
    else
    {
        Console.WriteLine("Неверный выбор.");
    }

    book.ShowInfo();
}
        else if (choice == "4")
{
    Employee employee = new Employee(
        "Азамат",
        "Программист",
        30000
    );

    employee.ShowInfo();

    Console.Write("\nВведите процент повышения зарплаты: ");

    if (double.TryParse(Console.ReadLine(), out double percent)
        && percent > 0)
    {
        employee.IncreaseSalary(percent);
        employee.ShowInfo();
    }
    else
    {
        Console.WriteLine("Введите корректный процент.");
    }
}
        else if (choice == "0")
        {
            Console.WriteLine("Программа завершена.");
        }
        else
        {
            Console.WriteLine("Такого пункта нет.");
        }
    }
}

class Order
{
    public string DishName;
    public int Quantity;
    public double Price;

    public Order(string dishName, int quantity, double price)
    {
        DishName = dishName;
        Quantity = quantity;
        Price = price;
    }

    public double CalculateTotal()
    {
        return Quantity * Price;
    }

    public void ShowInfo()
    {
        Console.WriteLine("\n--- ЗАКАЗ В РЕСТОРАНЕ ---");
        Console.WriteLine("Блюдо: " + DishName);
        Console.WriteLine("Количество порций: " + Quantity);
        Console.WriteLine("Цена за порцию: " + Price + " сом");
        Console.WriteLine("Общая стоимость: " + CalculateTotal() + " сом");
    }
}

class Car
{
    public string Brand;
    public string Model;
    public int Year;
    public double PricePerDay;

    public Car(string brand, string model, int year, double pricePerDay)
    {
        Brand = brand;
        Model = model;
        Year = year;
        PricePerDay = pricePerDay;
    }

    public double CalculateRentalCost(int days)
    {
        return PricePerDay * days;
    }

    public void ShowInfo()
    {
        Console.WriteLine("\n--- АРЕНДА АВТОМОБИЛЯ ---");
        Console.WriteLine("Марка: " + Brand);
        Console.WriteLine("Модель: " + Model);
        Console.WriteLine("Год выпуска: " + Year);
        Console.WriteLine("Цена за день: " + PricePerDay + " сом");
    }
}


class Book
{
    public string Title;
    public string Author;
    public bool IsAvailable;

    public Book(string title, string author, bool isAvailable)
    {
        Title = title;
        Author = author;
        IsAvailable = isAvailable;
    }

    public void ChangeStatus(bool status)
    {
        IsAvailable = status;

        if (IsAvailable)
        {
            Console.WriteLine("Книга теперь доступна.");
        }
        else
        {
            Console.WriteLine("Книга выдана читателю.");
        }
    }

    public void ShowInfo()
    {
        Console.WriteLine("\n--- ИНФОРМАЦИЯ О КНИГЕ ---");
        Console.WriteLine("Название: " + Title);
        Console.WriteLine("Автор: " + Author);

        if (IsAvailable)
        {
            Console.WriteLine("Состояние: доступна");
        }
        else
        {
            Console.WriteLine("Состояние: выдана");
        }
    }
}

class Employee
{
    public string Name;
    public string Position;
    public double Salary;

    public Employee(string name, string position, double salary)
    {
        Name = name;
        Position = position;
        Salary = salary;
    }

    public void IncreaseSalary(double percent)
    {
        Salary = Salary + Salary * percent / 100;

        Console.WriteLine(
            "\nЗарплата повышена на " + percent + "%."
        );
    }

    public void ShowInfo()
    {
        Console.WriteLine("\n--- ИНФОРМАЦИЯ О СОТРУДНИКЕ ---");
        Console.WriteLine("Имя: " + Name);
        Console.WriteLine("Должность: " + Position);
        Console.WriteLine("Зарплата: " + Salary + " сом");
    }
}