using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp41
{
    public class Burger
    {
        public Component BaseComponent { get; set; }
        public Component SecondComponent { get; set; }
        public Component ThirdComponent { get; set; }
        public Component FourthComponent { get; set; }

        public override string ToString()
        {
            return $"Бургер. Состав: {BaseComponent} {SecondComponent} {ThirdComponent} {FourthComponent} ";
        }
    }

    public abstract class Component
    {
    }

    public class Булочка : Component
    {
    }

    public class ЧерствыйХлеб : Component
    {
    }

    public class Соус : Component
    {
    }

    public class Паучок : Component
    {
    }

    public class Котлета : Component
    {
    }

    public class КотлетаКошка : Component
    {
    }

    public class Кипченез : Component
    {
    }

    public class BurgerBuilder
    {
        Burger burger;

        public BurgerBuilder()
        {
            burger = new Burger();
        }

        public BurgerBuilder AddBread()
        {
            burger.BaseComponent = new Булочка();
            return this;
        }

        public BurgerBuilder AddBadBread()
        {
            burger.BaseComponent = new ЧерствыйХлеб();
            return this;
        }

        public BurgerBuilder AddSauce()
        {
            burger.ThirdComponent = new Соус();
            return this;
        }

        public BurgerBuilder AddBadSauce()
        {
            burger.ThirdComponent = new Кипченез();
            return this;
        }

        public BurgerBuilder AddCutlet()
        {
            burger.SecondComponent = new Котлета();
            return this;
        }

        public BurgerBuilder AddBadCutlet()
        {
            burger.SecondComponent = new КотлетаКошка();
            return this;
        }

        public BurgerBuilder AddSecredIngredient()
        {
            burger.FourthComponent = new Паучок();
            return this;
        }

        public Burger GetResult()
        {
            return burger;
        }

        public BurgerBuilder Clear()
        {
            burger = new Burger();
            return this;
        }
    }

    public class Cooker
    {
        private readonly BurgerBuilder burgerBuilder;

        public Cooker(BurgerBuilder burgerBuilder)
        {
            this.burgerBuilder = burgerBuilder;
        }

        public Burger CookBurger()
        {
            return burgerBuilder
                .Clear()
                .AddBread()
                .AddCutlet()
                .AddSauce()
                .GetResult();
        }
    }

    public class BadCooker
    {
        private readonly BurgerBuilder burgerBuilder;

        public BadCooker(BurgerBuilder burgerBuilder)
        {
            this.burgerBuilder = burgerBuilder;
        }

        public Burger CookBurger()
        {
            return burgerBuilder
                .AddBadBread()
                .AddBadCutlet()
                .AddBadSauce()
                .AddSecredIngredient()
                .GetResult();
        }
    }

}
