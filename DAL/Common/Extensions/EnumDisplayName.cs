using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DAL.Common.Extensions
{
    public static class EnumDisplayName
    {
        public static string GetEnumDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                        .GetMember(enumValue.ToString())
                        .First()
                        .GetCustomAttribute<DisplayAttribute>().Name;
        }
    }
}
