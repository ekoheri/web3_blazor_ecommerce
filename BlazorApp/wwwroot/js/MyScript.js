[script.js]
function buatPopup(pageURL, lebar, tinggi)
{
    var kiri = (screen.width - lebar) / 2;
    var atas = (screen.height - tinggi) /4;
    var features = 'modal=yes,'
        +'popup=yes,'
        +'resizable=no,'
        +'menubar=no,'
        +'toolbar=no,'
        +'width=' + lebar +','
        +'height='+ tinggi +','
        +'top='+ atas +','
        +'left='+ kiri;

    window.open(pageURL, 'Pop up', features);
}