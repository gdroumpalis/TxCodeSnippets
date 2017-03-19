using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TxVisualStudioSnippetCreatorandTester
{

    class Program
    {

        

        static readonly string source = @"C:\Users\TerminuX\Desktop\TxCodeSnippets\TxVisualStudioSnippetCreatorandTester\TxVisualStudioSnippetCreatorandTester\Snippets";
        //static readonly string dest = @"C:\Users\TerminuX\Documents\Visual Studio 2015\Code Snippets\Visual C#\My Code Snippets";
        static readonly string dest = @"C:\Users\TerminuX\Documents\Visual Studio 2017\Code Snippets\Visual C#\My Code Snippets";
        static void Main(string[] args)
        {
            CleanSnippetsFolder(dest);
            DirectoryCopy(source, dest, true);

        }
        
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }

        }


        private static void CleanSnippetsFolder(string sourceDirName)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            foreach (var it in Directory.GetDirectories(sourceDirName))
            {
                try
                {
                    Directory.Delete(it, true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

        }

    }
}

namespace Test
{

}


