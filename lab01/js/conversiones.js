(function() {

	let valorDecimal = 0.0;
	let hasDecimalCero;
	let btnCalcular = {};
	let btnLimpiar = {};

	const cleanForm = function(){
    	document.getElementById("formularioConversiones").reset();
    }
	
	const clean = function(){
		// El utilizar el .value es para cuando podria utilizar un arreglo
		// en este caso no parece que sea para esto
		cleanForm();
        document.getElementById("shortNumber").innerHTML = '';
        document.getElementById("intNumber").innerHTML = '';
        document.getElementById("longNumber").innerHTML = '';
    	document.getElementById("floatNumber").innerHTML = '';
    	document.getElementById("doubleNumber").innerHTML = '';
    }

    const calculateNumbers = function() {
    	// Obtener valor a procesar
    	valorDecimal = document.getElementById("valorDecimal").value;
    	valorDecimalStr = valorDecimal.length
    	evaluateNumber = valorDecimal;
    	console.log("Valor decimal: " + valorDecimal);
    	console.log("Evaluar numero: " + valorDecimal);

    	// Rule: no debe tener ceros en sus decimales.
    	hasDecimalCero = verifyDecimals(valorDecimal);

    	// Rule: ver si es decimal o no
    	if(evaluateNumber == Math.floor(evaluateNumber)){
    		alert(evaluateNumber + " valor es entero y debe ser decimal.")
    		clean();
    	}if(hasDecimalCero){
    		alert("Valor no debe contener valores decimales en cero.");
    		clean();
    	}if(valorDecimalStr < 4){
    		alert("Valor no tiene 4 caracteres");
    	}else{
    		processCalcularNumbers(valorDecimal);
    	}
    }

    const processCalcularNumbers = function(valorDecimal,evaluateNumber) {
    	document.getElementById("shortNumber").innerHTML = parseInt(valorDecimal);
    	document.getElementById("intNumber").innerHTML = parseInt(valorDecimal);
    	document.getElementById("longNumber").innerHTML = parseInt(valorDecimal);
    	document.getElementById("floatNumber").innerHTML = valorDecimal;
    	document.getElementById("doubleNumber").innerHTML = valorDecimal;
    }

    const verifyDecimals = function(valorDecimal) {
    	// Funcion para verificar si posee o no decimales
    	let result;
    	let stringValue = valorDecimal.toString();

    	result = stringValue.indexOf("0") > 0 ? true : false;

		return result;
    }

    const initializer = function(){
		// Obtener valores
		btnCalcular = document.getElementById('btnCalcular');
		btnLimpiar = document.getElementById('btnLimpiar');

		// Botones de acciones
		btnCalcular.onclick = calculateNumbers;
		btnLimpiar.onclick = clean;

	}

    initializer();

})()