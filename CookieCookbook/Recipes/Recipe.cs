﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieCookbook.Recipes.Ingredients;

namespace CookieCookbook.Recipes;

public  class Recipe
{
    public IEnumerable<Ingredient> Ingredients { get;  }
    public Recipe(IEnumerable<Ingredient> ingredients)
    {
        Ingredients = ingredients;
    }
    public override string ToString()
    {
        var steps = new List<string>();
        foreach(var ingredient in Ingredients)
        {
            steps.Add($"{ingredient.Name}. {ingredient.PreparationInstruction}");
        }
        return string.Join(Environment.NewLine, steps);
    }
}
