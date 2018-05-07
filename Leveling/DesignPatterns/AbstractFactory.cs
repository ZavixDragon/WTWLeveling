using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns
{
    //Case study for fun!
    //You make sweet food ordering software, and clients need a plugin point to make their own menu's for the food
    //You don't want to change the software when clients decide on new menu items so you decide that they can just implement this interface
    public interface IFoodFactory
    {
        //Here since we are not sure all the foods you can buy as it can vary from place to place
        List<string> GetMenu();
        IFood Create(string foodName);
    }

    public interface IFood
    {
        string Eat();
    }

    //One of your first client's is a donut shop so here they got to make this class for donuts menu
    public class DonutFactory : IFoodFactory
    {
        //There is of course plenty of ways to implement the internals
        private readonly Dictionary<string, Func<IFood>> _donuts = new Dictionary<string, Func<IFood>>
        {
            { "Glazed", () => new GlazedDonut() },
            { "Chocolate", () => new ChocolateDonut() }
        };

        public List<string> GetMenu()
        {
            return _donuts.Keys.ToList();
        }

        public IFood Create(string foodName)
        {
            return _donuts[foodName]();
        }
    }

    public class GlazedDonut : IFood
    {
        public string Eat()
        {
            return "It tastes disgustingly too much like sugar";
        }
    }

    public class ChocolateDonut : IFood
    {
        public string Eat()
        {
            return "This makes you feel like this is the greatest moment of your life";
        }
    }

    //This pattern allows you to even add behaviour without the rest of the app knowing and without this being coupled to the rest of the app
    //Check out these time based menus without modifying the interface
    public class FancyRestrauntFactory : IFoodFactory
    {
        private readonly Dictionary<string, Func<IFood>> _donuts = new Dictionary<string, Func<IFood>>
        {
            { "Déjeuner", () => new FancyBreakfast() },
            { "Le Déjeuner", () => new FancyLunch() },
            { "Dîner", () => new FancyDinner() }
        };


        public List<string> GetMenu()
        {
            var currentHour = DateTime.Now.Hour;
            if (currentHour >= 6 && currentHour < 12)
                return new List<string> { "Déjeuner" };
            if (currentHour >= 12 && currentHour < 5)
                return new List<string> { "Le Déjeuner" };
            return new List<string> { "Dîner" };
        }

        public IFood Create(string foodName)
        {
            return _donuts[foodName]();
        }
    }

    public class FancyBreakfast : IFood
    {
        public string Eat()
        {
            return "You'd believe there were drugs in the food with how addictive it is";
        }
    }

    public class FancyLunch : IFood
    {
        public string Eat()
        {
            return "It tastes like a normal lunch except with an extra 0 added to the bill";
        }
    }

    public class FancyDinner : IFood
    {
        public string Eat()
        {
            return "After eating that pretentious dinner you feel like you should judge people around you for being ill-mannered hooligans";
        }
    }

    //This pattern ensures that the implmentation and users of the food or food factory won't have to change because of each other
    //And makes testing easier
    //Don't use this when you don't need to swap out dependencies 
    //if you are only a donut place and not a food ordering place you probs don't need this extra seperation. 
    //you can just use the concrete DonutFactory

}
