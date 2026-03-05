using NetBrowserWindow;
using winCreator;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using App;

namespace MyApp
{
    public class Program
    {


        //use the file main.cs in the backend folder as starting point
        //make changes here only if you need to change startup behevior

        static string GetSourceDirectory([CallerFilePath] string path = "") => Path.GetDirectoryName(path)!;

        //thes functions will start the command 'npm run build' to rebuild the interface
        public static void reloadUI(BrowserWindow window, string path)
        {
            window.Window!.Opacity = 0.5;
            buildUI();

            window.WebView.CoreWebView2.Navigate(path);

            window.Window!.Opacity = 1;
        }

        public static void buildUI()
        {
            string command = $"/c cd /d \"{Path.Combine(GetSourceDirectory(), "frontend/src")}\" && npm run build";

            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = command,
                CreateNoWindow = false,
                UseShellExecute = false
            })?.WaitForExit();
        }



        [STAThread]
        static void Main(string[] args)
        {

            Console.Clear();

#if DEBUG
            //default vite will rebuild the frontend
            //you change this value if you want to turn off this function
            bool rebuildUI = true;
            if (rebuildUI)
            {
                buildUI();
            }
            System.Console.WriteLine("-----------App starting-----------");
#endif
            App.App.main(GetSourceDirectory());
            //------------------------------------------
            //everithing you write here will NOT execute
            //move to the 'main.cs' file
        }
    }
}