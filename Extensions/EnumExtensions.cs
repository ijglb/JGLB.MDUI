using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumValue)
        {
            var enumType = enumValue.GetType();
            var enumName = Enum.GetName(enumType, enumValue);
            var fieldInfo = enumType.GetField(enumName);
            return fieldInfo.GetCustomAttribute<DescriptionAttribute>(true)?.Description ?? string.Empty;
        }
    }
}
