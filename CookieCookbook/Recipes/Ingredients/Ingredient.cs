﻿namespace CookieCookbook.Recipes.Ingredients;

public abstract class Ingredient
{
    public abstract int Id { get; }
    public abstract string Name { get; }
    public virtual string PreparationInstruction => "Add to other ingredients";

    public override string ToString() =>
        $"{Id}. {Name}";
}
