using EquipmentRepairServiceCenter.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EquipmentRepairServiceCenter.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(EquipmentType equipmentType)
        {
            Type type = equipmentType.GetType();
            var enumItem = type.GetField(equipmentType.ToString());
            var attribute = enumItem?.GetCustomAttribute<DisplayAttribute>();
            return attribute?.Name;
        }

        public static string GetDisplayName(Position position)
        {
            Type type = position.GetType();
            var enumItem = type.GetField(position.ToString());
            var attribute = enumItem?.GetCustomAttribute<DisplayAttribute>();
            return attribute?.Name;
        }

        public static EquipmentType SetEquipmentType(string typeStr, bool isDisplayName)
        {
            if (isDisplayName)
            {
                switch (typeStr)
                {
                    case "Refrigerator":
                        return EquipmentType.Refrigerator;
                    case "Coffee Machine":
                        return EquipmentType.CoffeeMachine;
                    case "Television":
                        return EquipmentType.Television;
                    case "Computer":
                        return EquipmentType.Computer;
                    case "Telephone":
                        return EquipmentType.Telephone;
                    case "Headphones":
                        return EquipmentType.Headphones;
                    case "Iron":
                        return EquipmentType.Iron;
                    case "Electric Kettle":
                        return EquipmentType.ElectricKettle;
                    default:
                        throw new Exception("Such type of equipment is not found");
                }
            }

            if (!Enum.TryParse(typeStr, true, out EquipmentType equipmentType))
            {
                throw new Exception("Such type of equipment is not found");
            }

            return equipmentType;
        }

        public static Position SetPosition(string positionStr, bool isDisplayName)
        {
            if (isDisplayName)
            {
                switch (positionStr)
                {
                    case "Engineer":
                        return Position.Engeneer;
                    case "System engineer":
                        return Position.SystemsEngineer;
                    case "Electronics engineer":
                        return Position.ElectronicsEngineer;
                    default:
                        throw new Exception("Such position is not found");
                }
            }

            if (!Enum.TryParse(positionStr, true, out Position position))
            {
                throw new Exception("Such positionis not found");
            }

            return position;
        }
    }
}
