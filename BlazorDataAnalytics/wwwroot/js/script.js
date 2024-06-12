function isDevice() {
    return /android|webos|iphone|ipad|ipod|blackberry|iemobile|opera mini|mobile/i.test(navigator.userAgent);
}

function GetAddress() {
    var script = document.createElement("script");
    script.type = "text/javascript";
    script.src = "https://api.ipify.org?format=jsonp&callback=DisplayIP";
    var address = document.getElementsByTagName("head")[0].appendChild(script);

    return address
};

function DisplayIP(response) {
    return document.getElementById("text").innerHTML = "Your IP Address is " + response.ip;
};

function identifyBrowser() {

    let userAgent = navigator.userAgent;
    let browser;
    if (userAgent.match(/edg/i)) {
        browser = "edge";
    } else if (userAgent.match(/firefox|fxios/i)) {
        browser = "firefox";
    } else if (userAgent.match(/opr\//i)) {
        browser = "opera";
    } else if (userAgent.match(/chrome|chromium|crios/i)) {
        browser = "chrome";
    } else if (userAgent.match(/safari/i)) {
        browser = "safari";
    } else {
        alert("Other browser");
    }

    return browser;
};
function jsSaveAsFile(filename, byteBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + byteBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}