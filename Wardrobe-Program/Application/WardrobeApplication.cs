﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Wardrobe_Program
{
    class WardrobeApplication
    {
        static void Main(string[] args) {
            Application app = new();
            MockDao data = MockDao.GetPopulatedTestDatabase();
            var factories = new List<GarmentFactory>
            {
                new AccessoryFactory(),
                new BottomFactory(),
                new TopFactory(),
                new ShoeFactory(),
                new OuterwearFactory()
            };

            app.AddController("new-garment", new CreateGarmentController(data, factories));
            app.AddController("delete-garment", new DeleteGarmentController(data));

            app.AddController("add-material", new AddMaterialController(data));
            app.AddController("delete-material", new DeleteMaterialController(data));
            app.AddController("list-colours", new ListColourController());
            app.AddController("change-subtype", new ChangeSubtypeController(data));
            app.AddController("change-price", new ChangePriceController(data));
			app.AddController("change-size", new ChangeSizeController(data));
			app.AddController("change-brand", new ChangeBrandController(data));
			app.AddController("change-season", new ChangeSeasonController(data));
            app.AddController("change-note", new ChangeNoteController(data));
			app.AddController("list-garments", new ListGarmentsController(data));

            app.AddController("say-hello", new SayHelloController(app));

            app.AddController("--help", new ListCommandsController(app.Controllers));
            app.AddController("cls", new ClearScreenController());
            app.AddController("exit", new QuitController(app));

            Task mainLoop = Task.Run(() => app.RunApplication());
            mainLoop.Wait();
        }
    }
}
