(function() {

    let arregloPosts = [];
    const cargarPosts = function() {
        // Llamado asincrono
        arregloPosts = await fetch('https://jsonplaceholder.typicode.com/users/1/posts')
            .then(response => response.json())
        crearCuerpoTabla();
    }

    const crearCuerpoTabla = function() {
        var body = document.getElementById('tbody');
        tbody.innerHTML = '';
        arregloPosts.map(fila => {
            return 'd'
        });
    }

    cargarPosts();
    alert('vamos bien')
})()


/*
(function() {

    let arregloPosts = [];
    const cargarPosts = function() {
        // Llamado asincrono
        fetch('https://jsonplaceholder.typicoder.com/users/1/posts')
        .then(response => response.json())
        .then(data => console.log(data));
    }

    alert('vamos bien')
})()

*/