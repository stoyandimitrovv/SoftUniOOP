using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BirthdayCelebrations
{
    public class Engine
    {
        private List<IBirtable> reporsitory;

        public Engine()
        {
            this.reporsitory = new List<IBirtable>();
        }

        public void Run()
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputTokens = input.Split().ToArray();
                CreateBirthables(inputTokens);
                input = Console.ReadLine();
            }

            string seachedYear = Console.ReadLine();

            string[] birthdates = this.reporsitory.Where(b => b.Birthdate.Split("/").Last() == seachedYear).Select(b => b.Birthdate).ToArray();

            PrintFinalResult(birthdates);
        }

        private void PrintFinalResult(string[] birthdates)
        {
            foreach (var birthdate in birthdates)
            {
                Console.WriteLine(birthdate);
            }
        }

        private void CreateBirthables(string[] inputTokens)
        {
            IBirtable birthable = null;
            var type = inputTokens[0];
            if (type == "Citizen")
            {
                string name = inputTokens[1];
                int age = int.Parse(inputTokens[2]);
                string id = inputTokens[3];
                string birthdate = inputTokens[4];
                birthable = new Citizen(id, name, age, birthdate);
            }
            else if (type == "Pet")
            {
                string name = inputTokens[1];
                string birthdate = inputTokens[2];
                birthable = new Pet(name, birthdate);
            }

            if (birthable != null)
            {
                this.reporsitory.Add(birthable);
            }          
        }
    }
}
