

window.isJsReady = () => {
    console.log("JavaScript is ready!");
    return true;
};
window.toggleDarkMode = function (enabled) {
    if (!document || !document.body) {
        setTimeout(() => window.toggleDarkMode(enabled), 100); 
        return;
    }

    if (enabled) {
        document.body.classList.add('dark-mode');
    } else {
        document.body.classList.remove('dark-mode');
    }
};