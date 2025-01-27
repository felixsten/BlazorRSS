
window.startAutoScroll = (containerId) => {
    
    setTimeout(() => {
        const container = document.getElementById(containerId);

        if (container) {
            console.log("Container found! Starting auto-scroll.");

            let scrollAmount = 0;
            let scrollStep = 2; 
            let isScrollingDown = true;

            function scrollContent() {
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
            }

            
            window.requestAnimationFrame(scrollContent);
        } else {
            console.log('Container not found');
        }
    }, 500); 
};