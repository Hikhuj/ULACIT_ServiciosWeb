(function(){
    let btnGetAction1 = {};
    let btnGetAction2 = {};
    let btnGetAction3 = {};
    let btnGetAction4 = {};
    let btnGetAction5 = {};
    let btnGetAction6 = {};

    const inicializar = function () {
        btnGetAction1 = document.querySelector('#btnGetAction1');
        btnGetAction2 = document.querySelector('#btnGetAction2');
        btnGetAction3 = document.querySelector('#btnGetAction3');
        btnGetAction4 = document.querySelector('#btnGetAction4');
        btnGetAction5 = document.querySelector('#btnGetAction5');
        btnGetAction6 = document.querySelector('#btnGetAction6');
        bind();
        
    }
    const bind= function(){
        btnGetAction1.onclick = getQuery1;
        btnGetAction2.onclick = getQuery2;
        btnGetAction3.onclick = getQuery3;
        btnGetAction4.onclick = getQuery4;
        btnGetAction5.onclick = getQuery5;
        btnGetAction6.onclick = getQuery6;
    }
    
    const getQuery1 = function (){
        fetch('http://localhost:61610/api/ProductosAlfabeticos')
            .then(response => response.json())
            .then(datos => {
                let dato = JSON.parse(datos);
                let archivo = base64ToArrayBuffer(dato['archivo']);
                saveByteArray("ProductosAlfabeticos", "xml", archivo)
            } );
    }

    const getQuery2 = function (){
        fetch('http://localhost:61610/api/ProveedoresFiltro1')
            .then(response => response.json())
            .then(datos => {
                let dato = JSON.parse(datos);
                let archivo = base64ToArrayBuffer(dato['archivo']);
                saveByteArray("ProveedoresFiltro1", "xml", archivo);
            } );
    }

    const getQuery3 = function (){
        fetch('http://localhost:61610/api/ProveedoresFiltro2')
            .then(response => response.json())
            .then(datos => {
                let dato = JSON.parse(datos);
                let archivo = base64ToArrayBuffer(dato['archivo']);
                saveByteArray("ProveedoresFiltro2", "xml", archivo);
            } );
    }

    const getQuery4 = function (){
        fetch('http://localhost:61610/api/Canton')
            .then(response => response.json())
            .then(datos => {
                let dato = JSON.parse(datos);
                let archivo = base64ToArrayBuffer(dato['archivo']);
                saveByteArray("Canton", "xml", archivo);
            } );
    }

    const getQuery5 = function (){
        fetch('http://localhost:61610/api/Pedidos')
            .then(response => response.json())
            .then(datos => {
                let dato = JSON.parse(datos);
                let archivo = base64ToArrayBuffer(dato['archivo']);
                saveByteArray("Pedidos", "xml", archivo);
            } );
    }

    const getQuery6 = function (){
        fetch('http://localhost:61610/api/ProductoLinea')
            .then(response => response.json())
            .then(datos => {
                let dato = JSON.parse(datos);
                let archivo = base64ToArrayBuffer(dato['archivo']);
                saveByteArray("ProductoLinea", "xml", archivo);
            } );
    }


    const base64ToArrayBuffer = function (base64) {
        var binaryString = window.atob(base64);
        var len = binaryString.length;
        var bytes = new Uint8Array(len);
        for (var i = 0; i < len; i++) {
            bytes[i] = binaryString.charCodeAt(i);
        }
        return bytes.buffer;
    }

    const saveByteArray = function (reportName, ext, byte) {
        var blob = new Blob([byte], { type: 'application/octet-binary' });
        var fileName = reportName + "." + ext;
        if (navigator.appVersion.toString().indexOf('.NET') > 0) {
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
})();