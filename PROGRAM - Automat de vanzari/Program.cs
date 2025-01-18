using System;

class VendingMachine
{
    // States of the vending machine
    enum State { A, B, C, D }

    static void Main()
    {
        State currentState = State.A;
        int totalCents = 0;

        Console.WriteLine("Vending Machine started. Price of the product is 20 cents.");
        Console.WriteLine("Insert coins: Nickel (5), Dime (10), or Quarter (25). Type 'exit' to quit.");

        while (true)
        {
            Console.WriteLine($"\nCurrent state: {currentState}, Total: {totalCents} cents");
            Console.Write("Insert coin (5, 10, 25): ");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                Console.WriteLine("Exiting. Thank you!");
                break;
            }

            int coin;
            if (!int.TryParse(input, out coin) || (coin != 5 && coin != 10 && coin != 25))
            {
                Console.WriteLine("Invalid coin. Please insert Nickel (5), Dime (10), or Quarter (25).");
                continue;
            }

            totalCents += coin;

            switch (currentState)
            {
                case State.A:
                    if (coin == 5) currentState = State.B;
                    else if (coin == 10) currentState = State.C;
                    else if (coin == 25) DispenseProduct(ref totalCents, ref currentState);
                    break;

                case State.B:
                    if (coin == 5) currentState = State.C;
                    else if (coin == 10) currentState = State.D;
                    else if (coin == 25) DispenseProduct(ref totalCents, ref currentState);
                    break;

                case State.C:
                    if (coin == 5) currentState = State.D;
                    else if (coin == 10 || coin == 25) DispenseProduct(ref totalCents, ref currentState);
                    break;

                case State.D:
                    DispenseProduct(ref totalCents, ref currentState);
                    break;
            }
        }
    }

    static void DispenseProduct(ref int totalCents, ref State currentState)
    {
        Console.WriteLine("Product dispensed!");
        totalCents -= 20;

        if (totalCents > 0)
        {
            Console.WriteLine($"Change returned: {totalCents} cents");
            totalCents = 0;
        }

        currentState = State.A;
    }
}
