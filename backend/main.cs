using System.Runtime.InteropServices;
using System.Text.Json.Nodes;
using winCreator;

namespace App
{
    [ComVisible(true)]
    public class Invokable
    {
        public string returnDate()
        {
            var date = DateTime.Today;

            return date.ToString();
        }
    }

    class App
    {
        public static void main(string projPath)
        {


#if DEBUG
            //start the vite server for debug
            MyApp.Program.startServerNPM(Path.Combine(projPath, "frontend/src"));
#endif



            //this is how to create a window, you can also specify a class that can be called by JS (the methods in the class must NOT be static) 
            string _htmlPath = Path.Combine(projPath, "frontend/baked/index.html");

            BrowserWindow mainWindow = new BrowserWindow(new BrowserWindowSettings
            {
                WindowTitle = ".NET PRISM demo",
                WindowStyle = BrowserWindow.NoTitleStyle,
                WindowIcon = new Icon(Path.Combine(projPath, "NETPRISM.ico")),
                MinHeight = 400,
                MinWidth = 650,
                CanClose = true,
#if DEBUG
                HTMLPath = "http://localhost:5173/",
#else
                HTMLPath = _htmlPath,
#endif
            }, bridge: new Invokable());


            //change the value of this line to hide or show the console when executed by the exe file.
            //WinTools.WinTools.SetShowConsole(false);


            //ipc test
            mainWindow.WebView.KeyDown += (s, e) =>
            {
                JsonObject P = new JsonObject();

                P["text"] = e.KeyData.ToString();

                mainWindow.callVoidFunc("ipctest", P);
            };



            //this is how you can run the app 
            //you can also use 'mainWindow.Window.show()'
            //and use 'Application.Run()' whitout passing the window
            //if you want a multi window application
            Application.Run(mainWindow.Window!);
        }
    }
}