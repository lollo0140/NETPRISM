# NET PRISM (.NET + SVELTE) WINDOWS
## .NET PRISM FRAMEWORK Template

A modern template for creating Desktop applications using **.NET (C#)** for the backend and **Svelte 5 + Vite** for the user interface, via WebView2.

## Project Structure

- `/backend`: C# logic exposed to the frontend via bridge.
- `/frontend/src`: Svelte source code (Vite).
- `/frontend/baked`: Compiled files ready to be loaded into the `BrowserWindow`.

## Prerequisites

- [.NET SDK 10+](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/) (for frontend build)
- [WebView2 Runtime](https://developer.microsoft.com/microsoft-edge/webview2/) (pre-installed on Windows 10/11)

## Getting Started

1.  **Install frontend dependencies**:
    ```bash
    cd frontend/src
    npm install
    ```

2.  **Run the project**:
    Open the `.sln` file with Visual Studio or run:
    ```bash
    dotnet run
    ```

## Features

- **Auto-Rebuild**: When running the app in DEBUG mode, .NET automatically executes `npm run build` if enabled in `Program.cs`.
- **Single File UI**: The frontend is compiled into a single HTML file for easy distribution.
- **C#/JS Bridge**: Call C# methods directly from Svelte using the `bridge` object.

## Configuration

- To hide the executable console, change `WinTools.WinTools.SetShowConsole(false);` in `backend/main.cs`.
- To disable automatic rebuild, set `bool rebuildUI = false;` in `Program.cs`.
