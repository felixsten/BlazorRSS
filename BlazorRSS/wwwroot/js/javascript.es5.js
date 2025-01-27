"use strict";

window.startAutoScroll = function (containerId) {

    setTimeout(function () {
        var container = document.getElementById(containerId);

        if (container) {
            (function () {
                var scrollContent = function scrollContent() {
                    if (isScrollingDown) {
                        if (scrollAmount >= container.scrollHeight - container.clientHeight) {
                            isScrollingDown = false;
                        } else {
                            scrollAmount += scrollStep;
                        }
                    } else {
                        if (scrollAmount <= 0) {
                            isScrollingDown = true;
                        } else {
                            scrollAmount -= scrollStep;
                        }
                    }
                    container.scrollTop = scrollAmount;
                    window.requestAnimationFrame(scrollContent);
                };

                console.log("Container found! Starting auto-scroll.");

                var scrollAmount = 0;
                var scrollStep = 2;
                var isScrollingDown = true;

                window.requestAnimationFrame(scrollContent);
            })();
        } else {
            console.log('Container not found');
        }
    }, 500);
};

