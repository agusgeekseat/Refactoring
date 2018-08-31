const int price = 100;

void Print()
{
    // quantity
    int q = 5;

    double t = q * price * (20/100); // tax, tax rate : 20%
    double total = Calculate(q, 0);
    
    // print receipt
    Console.WriteLine("Book Name: Refactoring Part 1");
    Console.WriteLine("Price: 100");
    Console.WriteLine("Quantity: " + q);
    Console.WriteLine("Tax: " + t);
    Console.WriteLine("Total: " + total);
}

// calculate total price
double Calculate(int a, int discount)
{
    double t = a * price * (20/100); // tax, tax rate : 20%
    double total = (a * price) + t;

    return total;
}