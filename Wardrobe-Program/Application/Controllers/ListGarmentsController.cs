using System;
using System.Collections.Generic;

namespace Wardrobe_Program
{
    class ListGarmentsController : AbstractController
    {
        private readonly IDao<Garment> _availableGarments;

        public ListGarmentsController(IDao<Garment> availableGarments) : base("Lists the available garments") {
            _availableGarments = availableGarments;
        }

        public override void Handle(Command command) {
            if (!ValidateCommand(command)) return;
            if (command.Parameters.Keys.Count == 0) {
                var garments = _availableGarments.ListAll();
                foreach (var garment in garments)
                {
                    UserInterface.Instance.Print($"{garment}");
                }
            }
            else {
                List<Predicate<Garment>> matchers = new();
                if (command.Parameters.ContainsKey("-type")) {
                    matchers.Add(g => g.Subtype.Contains(command.Parameters["-type"]));
                } if (command.Parameters.ContainsKey("-brand")) {
                    matchers.Add(g => g.Brand.Contains(command.Parameters["-brand"]));
                } if (command.Parameters.ContainsKey("-size")) {
                    matchers.Add(g => g.Size.Contains(command.Parameters["-size"]));
                } if (command.Parameters.ContainsKey("-note")) {
                    matchers.Add(g => g.Note.Contains(command.Parameters["-note"]));
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

        protected override ControllerValidator GetControllerValidator() {
            return new ControllerValidator
            {
                AvailableKeys = new()
                {
                    {"-type",(false, true)},
                    {"-price",(false, true)},
                    {"-size",(false, true)},
                    {"-brand",(false, true)}
                }
            };
        }
    }
}