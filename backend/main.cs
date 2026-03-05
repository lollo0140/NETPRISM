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

            //this is how to create a window, you can also specify a class that can be called by JS (the methods in the class must NOT be static) 

            

            string _htmlPath = Path.Combine(projPath, "frontend/baked/index.html");

            BrowserWindow mainWindow = new BrowserWindow(new BrowserWindowSettings
            {
                WindowTitle = ".NET PRISM demo",
                HTMLPath = _htmlPath,
                WindowStyle = BrowserWindow.NoTitleStyle,
                WindowIcon = new Icon(Path.Combine(projPath, "NETPRISM.ico")),
                MinHeight = 400,
                MinWidht = 650, 
            }, bridge: new Invokable());


            //do NOT remove this code unless the app is ready for release
            mainWindow.WebView.KeyDown += (s, e) =>
            {
                //this function will reload the ui when control + R is pressed
                if (e.Control && e.KeyCode == Keys.R)
                {
                    MyApp.Program.reloadUI(mainWindow, _htmlPath);
                }
            };
           


            //change the value of this line to hide or show the console when executed by the exe file.
            WinTools.WinTools.SetShowConsole(false);



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