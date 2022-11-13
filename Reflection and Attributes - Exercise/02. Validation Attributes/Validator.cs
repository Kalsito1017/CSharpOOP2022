
namespace ValidationAttributes
{
using System.Linq;
using System.Reflection;
    public class Validator
    {
        public static bool IsValid(object obj) //Person, Name, Age
        {
            PropertyInfo[] propertyInfos = obj               
                .GetType() //Person
                .GetProperties() //Name, Age, Salary
                .Where(t => t.GetCustomAttributes(typeof(MyValidationAttribute)).Any()) //Name, Age, Salary
                .ToArray();  //PropertyInfo[]

            foreach (PropertyInfo item in propertyInfos) //Name, Age
            {
                var value = item.GetValue(obj); // object "Kalsito", then 40
                var attribute = item //Name->MyValidationAttribute
                    .GetCustomAttribute<MyValidationAttribute>(); // Age -> MyValidationAttribute
                bool isValid = attribute.IsValid(value); // MyRequiredAttribute -> IsValid
                if (!isValid)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
