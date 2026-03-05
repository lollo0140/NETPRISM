let CallBridge = window.cs;


class Bridge {
    constructor() {
        this.Call = CallBridge
    }

    RegisterHandle(name, func) {
        window.registerFunc(name, func);
    }

    CloseWindow() {
        window.closeAppWindow()
    }

    MinimizeWindow() {
        window.minimizeAppWindow()
    }

    MaximizeWindow() {

        window.maximizeAppWindow()
    }

    DragWindow() {
        window.startDrag()
    }

}

export default new Bridge();