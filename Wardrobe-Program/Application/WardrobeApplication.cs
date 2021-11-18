using System.Collections.Generic;

namespace Wardrobe_Program
{
    class WardrobeApplication
    {
        static void Main(string[] args) {
            Application app = new();
            MockDao data = MockDao.GetPopulatedTestDatabase();
            List<GarmentFactory> factories = new List<GarmentFactory>();
            factories.Add(new AccessoryFactory());
            factories.Add(new BottomFactory());
            factories.Add(new TopFactory());
            factories.Add(new ShoeFactory());
            factories.Add(new OuterwearFactory());

            app.AddController("new-garment", new CreateGarmentController(data, factories));
            app.AddController("change-name", new ChangeNameController(data));
            app.AddController("change-price", new ChangePriceController(data));
			app.AddController("change-size", new ChangeSizeController(data));
			app.AddController("change-brand", new ChangeBrandController(data));
			app.AddController("change-season", new ChangeSeasonController(data));
			app.AddController("list-garments", new ListGarmentsController(data));
            app.AddController("--help", new ListCommandsController(app.Controllers));
            app.AddController("cls", new ClearScreenController());
            app.AddController("exit", new QuitController(app));

            app.RunApplication();
        }
    }
}
