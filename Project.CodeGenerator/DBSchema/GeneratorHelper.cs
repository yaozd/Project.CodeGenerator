namespace Project.CodeGenerator.DBSchema
{
    public class GeneratorHelper
    {
        public static readonly string StringType = "String";
        public static readonly string DateTimeType = "DateTime";
        public static string GetQuesMarkByType(string typeName)
        {
            string result = typeName;
            if (typeName == DateTimeType)
            {
                result += "?";
            }
            return result;
        }
    }
}