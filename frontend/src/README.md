# .NET PRISM - Frontend (Svelte 5)

This folder contains the Svelte source code for the .NET PRISM UI.

## Development

1. Install dependencies:
   ```bash
   npm install
   ```

2. Start dev server (Vite):
   ```bash
   npm run dev
   ```

## Build

When you run the .NET application in DEBUG mode, it will automatically build this project and output the result to `../baked`.

To build manually:
```bash
npm run build
```

The output will be a single-file `index.html` located in `../baked`.
