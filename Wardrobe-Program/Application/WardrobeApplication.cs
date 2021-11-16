using System;

namespace Wardrobe_Program
{
    class WardrobeApplication
    {
        static void Main(string[] args) {
            Application app = new();
            MockDatabase data = new();

            app.AddController("change-colour", new ChangeNameController(data));
            app.AddController("list-controllers", new ListCommandsController(app.Controllers));

            app.RunApplication();
        }
    }
}
