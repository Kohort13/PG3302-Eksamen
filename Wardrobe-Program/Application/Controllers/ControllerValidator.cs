using System;
using System.Collections.Generic;

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
            foreach (var availableKey in AvailableKeys)
            {
                bool isValidKey = false;
                foreach (var kvPair in command.Parameters)
                {
                    if (kvPair.Key == availableKey.Key)
                    {
                        if (kvPair.Value == "" && availableKey.Value.needsParams)
                        {
                            Logger.Instance.Error($"Param {kvPair.Key} needs a value passed in!");
                            return false;
                        }
                        isValidKey = true;
                    }
                }
                if (!isValidKey)
                {
                    Logger.Instance.Error("Incorrect format of command!");
                }
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