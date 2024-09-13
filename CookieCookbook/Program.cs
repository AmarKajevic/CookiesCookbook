using CookieCookbook.App;
using CookieCookbook.FileAccess;
using CookieCookbook.Recipes;
using CookieCookbook.Recipes.Ingredients;
using System.Text.Json;
var ingredintsRegister = new IngredientsRegister();

const FileFormat Format = FileFormat.Json;

IStringsRepository stringsRepository = Format == FileFormat.Json ?
    new StringsJsonRepository() :
    new StringsTextualRepository();

const string FileName = "recipes";
var fileMetadata = new FileMetadata(FileName, Format);

var cokiesRecipesApp = new CookiesRecipesApp(
    new RecipesRepository(
        ingredintsRegister,
        new StringsJsonRepository()
        ),
    new RecipesConsoleUserInteraction(
        ingredintsRegister));
cokiesRecipesApp.Run(fileMetadata.ToPath());




