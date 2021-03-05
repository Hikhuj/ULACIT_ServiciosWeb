(function() {

	let salarioPorHoras = 0;
	let diasTrabajados = 0;
	let porcentajeDeducciones = 0;
	let salarioBruto = 0;
	let deducciones = 0;
	let salarioNeto = 0;
	let btnCalcular = {};
	let btnLimpiar = {};

	function toPercentage(value) {
		return value / 100;
	}

	const calculateSalary = function(){
		// Obtener valores
		salarioPorHoras = document.getElementById("salarioPorHoras").value;
		diasTrabajados = document.getElementById("diasTrabajados").value;
		deducciones = toPercentage(document.getElementById("porcentajeDeducciones").value);

		salarioBruto = 8 * diasTrabajados;
		deducciones = deducciones * salarioBruto;
		salarioNeto = salarioBruto - deducciones;

		document.getElementById("salarioBrutoId").innerHTML = "$" + salarioBruto;
		document.getElementById("deduccionesId").innerHTML = "$" + deducciones;
		document.getElementById("salarioNetoId").innerHTML = "$" + salarioNeto
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