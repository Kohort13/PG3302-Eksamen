using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Wardrobe_Program
{
    public class CreateGarmentController : AbstractController
    {
        private readonly IDao<IGarment> _garmentDao;
        private readonly List<GarmentFactory> _availableFactories;
        public CreateGarmentController(IDao<IGarment> garmentDao, List<GarmentFactory> availableFactories) 
            : base("Creates a new garment and adds it to the database") {
            _garmentDao = garmentDao;
            _availableFactories = availableFactories;
        }

        public override void Handle(Command command) {
            UserInterface.Instance.Print("Select garment type:");
            for (int i = 0; i < _availableFactories.Count; i++) {
                UserInterface.Instance.Print($"ID: {i} - {_availableFactories[i].GarmentType}");
            }

            int typeId;
            try {
                typeId = Convert.ToInt32(UserInterface.Instance.ReadLine());
                typeId = Math.Clamp(typeId, 0, _availableFactories.Count - 1);
            } catch (Exception) {
                UserInterface.Instance.Print("Looks like someone's being cheeky... This isn't a valid id, is it?", ConsoleColor.DarkRed);
                return;
            }

            var newGarment = _availableFactories[typeId].CreateGarment();

            UserInterface.Instance.Print("Enter name:");
            newGarment.Subtype = UserInterface.Instance.ReadLine();

            UserInterface.Instance.Print("Enter price:");
            float price;
            try {
                price = Convert.ToSingle(UserInterface.Instance.ReadLine());
            }
            catch (Exception) {
                UserInterface.Instance.Print("That's not a valid price...", ConsoleColor.DarkRed);
                return;
            }
            newGarment.Price = Convert.ToSingle(price);

            UserInterface.Instance.Print("Enter size:");
            newGarment.Size = UserInterface.Instance.ReadLine();

            UserInterface.Instance.Print("Enter brand:");
            newGarment.Brand = UserInterface.Instance.ReadLine();

            _garmentDao.Insert(newGarment);
            UserInterface.Instance.Print($"New garment is: {newGarment}");
        }

        public override void Help(Command command) {
            UserInterface.Instance.Print("Takes you through the steps of creating a new garment. Is ez-pz-lm-sqzy :)");
        }

        protected override ControllerValidator GetControllerValidator() {
            return new ControllerValidator
            {
                AvailableKeys = new()
            };
        }
    }
}