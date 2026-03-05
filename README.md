# .NET PRISM FRAMEWORK Template

Un template moderno per creare applicazioni Desktop utilizzando **.NET (C#)** per il backend e **Svelte 5 + Vite** per l'interfaccia utente, tramite WebView2.

## Struttura del Progetto

- `/backend`: Logica C# esposta al frontend via bridge.
- `/frontend/src`: Codice sorgente Svelte (Vite).
- `/frontend/baked`: File compilati pronti per essere caricati nel `BrowserWindow`.

## Prerequisiti

- [.NET SDK 10+](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/) (per la build del frontend)
- [WebView2 Runtime](https://developer.microsoft.com/microsoft-edge/webview2/) (già presente in Windows 10/11)

## Come Iniziare

1.  **Installa le dipendenze frontend**:
    ```bash
    cd frontend/src
    npm install
    ```

2.  **Avvia il progetto**:
    Apri il file `.sln` con Visual Studio o esegui:
    ```bash
    dotnet run
    ```

## Caratteristiche

- **Auto-Rebuild**: Quando avvi l'app in modalità DEBUG, .NET esegue automaticamente `npm run build` se abilitato in `Program.cs`.
- **Single File UI**: Il frontend viene compilato in un unico file HTML per facilità di distribuzione.
- **Bridge C#/JS**: Chiama metodi C# direttamente da Svelte usando l'oggetto `bridge`.

## Configurazione

- Per nascondere la console dell'eseguibile, cambia `WinTools.WinTools.SetShowConsole(false);` in `backend/main.cs`.
- Per disabilitare il rebuild automatico, imposta `bool rebuildUI = false;` in `Program.cs`.
