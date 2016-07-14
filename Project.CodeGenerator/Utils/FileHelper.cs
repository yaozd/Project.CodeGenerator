using System;
using System.IO;
using System.Text;

namespace Project.CodeGenerator.Utils
{
    public class FileHelper
    {
        private static readonly string Path = AppPath();
        /// <summary>
        /// 文件读取
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string Read(string fileName)
        {
            return Read(fileName, Encoding.GetEncoding("utf-8"));
        }
        /// <summary>
        /// 文件读取
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Read(string fileName, Encoding encoding)
        {
            var filePath = System.IO.Path.Combine(Path, fileName);
            return File.ReadAllText(filePath, encoding);
        }
        /// <summary>
        /// 文件保存
        /// </summary>
        /// <param name="path"></param>
        /// <param name="result"></param>
        public static void Save(string path, Byte[] result)
        {
            var index = path.LastIndexOf(@"\", StringComparison.Ordinal);
            var dir = path.Substring(0, index);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                for (int i = 0; i < result.Length; i++)
                {
                    fileStream.WriteByte(result[i]);
                }
            }
        }

        public static void Save(string path, string input)
        {
            byte[] inputBytes = System.Text.Encoding.GetEncoding("utf-8").GetBytes(input);
            Save(path, inputBytes);
        }

        private static string AppPath()
        {
            return System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        }
    }
}