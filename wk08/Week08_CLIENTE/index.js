(function() {

    /*
    *   Vamos a recibir un objeto que este debe venir serializado desde
    *   el sistema principal que seria el codigo C# y luego lo deserializo
    *   aca en la aplicacion de aqui para obtener los datos, deserializando
    *   en base 64.
    */

    // Var declaration
    let btnDescarga = {};
    let btnEnviar = {};
    let archivoSubir = {};
    let url = 'http://localhost:58291/api/articulos'

    // Funcion de tipo Expression
    const inicializar = function() {
        btnEnviar = document.querySelector('#btnEnviar');
        archivoSubir = document.querySelector('#subir');
        btnDescarga = document.querySelector('#btnDescarga');
        bind();
    }

    const bind = function() {
        btnDescarga.onclick = descargarArchivo;
        btnEnviar.onclick = enviarArchivo;
    }

    // Crearemos un formulario porque es mejor crearlo por un formulario
    const enviarArchivo = function() {
        // Este es el tipo de dato que ocupamos
        const formData = new FormData();
        // aqui tenemos el archivo que nosotros seleccionamos
        formData.append('miArchivo',archivoSubir.files[0]);
        fetch(url,{
            // aqui abrimos un objeto donde vamos a definir lo que vamos a necesitar
            method: 'POST',
            body: formData
        })
        .then(response => response.json())
        .then(datos => {
            console.log(datos)
        });
    }

    // Funcion de tipo Expression
    // la cual nos va a permitir obtener los datos
    const descargarArchivo = function() {
        fetch(url)
            .then(response => response.json())
            .then(datos => {
                // hacemos la peticion, traigame esa peticion del JSON
                let dato = JSON.parse(datos);
                // tomar el archivo y lo convierte en base 64
                let archivo = base64ToArrayBuffer(dato['archivo']);
                // aqui vamos a obtener el archivo, lo va a procesar
                // mientras nosotros le indicamos el NOMBRE, EXTENSION
                // o tipo de archivo
                // luego por aca hago que el mae lo convierta a XML
                // esta funcion me permite crear un archivo, con el nombre
                // la extension que necesitamos y los datos del archivo para
                // crear un archivo descargable
                saveByteArray("Documento","xml",archivo);
            });
    }

    // Funcion de tipo Expression: tambien me permite que sea local
    // y no global
    // esta funcion me va a ser util para deserializar los datos
    // pero utilizando como base 64
    const base64ToArrayBuffer = function (base64) {
        var binaryString = window.atob(base64);
        var len = binaryString.length;
        var bytes = new Uint8Array(len);
        for (var i = 0; i < len; i++) {
            bytes[i] = binaryString.charCodeAt(i);
        }

        return bytes.buffer;
    }

    // Todo esto es para exportar archivos a XML
    // Esta funcion
    // Funcion de tipo Expression
    const saveByteArray = function(reportName, ext, byte) {
        var blob = new Blob([byte], { type: 'application/octet-binary' });
        var fileName = reportName + "." + ext;
        if (navigator.appVersion.toString().indexOf('.NET') > 0) { // for IE Browser
            window.navigator.msSaveBlob(blob, fileName);
        } else {
            var link = document.createElement('a');
            link.href = window.URL.createObjectURL(blob);
            link.download = fileName;
            document.body.appendChild(link);
            link.click();
            document.body.removeChild(link);
        }
    };
    inicializar();
})()