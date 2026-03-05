import { defineConfig } from 'vite'
import { svelte } from '@sveltejs/vite-plugin-svelte'
import { viteSingleFile } from "vite-plugin-singlefile"
import path from 'path'
import { fileURLToPath } from 'url'

const __filename = fileURLToPath(import.meta.url)
const __dirname = path.dirname(__filename)

// https://vite.dev/config/
export default defineConfig({
  plugins: [svelte(), viteSingleFile()],
  build: {
    outDir: '../baked',
    emptyOutDir: true
  },
  resolve: {
    alias: {
      'jsBridge': path.resolve(__dirname, './src/bridge/bridge.js')
    }
  }
})
