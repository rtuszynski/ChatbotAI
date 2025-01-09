let typeWriterTimeout;

function typeWriter(elementId, text, delay = 50) {
    let i = 0;
    function type() {
        if (i < text.length) {
            document.getElementById(elementId).innerHTML += text.charAt(i);
            i++;
            typeWriterTimeout = setTimeout(type, delay);
        }
    }
    type();
}

function getElementContent(elementId) {
    return document.getElementById(elementId).innerText;
}

function clearElementContent(elementId) {
    document.getElementById(elementId).innerHTML = '';
}

function stopTypeWriter() {
    clearTimeout(typeWriterTimeout);
}