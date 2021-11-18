using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Wardrobe_Program
{
    public class CreateGarmentController : AbstractController
    {
        private readonly IDao<Garment> _garmentDao;
        private readonly List<GarmentFactory> _availableFactories;
        public CreateGarmentController(IDao<Garment> garmentDao, List<GarmentFactory> availableFactories) 
            : base("Creates a new garment and adds it to the database") {
            _garmentDao = garmentDao;
            _availableFactories = availableFactories;
        }

        public override void Handle(Command command) {
            UserInterface.Instance.Print("Select garment type:");
            for (int i = 0; i < _availableFactories.Count; i++) {
                UserInterface.Instance.Print($"ID: {i} - {_availableFactories[i].GarmentType}");
            }

            var cleanedInputId = Utils.RemoveNonDigits(UserInterface.Instance.ReadLine());
            if (cleanedInputId.Length is < 0 or > 5 ) {
                UserInterface.Instance.Print("Looks like someone's being cheeky... This isn't a valid id, is it?", ConsoleColor.DarkRed);
                return;
            }
            int garmentId = Convert.ToInt32(cleanedInputId);
            garmentId = Math.Clamp(garmentId, 0, _availableFactories.Count -1);
            
            var newGarment = _availableFactories[garmentId].CreateGarment();

            UserInterface.Instance.Print("Enter name:");
            newGarment.Name = UserInterface.Instance.ReadLine();

            UserInterface.Instance.Print("Enter price:");
            var cleanedPrice = Utils.RemoveNonDigits(UserInterface.Instance.ReadLine());
            
            if (cleanedPrice.Length == 0)
            {
                UserInterface.Instance.Print("Not a valid price!");
                return;
            }
            newGarment.Price = Convert.ToSingle(cleanedPrice);

            UserInterface.Instance.Print("Enter size:");
            newGarment.Size = UserInterface.Instance.ReadLine();

            UserInterface.Instance.Print("Enter brand:");
            newGarment.Brand = UserInterface.Instance.ReadLine();

            _garmentDao.Insert(newGarment);
            UserInterface.Instance.Print($"New garment is: {newGarment}");
        }

        protected override ControllerValidator GetControllerValidator() {
            return new ControllerValidator
            {
                AvailableKeys = new()
            };
        }
    }
}