function load(img) {
    const url = img.getAttribute('lazy-src')

    img.setAttribute('src', url)
    /*img.removeAttribute('lazy-src')*/
}

function ready() {
    if ('IntersectionObserver' in window) {
        var lazyImgs = document.querySelectorAll('[lazy-src]')

        let observer = new IntersectionObserver((entries) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    load(entry.target)
                }
            })
        });

        lazyImgs.forEach(img => {
            observer.observe(img);
        })
    } else {

    }
}

document.addEventListener('DOMContentLoaded', ready)