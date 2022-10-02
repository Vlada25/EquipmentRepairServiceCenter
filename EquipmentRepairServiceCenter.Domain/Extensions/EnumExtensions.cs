using EquipmentRepairServiceCenter.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

        public static EquipmentType SetEquipmentType(string typeStr)
        {
            if (!Enum.TryParse(typeStr, true, out EquipmentType equipmentType))
            {
                throw new Exception("Such type of equipment not found");
            }

            return equipmentType;
        }

        public static Position SetPosition(string positionStr)
        {
            if (!Enum.TryParse(positionStr, true, out Position position))
            {
                throw new Exception("Such position not found");
            }

            return position;
        }
    }
}
