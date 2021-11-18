using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Wardrobe_Program
{
    public class ControllerValidator
    {
        public Dictionary<string, (bool isRequired, bool needsParams)> AvailableKeys { get; set; } = new();

        public bool Validate(Command command) {
            if (command.Parameters.Count < GetNumRequiredParams()) {
                Logger.Instance.Error("Not enough parameters passed in!");
                return false;
            }

            foreach (var (key, value) in command.Parameters) {
                bool isValidKey = false;
                foreach (var (availableKey, valueTuple) in AvailableKeys) {
                    if (key != availableKey) continue;
                    if(value == "" && valueTuple.needsParams) {
                        Logger.Instance.Error($"Param {key} needs a value passed in!");
                        return false;
                    }
                    isValidKey = true;
                }
                if (isValidKey) continue;
                Logger.Instance.Error($"Param {key} needs a value passed in!");
                return false;
            }

            return true;
        }

        private int GetNumRequiredParams() {
            int result = 0;
            foreach (var availableKey in AvailableKeys) {
                if (availableKey.Value.needsParams) {
                    result++;
                }
            }

            return result;
        }
    }
}