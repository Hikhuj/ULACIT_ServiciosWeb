(function() {

	function toPercentage(value) {
		return value / 100;
	}

	const cleanForm = function(){
    	document.getElementById("formularioSalario").reset();
    }
	
	const clean = function(){
		// El utilizar el .value es para cuando podria utilizar un arreglo
		// en este caso no parece que sea para esto
		cleanForm();
        document.getElementById("salarioBrutoId").innerHTML = '';
        document.getElementById("deduccionesId").innerHTML = '';
        document.getElementById("salarioNetoId").innerHTML = '';
    }

	const initializer = function(){
		// Obtener valores
		btnCalcular = document.getElementById('btnCalcular');
		btnLimpiar = document.getElementById('btnLimpiar');

		// Botones de acciones
		btnCalcular.onclick = calculateSalary;
		btnLimpiar.onclick = clean;

	}

    initializer();

})()