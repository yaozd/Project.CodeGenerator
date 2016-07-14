using System.Text.RegularExpressions;

namespace Project.CodeGenerator.Utils
{
    public class RegexPub
    {
        public static Regex H1()
        {
            return new Regex(@"<h1>[\s]*|</h1>[\s]*", RegexOptions.Compiled);
        }
        public static Regex H2()
        {
            return new Regex(@"<h2>[\s]*|</h2>[\s]*", RegexOptions.Compiled);
        }
    }
}