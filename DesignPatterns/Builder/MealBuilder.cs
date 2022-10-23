﻿using Builder.BurgerTypes;
using Builder.Drinktypes;

namespace Builder;

public class MealBuilder
{
    public Meal PrepareVegMeal (){
        var meal = new Meal();
        meal.AddItem(new VeganBurger());
        meal.AddItem(new Coke());
        return meal;
    }   

    public Meal PrepareNonVegMeal (){
        var meal = new Meal();
        meal.AddItem(new ChickenBurger());
        meal.AddItem(new Pepsi());
        return meal;
    }
}