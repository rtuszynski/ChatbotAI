function typeWriter(elementId, text, delay = 100) {
    let i = 0;
    function type() {
        if (i < text.length) {
            document.getElementById(elementId).innerHTML += text.charAt(i);
            i++;
            setTimeout(type, delay);
        }
    }
    type();
}