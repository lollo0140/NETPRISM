using NetBrowserWindow;
using winCreator;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using App;

namespace MyApp
{
    public class Program
    {
        
        public static async void startServerNPM(string path)
        {
            string command = $"/c cd /d \"{path}\" && npm run dev";

            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = command,
                CreateNoWindow = false,
                UseShellExecute = false
            });
        }


        //use the file main.cs in the backend folder as starting point
        //make changes here only if you need to change startup behevior

        static string GetSourceDirectory([CallerFilePath] string path = "") => Path.GetDirectoryName(path)!;

        [STAThread]
        static void Main(string[] args)
        {

#if DEBUG
            Console.Clear();
#endif

#if DEBUG
            //default vite will rebuild the frontend
            //you change this value if you want to turn off this function
            System.Console.WriteLine("-----------App starting-----------");
#endif
            App.App.main(GetSourceDirectory());
            //------------------------------------------
            //everithing you write here will NOT execute
            //move to the 'main.cs' file
        }
    }
}