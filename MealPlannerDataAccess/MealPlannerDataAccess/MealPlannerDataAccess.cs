using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealClass;


namespace MealPlannerDataAccess
{
    public class MealContext : System.Data.Entity.DbContext
    {
        public DbSet<Meal> Meals { get; set; }
    }
}
