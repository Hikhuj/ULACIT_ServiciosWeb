(function() {
	let btnDescarga = {}
	const inicializar = function(){
		btnDescarga = document.querySelector('#btnDescarga');
		btnDescarga.onclick = descargarArchivo;
	}

	const descargarArchivo = function() {
		console.log('vamos bien')
		fetch()
	}

	// Todo esto es para exportar archivos a XML
	const saveByteArray = function(reportname, ext, byte){
		var blob = new Blob([byte], {type:'application/octet-binary'});
		var fileName = reportName + "." + ext;
		if(navigator.appVersion.toString().indexOf('.NET') > 0) { // for IE Browser
			window.navigator.msSaveBlob(blob, fileName);
		}else{
			var link = document.createElement('a');
			link.href = window.URL.createObjectURL(blob);
			link.download = filename;
			document.body.appendChild(link);
			link.click();
			document.body.removeChild(link);
		}
	};
	inicializar();
})