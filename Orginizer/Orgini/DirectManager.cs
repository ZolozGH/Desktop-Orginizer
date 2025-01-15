using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orginigger
{
    internal class DirectManager
    {

        public static void OrganizeFolder(string folderPath)
        {
            try
            {
                var fileCategories = new Dictionary<string, string>
            {
                { ".mp3", "Music" },
                { ".wav", "Music" },
                { ".flac", "Music" },
                { ".jpg", "Pictures" },
                { ".jpeg", "Pictures" },
                { ".png", "Pictures" },
                { ".webp", "Pictures" },
                { ".PNG", "Pictures" },
                { ".gif", "Pictures" },
                { ".bmp", "Pictures" },
                { ".txt", "Documents" },
                { ".pdf", "Documents" },
                { ".doc", "Documents" },
                { ".docx", "Documents" },
                { ".xls", "Documents" },
                { ".xlsx", "Documents" },
                { ".ppt", "Documents" },
                { ".pptx", "Documents" },
                { ".mp4", "Videos" },
                { ".mkv", "Videos" },
                { ".avi", "Videos" },
                { ".mov", "Videos" },
                { ".wmv", "Videos" },
                { ".zip", "Zip_Files" },
                { ".rar", "Rar_Files" },
                //{ ".h", "Ziprectories" },
                { ".dll", "Dll_Files" },
                { ".exe", "Executables" },
                { ".lnk", "Shortcuts" }
            };

                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string videosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string picturesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                string musicPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

                string ziprectoriesPath = Path.Combine(desktopPath, "Ziprectories");
                string dynamicLLPath = Path.Combine(desktopPath, "DynamicLL");
                string executablesPath = Path.Combine(desktopPath, "Executables");
                string shortcutsPath = Path.Combine(desktopPath, "Shortcuts");
                string junkPath = Path.Combine(documentsPath, "Junk");

                if (!Directory.Exists(folderPath))
                {
                    Console.WriteLine("The specified folder does not exist: " + folderPath);
                    return;
                }

                foreach (var filePath in Directory.GetFiles(folderPath))
                {
                    string extension = Path.GetExtension(filePath).ToLower();
                    string targetFolder;

                    if (fileCategories.TryGetValue(extension, out string category))
                    {
                        switch (category)
                        {
                            case "Music":
                                targetFolder = musicPath;
                                break;
                            case "Pictures":
                                targetFolder = picturesPath;
                                break;
                            case "Documents":
                                targetFolder = documentsPath;
                                break;
                            case "Videos":
                                targetFolder = videosPath;
                                break;
                            case "Ziprectories":
                                targetFolder = ziprectoriesPath;
                                break;
                            case "DynamicLL":
                                targetFolder = dynamicLLPath;
                                break;
                            case "Executables":
                                targetFolder = executablesPath;
                                break;
                            case "Shortcuts":
                                targetFolder = shortcutsPath;
                                break;
                            default:
                                targetFolder = junkPath;
                                break;
                        }
                    }
                    else
                    {
                        targetFolder = junkPath;
                    }

                    if (!Directory.Exists(targetFolder))
                    {
                        Directory.CreateDirectory(targetFolder);
                    }

                    string targetPath = Path.Combine(targetFolder, Path.GetFileName(filePath));
                    File.Move(filePath, targetPath);

                    Console.WriteLine($"Moved {filePath} to {targetPath}");
                }

                Console.WriteLine("Folder organization complete.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while organizing the folder: " + ex.Message);
            }
        }

        public static void CreateFolder(string path, string folderName)
        {
            try
            {
                string fullPath = Path.Combine(path, folderName);
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                    Console.WriteLine("Folder created successfully at: " + fullPath);
                }
                else
                {
                    Console.WriteLine("Folder already exists at: " + fullPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while creating the folder: " + ex.Message);
            }
        }
    }
}
