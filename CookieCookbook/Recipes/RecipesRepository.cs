using CookieCookbook.Recipes.Ingredients;

namespace CookieCookbook.Recipes;

public class RecipesRepository : IRecipesRepository
{
    private readonly IStringsRepository _stringsTextualRepository;
    private readonly IIngredientsRegister _ingredientsRegister;

    public RecipesRepository(IIngredientsRegister ingredientsRegister, IStringsRepository stringsTextualRepository)
    {
        _ingredientsRegister = ingredientsRegister;
        _stringsTextualRepository = stringsTextualRepository;
    }

    private const string Separator = ",";

    public RecipesRepository(IStringsRepository stringsTextualRepository)
    {
        _stringsTextualRepository = stringsTextualRepository;
    }

    public List<Recipe> Read(string filepath)
    {
        List<string> recipesFromFile = _stringsTextualRepository.Read(filepath);
        var recipes = new List<Recipe>();
        foreach (var recipeFromFile in recipesFromFile)
        {
            var recipe = RecipeFromString(recipeFromFile);
            recipes.Add(recipe);

        }

        return recipes;
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        var textualIds = recipeFromFile.Split(Separator);
        var ingredients = new List<Ingredient>();

        foreach (var textualId in textualIds)
        {
            var id = int.Parse(textualId);
            var ingredient = _ingredientsRegister.GetById(id);
            ingredients.Add(ingredient);
        }

        return new Recipe(ingredients);
    }

    public void Write(string filepath, List<Recipe> allRecipes)
    {
        var recipesAsStrings = new List<string>();
        foreach (var recipe in allRecipes)
        {
            var allIds = new List<int>();
            foreach (var ingredient in recipe.Ingredients)
            {
                allIds.Add(ingredient.Id);
            }
            recipesAsStrings.Add(string.Join(Separator, allIds));
        }
        _stringsTextualRepository.Write(filepath, recipesAsStrings);
    }
}
