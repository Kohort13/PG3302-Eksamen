using System;

namespace Wardrobe_Program
{
    class WardrobeApplication
    {
        static void Main(string[] args) {
            Application app = new();
            MockDao data = MockDao.GetPopulatedTestDatabase();

            app.AddController("list-controllers", new ListCommandsController(app.Controllers));
            app.AddController("change-name", new ChangeNameController(data));
            app.AddController("change-price", new ChangePriceController(data));
			app.AddController("change-size", new ChangeSizeController(data));
			app.AddController("change-brand", new ChangeBrandController(data));
			app.AddController("change-season", new ChangeSeasonController(data));
			app.AddController("list-garments", new ListGarmentsController(data));
			app.AddController("cls", new ClearScreenController());
            app.AddController("exit", new QuitController(app));

            app.RunApplication();
        }
    }
}
