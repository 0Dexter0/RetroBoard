function saveBoardDataBeforeReload() {
    console.log("saveBoardDataBeforeReload");
    DotNet.invokeMethod("RetroBoard", "SaveBeforeReload")
    // dotNetHelper.invokeMethodAsync("SaveBeforeReload");
    // dotNetHelper.dispose();
}