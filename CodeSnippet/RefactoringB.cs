const int price = 100;

void Print()
{
    // quantity
    int q1 = 6;
    int q2 = 12;

    double t1 = q * price * (20/100); // tax, tax rate : 20%
    double total1 = Calculate(q1, 0);

    double t2 = q * price * (20/100); // tax, tax rate : 20%
    double total2 = Calculate(q2, 0);
    
    // print receipt
    string bookName1 = "Refactoring Part 1";
    Console.WriteLine("Book Name: Refactoring Part 1");
    Console.WriteLine("Price: 100");
    Console.WriteLine("Quantity: " + q1);
    Console.WriteLine("Tax: " + t1);
    Console.WriteLine("Total: " + total1);   

    string bookName2 = "Refactoring Part 2";
    Console.WriteLine("Book Name: Refactoring Part 2");
    Console.WriteLine("Price: 100");
    Console.WriteLine("Quantity: " + q2);
    Console.WriteLine("Tax: " + t2);
    Console.WriteLine("Total: " + total2);
}

// calculate total price
double Calculate(int a, int discount)
{
    double t = a * price * (20/100); // tax, tax rate : 20%
    double total = (a * price) + t;
    
    // check for discount
    if (quantity = 1) {
        total = (a * price) + t - 0;
    } else if (quantity > 5 && quantity <= 10) {
        total = (a * price) + t - 5;
    } else if (quantity > 10 && quantity <= 15) {
        total = (a * price) + t - 10;
    } else if (quantity > 15 && quantity <= 20) {
        total = (a * price) + t - 10;
    } else if (quantity > 20) {
        total = (a * price) + t - 15;
    }

    return total;
}