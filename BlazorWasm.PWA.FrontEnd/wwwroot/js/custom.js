

window.gerarImagemCarta = function () {
    var element = document.getElementById("template");
    html2canvas(element).then(function (canvas) {
        var imageData = canvas.toDataURL('image/png');

        var link = document.createElement('a');
        link.href = imageData;
        link.download = 'YuGiOh-Card.jpg';
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);

        return ImageData;
    });
};

function notifySuccess(message) {
    PNotify.success({
        text: message,
        styling: 'bootstrap3'
    });
}

function notifyError(message) {
    PNotify.error({
        text: message,
        styling: 'bootstrap3'
    });
}
