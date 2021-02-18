(function() {

	let array = {};
	let arraySize = 0;
	let randomLimit = 0;

	const createArray = function(arraySize, randomLimit) {

		for (var i = 0; i <= arraySize; i++) {
			array.push(Math.floor((Math.random() * randomLimit) + 1));
		};
		array = array;
	}

	const showArray = function(array) {
		for (var i = 0; i <= array.length; i++) {
			document.write("<tr><td>Number " + i + " is:</td>");
			document.write("<td>" + myArray[i] + "</td></tr>");
		}
	}

	const cleanForm = function(){
    	document.getElementById("formularioControlCheckBox").reset();
    }
	
	const clean = function(){
		// El utilizar el .value es para cuando podria utilizar un arreglo
		// en este caso no parece que sea para esto
		cleanForm();
        document.getElementById('arrayContent').innerHTML = '';
    }

	const initializer = function(){
		// Obtener valores
		btnLlenarArreglo = document.getElementById('btnLlenarArreglo');
		btnCalcular = document.getElementById('btnVerResultados');
		btnLimpiar = document.getElementById('btnLimpiar');

		arraySize = document.getElementById('arraySize');
		randomSize = document.getElementById('randomSize');

		// Botones de acciones
		btnLlenarArreglo.onclick = createArray(arraySize,randomSize);
		btnVerResultados.onclick = showArray(array);
		btnLimpiar.onclick = clean;
	}

	initializer();

})()