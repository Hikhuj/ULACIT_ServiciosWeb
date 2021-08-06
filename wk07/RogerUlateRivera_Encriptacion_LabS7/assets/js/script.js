(function(){
    let body=$('body'),
        stage=$('#stage'),
        back=$('a.back');
        
        // Paso 1: Hacer click en alguna de las opciones para llamar una funcion
        $('#step1 .encrypt').on('click',()=>{
            body.attr('class','encrypt');
            step(2);
        })
        $('#step1 .decrypt').on('click',()=>{
            body.attr('class','decrypt');
            step(2);
        })


        //Paso 2
        $('#step2 .button').on('click', (e)=>{
            $(e.target).parent().find('input').click();
        })

        // Vamos a obtener el archivo para encriptacion
        let file = null;
        $('#step2').on('change','#encrypt-input',(e)=>{
            // Si el archivo tiene un largo diferente de 1
            if(e.target.files.length!=1){
                alert('Seleccione un archivo a encriptar');
                return 0; //false tambien sirve
            }
            file = e.target.files[0];
            // Si el tamanio del archivo es mayor a 1MB
            if(file.size>(1024*1024)){
                alert('El archivo es muy pesado');
                return 0;
            }
            // Pasar a encriptar al paso 3
            step(3);
            
        })

        // Vamos a obtener un archivo para procesar una desencriptacion
        $('#step2').on('change','#decrypt-input',(e)=>{
            if(e.target.files.length!=1){
                alert('Seleccione un archivo a desencriptar');
                return 0; //false tambien sirve
            }
            file = e.target.files[0];
            step(3);
            
        })

        //Paso 3
        $('a.button.process').on('click',(e)=>{
            let input = $(e.target).parent().find('input[type=password]'),
                a = $('#step4 a.download'),
                password = input.val();

            input.val('');

            input.val('');
            if(password.length < 5){
                alert('Por favor esciba una contrasenia mayor a 5 caracteres');
                return;
            }

            var reader = new FileReader();
            if(body.hasClass('encrypt')){
                // Funcion del lectoer (READER)
                reader.onload = function(doc){
                    let encrypted = CryptoJS.AES.encrypt(doc.target.result,password);
                    // Esto es de JQUERY, no es propio de JS
                    // Con esto ya estamos precargando el step 4
                    a.attr('href','data:application/octet-stream,' + encrypted);
                    a.attr('download', file.name + '.encriptado');
                    step(4);
                }
                // Para abrir el documento que estoy cargando
                reader.readAsDataURL(file);
            }else{
                reader.onload = function(doc){
                    let decrypted = CryptoJS.AES.decrypt(doc.target.result,password).toString(CryptoJS.enc.Latin1);
                    if(!/^data:/.test(decrypted)){
                        alert('La contrasenia no es correcta para la desencriptacion. Trate otra vez');
                        return;
                    }

                    // Esto es de JQUERY, no es propio de JS
                    // Con esto ya estamos precargando el step 4
                    a.attr('href', decrypted);
                    a.attr('download', file.name.replace('.encriptado','.desencriptado'));
                    step(4);
                }

                // Que lo lea como un documento de texto
                reader.readAsText(file);

            }
            
        })

        back.on('click',function(){
            step(1);
        })

        //funcion para navegar correctamente en divs
        const step=function(i){
            if (i=== 1) 
                back.fadeOut();
                else back.fadeIn();
                stage.css('top',(-(i-1)*100)+'%');
            
        }
})()
