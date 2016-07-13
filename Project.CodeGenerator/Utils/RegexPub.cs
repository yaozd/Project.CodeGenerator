using System.Text.RegularExpressions;

namespace Project.CodeGenerator.Utils
{
    public class RegexPub
    {
        public static Regex H1()
        {
            return new Regex(@"<h1>|</h1>", RegexOptions.Compiled);
        }
        public static Regex H2()
        {
            return new Regex(@"<h2>|</h2>", RegexOptions.Compiled);
        }
    }
}