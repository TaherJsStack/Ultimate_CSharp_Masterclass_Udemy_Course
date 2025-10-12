

using CookiesCookbookCSharpAssignment.App;
using CookiesCookbookCSharpAssignment.DataAccess;
using CookiesCookbookCSharpAssignment.DataAccess.FileAccess;
using CookiesCookbookCSharpAssignment.Recipes;
using CookiesCookbookCSharpAssignment.Recipes.Ingredients;

const FileFormat fileFormat = FileFormat.txt;
const string FileName = "Recipes";

var fileMetaData = new FileMetaData(FileName, fileFormat);

IStringsRepository stringsRepository = fileFormat == FileFormat.json ? 
    new StringsJsonRepository() : 
    new StringsTextualRepository();

IIngredientsRegister ingredientsRegister = new IngredientsRegister();
var cookiesRecipesApp = new CookiesRecipesApp(
   new RecipesRepository(stringsRepository, ingredientsRegister),
   new RecipesConsoleUserInteraction( ingredientsRegister ));
//cookiesRecipesApp.Initialize();
cookiesRecipesApp.Run(fileMetaData.ToPath());

