(function() {

	let array = {};
	let arraySize = 0;
	let randomLimit = 0;
	let noEvenNumbers;
	let removeLessThan10;
	let removeMoreThan50;

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

	// De esta forma puedo limpiar completamente un formulario reseteandolo
	const cleanForm = function(){
    	document.getElementById("formularioControlCheckBox").reset();
    }

    // Limpiar los checks en javascript
    const cleanChecks = function() {
    	noEvenNumbers = document.getElementById('noEvenNumbers');
    	removeLessThan10 = document.getElementById('removeLessThan10');
    	removeMoreThan50 = document.getElementById('removeMoreThan50');

    	noEvenNumbers.checked = false;
    	removeLessThan10.checked = false;
    	removeMoreThan50.checked = false;
    }
	
	// Limpiamos todo lo que se necesita limpiar
	const clean = function(){
		// El utilizar el .value es para cuando podria utilizar un arreglo
		// en este caso no parece que sea para esto
		cleanForm();
		cleanChecks();
        document.getElementById('arrayContent').innerHTML = '';
    }

	const initializer = function(){
		// Obtener valores
		arraySize = document.getElementById('arraySize');
		randomSize = document.getElementById('randomSize');

		// Obtener valores
		btnLlenarArreglo = document.getElementById('btnLlenarArreglo');
		btnCalcular = document.getElementById('btnVerResultados');
		btnLimpiar = document.getElementById('btnLimpiar');

		// Botones de acciones
		if(arraySize > 0 || randomSize > 0){
			btnLlenarArreglo.onclick = createArray(arraySize,randomSize);
			btnVerResultados.onclick = showArray(array);
		}else {
			alert("Sin valores en el tamanio del arreglo o el limite del arreglo");
		}

		btnLimpiar.onclick = clean;
	}

	initializer();

})()