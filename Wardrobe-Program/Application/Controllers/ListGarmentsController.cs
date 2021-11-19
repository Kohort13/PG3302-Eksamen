using System;
using System.Collections.Generic;

namespace Wardrobe_Program
{
    class ListGarmentsController : AbstractController
    {
        private readonly IDao<IGarment> _availableGarments;

        public ListGarmentsController(IDao<IGarment> availableGarments) : base("Lists the available garments") {
            _availableGarments = availableGarments;
        }

        public override void Handle(Command command) {
            if (!ValidateCommand(command)) return;
            if (command.Parameters.Keys.Count == 0) {
                var garments = _availableGarments.ListAll();
                foreach (var garment in garments) {
                    UserInterface.Instance.Print($"{garment}");
                }
            }
            else {
                List<Predicate<IGarment>> matchers = new();
                if (command.Parameters.ContainsKey("-stype")) {
                    matchers.Add(g => g.Subtype.Contains(command.Parameters["-stype"]));
                } if (command.Parameters.ContainsKey("-brand")) {
                    matchers.Add(g => g.Brand.Contains(command.Parameters["-brand"]));
                } if (command.Parameters.ContainsKey("-size")) {
                    matchers.Add(g => g.Size.Contains(command.Parameters["-size"]));
                } if (command.Parameters.ContainsKey("-note")) {
                    matchers.Add(g => g.Note.Contains(command.Parameters["-note"]));
                } if (command.Parameters.ContainsKey("-id")) {
                    try {
                        matchers.Add(g => g.Id == Convert.ToInt64(command.Parameters["-id"]));
                    } catch(Exception){
                        UserInterface.Instance.Print("Invalid ID passed in!");
                    }
                }

                if (command.Parameters.ContainsKey("-price"))
                {
                    int firstDigitPos = command.Parameters["-price"].IndexOfAny(new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
                    string sign = command.Parameters["-price"].Substring(0, firstDigitPos);
                    float number;
                    try
                    {
                        number = Convert.ToSingle(command.Parameters["-price"].Substring(firstDigitPos));
                    }
                    catch (Exception)
                    {
                        UserInterface.Instance.Print("Invalid number");
                        return;
                    }
                    if (sign.Contains(">")) {
                        matchers.Add(g => g.Price > number);
                    } else if (sign.Contains("<")) {
                        matchers.Add(g => g.Price < number);
                    }  else if (sign.Contains(">=")) {
                        matchers.Add(g => g.Price >= number);
                    } else if (sign.Contains("<=")) {
                        matchers.Add(g => g.Price <= number);
                    }
                }

                var garments = _availableGarments.ListSome(matchers.ToArray());
                foreach (var garment in garments)
                {
                    UserInterface.Instance.Print($"{garment}");
                }
            }
        }

        public override void Help(Command command)
		{
			UserInterface.Instance.Print("Use list-garments to see a complete list of all available garments");
            UserInterface.Instance.Print("Params to specify: -stype <filter by given subtype> " +
				"-brand <filter by given brand> -size <filter by given size> -sp/-su/-fa/-au/-wi <filter by given season> " +
				"-price > or -price < <filter by values greater than or less than given price>" +
				"-note <filter by given note>");
        }

		protected override ControllerValidator GetControllerValidator() {
            return new ControllerValidator
            {
                AvailableKeys = new()
                {
                    {"-stype",(false, true)},
                    {"-price",(false, true)},
                    {"-size",(false, true)},
                    {"-id",(false, true)},
                    { "-note", (false, true) },
                    { "-brand",(false, true)}
                }
            };
        }
    }
}