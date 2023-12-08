using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace PogoRFU
{
    public class Main_Execution
    { 
        public static void Main(string[] args)
        {
            string basefolderpath = @"C:\Users\XxFallDrop86xX\AppData\Local\Roblox\Versions\";
            string extrafolder = "ClientSettings";
            byte[] jsonfilesourcebyte = Properties.Resources.ClientAppSettings;
            string jsonfilesource = Encoding.UTF8.GetString(jsonfilesourcebyte);
            string jsonfilefinal = "ClientAppSettings.json";

            /* Here we are going to detect the latest version of roblox installed on the system. Each subfolder with the random id name will be
            checked to see if it contains the roblox file 'robloxplayerbeta.exe'*/
            string latestRobloxVersionFolder = GetLatestVersionFolder(basefolderpath, "RobloxPlayerBeta.exe");

            if (!string.IsNullOrEmpty(latestRobloxVersionFolder))
            {
                Console.WriteLine("Roblox exists in the system...");

                string fullPath = Path.Combine(basefolderpath, latestRobloxVersionFolder);
                string extrafolderpath = Path.Combine(fullPath, extrafolder);

                if (Directory.Exists(extrafolderpath))
                {
                    Console.WriteLine("Capping Unlimited fps. Closing app in 3 seconds");
                    Thread.Sleep(3000);
                    File.WriteAllText(Path.Combine(extrafolderpath, jsonfilefinal), jsonfilesource);
                }
                else
                {
                    Directory.CreateDirectory(extrafolder);
                    Console.WriteLine("Capping Unlimited fps. Closing app in 3 seconds");
                    Thread.Sleep(3000);
                    Directory.CreateDirectory(extrafolderpath);
                    File.WriteAllText(Path.Combine(extrafolderpath, jsonfilefinal), jsonfilesource);
                }
                
            }
            else
            {
                Console.WriteLine("Roblox is not installed! Please install roblox first to use this app... Closing in 5 seconds");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }
        }

        private static string GetLatestVersionFolder(string baseFolderPath, string executableName)
        {
            try
            {
                // Get all version folders
                var versionFolders = Directory.GetDirectories(baseFolderPath);

                // Select the latest version folder based on the presence of the executable
                var latestVersionFolder = versionFolders
                    .OrderByDescending(f => f)
                    .FirstOrDefault(folder =>
                        Directory.GetFiles(folder, executableName, SearchOption.AllDirectories).Any()
                    );

                return Path.GetFileName(latestVersionFolder);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while detecting the latest version. Roblox installation probably corrupt: {ex.Message}");
                return null;
            }
        }
    }
}