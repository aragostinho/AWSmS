using System;
using System.ComponentModel;
using System.Reflection;

namespace AWSmS.Utils
{
    public static class ExtensionsMethods
    {

        public static bool IsNullOrEmpty(this string pString)
        {
            return string.IsNullOrEmpty(pString);
        }

        public static bool IsNumber(this string pString)
        {
            long n;
            bool isNumeric = long.TryParse(pString, out n);
            return isNumeric;
        }
        public static string GetDescription(this Enum enumObj)
        {
            if (enumObj == null)
                return string.Empty;

            FieldInfo fieldInfo = enumObj.GetType().GetField(enumObj.ToString());
            object[] attribArray = fieldInfo.GetCustomAttributes(false);

            for (int i = 0; i < attribArray.Length; i++)
            {
                if (attribArray[i].ToString().Contains("Description"))
                    return ((DescriptionAttribute)attribArray[i]).Description;
            }
            return string.Empty;
        }

    }
}
