<script>
    import bridge from "jsBridge";
    import { onMount } from "svelte";
    import { fade, fly } from "svelte/transition";

    let date = $state(""); 

    let logs = $state([
        "PRISM Engine v1.0.4 initialized",
        "Secure bridge established with .NET Host",
        "Listening for IPC handles...",
    ]);

    onMount(() => {
        bridge.RegisterHandle("ipctest", (payload) => {
            const time = new Date().toLocaleTimeString("it-IT", {
                hour12: false,
            });
            logs.push(`[${time}] ${payload.text}`);
        });
    });

    function clearLogs() {
        logs = [];
    }

    async function askDate() {
        date = await bridge.Call.returnDate()
    }

</script>

<main>
    <!-- svelte-ignore a11y_no_static_element_interactions -->
    <header
        class="title-bar"
        onmousedown={(e) => {
            if (e.target !== e.currentTarget) return;
            bridge.DragWindow();
        }}
    >
        <div class="brand">
            <img src="./NETPRISM logo.png" class="Flogo" alt="logo" />
            <span class="brand-name"
                >.NET PRISM <span class="dim">FRAMEWORK</span></span
            >
        </div>

        <div class="window-controls">
            <button class="win-btn" onclick={bridge.MinimizeWindow}>–</button>
            <button class="win-btn" onclick={bridge.MaximizeWindow}>□</button>
            <button class="win-btn close" onclick={bridge.CloseWindow}>✕</button
            >
        </div>
    </header>

    <div class="main-content">
        <section class="log-section">
            <div class="section-header">
                <div class="status-indicator">
                    <span class="dot"></span>
                    <h3>LIVE TRAFFIC</h3>
                </div>
                <button class="action-btn" onclick={clearLogs}>
                    Clear Console
                </button>
            </div>

            <div class="log-viewport">
                {#if logs.length === 0}
                    <div class="empty-state" in:fade>
                        <p>No activity detected in the current session.</p>
                    </div>
                {/if}
                <div class="log-list">
                    {#each logs as log, i}
                        <div class="log-row" in:fly={{ x: -10, duration: 300 }}>
                            <span class="index"
                                >{i.toString().padStart(3, "0")}</span
                            >
                            <span class="message">{log}</span>
                        </div>
                    {/each}
                </div>
            </div>

            <div>
                <button class="action-btn" onclick={() => {
                    askDate()
                }}>
                    ask C# the time
                </button>

                <p>Today date is: {date}</p>

            </div>

        </section>
    </div>
</main>

<style>
    :global(body) {
        margin: 0;
        background-color: #0b0b0e;
        color: #cfd0d3;
        font-family:
            "Inter",
            -apple-system,
            BlinkMacSystemFont,
            "Segoe UI",
            Roboto,
            sans-serif;
        overflow: hidden;
    }

    main {
        display: flex;
        flex-direction: column;
        height: 100vh;
        box-sizing: border-box;

        border-radius: 15px;
    }

    /* --- TITLE BAR --- */
    .title-bar {
        position: absolute;


        display: flex;
        justify-content: space-between;
        align-items: center;
        background: #121217;
        padding: 0 12px;
        
        height: 38px;
        width: 100%;

        top: 0px;
        left: 0px;

        border-bottom: 1px solid #25252b;
        user-select: none;
    }

    .brand {
        position: absolute;
        left: 0px;
        display: flex;
        align-items: center;
        gap: 10px;
    }

    .prism-icon {
        width: 14px;
        height: 14px;
        background: linear-gradient(135deg, #4f46e5, #9333ea);
        clip-path: polygon(50% 0%, 100% 100%, 0% 100%);
    }

    .brand-name {
        font-size: 11px;
        font-weight: 700;
        letter-spacing: 0.05em;
        color: #fff;
    }

    .dim {
        color: #52525b;
        font-weight: 400;
    }

    .window-controls {
        
        position: absolute;

        top: 0px;
        right: 24px;
        
        display: flex;
        height: 40px;
    }

    .win-btn {
        background: transparent;
        border: none;
        color: #71717a;
        width: 45px;
        height: 38px;
        cursor: pointer;
        transition: all 0.2s;
        font-size: 14px;
    }

    .win-btn:hover {
        background: #1f1f24;
        color: #fff;
    }
    .win-btn.close:hover {
        background: #e81123;
        color: #fff;
    }

    /* --- CONTENT AREA --- */
    .main-content {
        padding: 24px;
        padding-top: 48px;
        flex-grow: 1;
        display: flex;
        flex-direction: column;
        background: radial-gradient(
            circle at top left,
            #121217 0%,
            #0b0b0e 100%
        );
    }

    .log-section {
        flex-grow: 1;
        display: flex;
        flex-direction: column;
        gap: 16px;
        min-height: 0; /* Fix per scrollbar in flexbox */
    }

    .section-header {
        display: flex;
        justify-content: space-between;
        align-items: center;
    }

    .status-indicator {
        display: flex;
        align-items: center;
        gap: 8px;
    }

    .dot {
        width: 6px;
        height: 6px;
        background: #22c55e;
        border-radius: 50%;
        box-shadow: 0 0 8px #22c55e;
    }

    h3 {
        margin: 0;
        font-size: 12px;
        font-weight: 600;
        color: #a1a1aa;
        letter-spacing: 0.05em;
    }

    .action-btn {
        background: #18181b;
        border: 1px solid #27272a;
        color: #d4d4d8;
        padding: 6px 12px;
        border-radius: 4px;
        font-size: 11px;
        font-weight: 500;
        cursor: pointer;
        transition: all 0.2s;
    }

    .action-btn:hover {
        background: #27272a;
        border-color: #3f3f46;
        color: #fff;
    }

    /* --- LOG VIEWPORT & SCROLLBAR --- */
    .log-viewport {
        flex-grow: 1;
        background: #09090b;
        border: 1px solid #18181b;
        border-radius: 6px;
        overflow-y: auto; /* Attiva lo scroll */
        position: relative;

        max-height: 300px;
    }

    /* Scrollbar Styling (Chrome/Edge/Webview2) */
    .log-viewport::-webkit-scrollbar {
        width: 8px;
    }

    .log-viewport::-webkit-scrollbar-track {
        background: #09090b;
        border-left: 1px solid #18181b;
    }

    .log-viewport::-webkit-scrollbar-thumb {
        background: #27272a;
        border-radius: 10px;
        border: 2px solid #09090b;
    }

    .log-viewport::-webkit-scrollbar-thumb:hover {
        background: #3f3f46;
    }

    .log-list {
        padding: 12px;
        display: flex;
        flex-direction: column;
        gap: 4px;
    }

    .log-row {
        display: flex;
        gap: 12px;
        padding: 6px 8px;
        border-radius: 3px;
        font-family: "JetBrains Mono", "Fira Code", monospace;
        font-size: 12px;
        line-height: 1.4;
        transition: background 0.1s;
    }

    .log-row:hover {
        background: #121217;
    }

    .index {
        color: #3f3f46;
        user-select: none;
    }

    .message {
        color: #d1d5db;
        word-break: break-all;
    }

    .empty-state {
        height: 100%;
        display: flex;
        align-items: center;
        justify-content: center;
        color: #3f3f46;
        font-size: 12px;
    }

    .Flogo {
        height: 40px;
    }
</style>
