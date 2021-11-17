using System;

namespace Wardrobe_Program
{
    class WardrobeApplication
    {
        static void Main(string[] args) {
            Application app = new();
            MockDatabase data = new();

            ShoeFactory shoeFactory = new();
            data.Insert(shoeFactory.CreateGarment());

            app.AddController("change-name", new ChangeNameController(data));
            app.AddController("list-controllers", new ListCommandsController(app.Controllers));
			app.AddController("change-price", new ChangePriceController(data));
			app.AddController("change-size", new ChangeSizeController(data));
			app.AddController("change-brand", new ChangeBrandController(data));
			app.AddController("change-season", new ChangeSeasonController(data));

            app.RunApplication();
        }
    }
}
