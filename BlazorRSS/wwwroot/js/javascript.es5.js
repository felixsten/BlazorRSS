'use strict';

window.isJsReady = function () {
    console.log("JavaScript is ready!");
    return true;
};
window.toggleDarkMode = function (enabled) {
    if (!document || !document.body) {
        setTimeout(function () {
            return window.toggleDarkMode(enabled);
        }, 100);
        return;
    }

    if (enabled) {
        document.body.classList.add('dark-mode');
    } else {
        document.body.classList.remove('dark-mode');
    }
};

