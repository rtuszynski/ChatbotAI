function typeWriter(elementId, text, delay = 50) {
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

function clearElementContent(elementId) {
    document.getElementById(elementId).innerHTML = '';
}