using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace MyNet.Library.Excel
{
    /// <summary>
    /// 文件操作类
    /// </summary>
    public class FileHelper
    {
        public string ReadTxt(string path)
        {
            return File.ReadAllText(path, Encoding.UTF8);
        }

        public void CopyFile(string source ,string path)
        {
            File.Copy(source, path, true);
        }
    }
}
