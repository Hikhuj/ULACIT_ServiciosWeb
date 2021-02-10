(function(){

    let arregloPosts=[];
    let btnAceptar={};
    let btnCancelar={};
    let posts={
        userId:{},
        id:{},
        title:{},
        body:{}
   };
    
    const cargarPosts =  async function(){
        arregloPosts = await fetch('https://jsonplaceholder.typicode.com/users/1/posts')
           .then(response => response.json())
           crearCuerpoTabla();
           
    }
    const crearCuerpoTabla = function(){
        var tbody = document.getElementById('tbody');
        tbody.innerHTML='';
        tbody.innerHTML+=arregloPosts.map(fila=>{
            return `<tr><td>${fila.userId}</td>
            <td>${fila.id}</td>
            <td>${fila.title}</td>
            <td>${fila.body}</td>
            <td><button class="btn btn-success">Editar</button><button class="btn btn-danger">Eliminar</button></td></tr>`
        })
    }
    const agregarPosts=function(){
        arregloPosts.push(Object.assign({},posts));
        crearCuerpoTabla();
        console.log(posts);
        limpiar();
    }
    const cancelarPosts = function(){
        limpiar();
    }
    const limpiar = function(){
        userId.value = '';
        id.value = '';
        title.value = '';
        body.value = '';
    }
    const inicializar = function(){
        userId = document.getElementById('userId');
        id = document.getElementById('id');
        title = document.getElementById('title');
        body = document.getElementById('body');
        btnAceptar = document.getElementById('btnAceptar');
        btnCancelar = document.getElementById('btnCancelar');
        btnAceptar.onclick=agregarPosts;
        btnCancelar.onclick=cancelarPosts;
        cargarPosts();
        userId.onchange=cambiarValor;
        id.onchange=cambiarValor;
        title.onchange=cambiarValor;
        body.onchange=cambiarValor;
    }
    const cambiarValor = function(e){
        
        var control = e.target;
        posts[control.name] = control.value;
        //const[value,name] = e.target;
        //console.log(name, value)
    }
    inicializar();
})()