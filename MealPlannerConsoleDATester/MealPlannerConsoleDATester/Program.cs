using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealPlannerDataAccess;
using MealClass;

namespace MealPlannerConsoleDATester
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var db = new MealContext();
            SelectOption(db);
        }

        private static void SelectOption(MealContext db)
        {
            
            Console.WriteLine("Please Select an option by enter number of selection:");
            Console.WriteLine("1. Create new Meal");
            Console.WriteLine("2. View All Meals");
            Console.WriteLine("3. Exit Application");
            int selection = int.Parse(Console.ReadLine());
            if (selection == 1)
            {
                Console.Clear();
                CreateNewMeal(db);
            }
            else if (selection == 2)
            {
                Console.Clear();
                SelectAllMeals(db);  
            }
            else if (selection == 3)
            {
                ExitApplication();
            }
            else
            {
                Console.WriteLine("Invalid Selection");
                Console.Clear();
                SelectOption(db);
            }
        }

        private static void ExitApplication()
        {
            Console.WriteLine("Exiting Application...");
            Environment.Exit(0);
        }

        private static void SelectAllMeals(MealContext db)
        {
            var meals = from m in db.Meals select m;
            foreach (Meal meal in meals)
            {
                Console.WriteLine("Id: {0}. Meat: {1}. Vegetable: {2}. Other Item:{3}.",
                    meal.id, meal.meat, meal.vegetable, meal.otherItem);
            }
            Console.ReadLine();
            SelectOption(db);
        }

        private static void CreateNewMeal(MealContext db)
        {
            Meal AMeal = new Meal();
            Console.Write("Enter Meat: ");
            AMeal.meat = Console.ReadLine();
            Console.Write("Enter Vegetable: ");
            AMeal.vegetable = Console.ReadLine();
            Console.Write("Other Item: ");
            AMeal.otherItem = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Adding Meal");
            db.Meals.Add(AMeal);
            Console.WriteLine("Meal Added, now Saving Changes");
            db.SaveChanges();
            Console.WriteLine("Changes Saved");
            Console.ReadLine();
            Console.Clear();
            SelectOption(db);
            
        }
    }
}
