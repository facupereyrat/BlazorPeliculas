function pruebnaPuntoNetStatic() {
    DotNet.invokeMethodAsync("BlazorPeliculas.Client", "ObtenerCurrentCount") //invoco metodo 
        .then(resultado => { //Luego de invocar entonces haces lo siguiente
            console.log('conteo desde javascript' + resultados);
        })
}

function pruebaPuntoNetInstancia(dotnetHelper) { //referencia a un objeto c# utilizable en js
    dotnetHelper.invokeMethodAsync("IncrementCount");
}