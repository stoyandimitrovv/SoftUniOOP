using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodShortage
{
    public class Engine
    {
        private List<IBuyer> reporsitory;

        public Engine()
        {
            this.reporsitory = new List<IBuyer>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] buyersInfo = Console.ReadLine().Split();
                string name = buyersInfo[0];
                int age = int.Parse(buyersInfo[1]);
                IBuyer buyer = null;
                if (buyersInfo.Length == 3)
                {
                    string group = buyersInfo[2];
                    buyer = new Rebel(name, age, group);
                }
                else if (buyersInfo.Length == 4)
                {
                    string id = buyersInfo[2];
                    string birthdate = buyersInfo[3];
                    buyer = new Citizen(id, name, age, birthdate);
                }

                if (buyer != null)
                {
                    this.reporsitory.Add(buyer);
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                IBuyer newBuyer = BuyFood(input, reporsitory);
                newBuyer?.BuyFood();
                input = Console.ReadLine();
            }

            PrintFinalResult();
        }

        private void PrintFinalResult()
        {
            int totalFoodBought = reporsitory.Sum(buyer => buyer.Food);
            Console.WriteLine(totalFoodBought);
        }

        private IBuyer BuyFood(string buyer, List<IBuyer> repository)
        {
            IBuyer curBuyer = reporsitory.FirstOrDefault(cb => cb.Name == buyer);
            return curBuyer;
        }
    }
}
