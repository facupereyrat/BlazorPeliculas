using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorPeliculas.Client.Pages
{
    public partial class Counter
    {

        [Inject] ServiciosSingleton singleton { get; set; } = null!;
        [Inject] ServiciosTransient transient { get; set; } = null!;
        [Inject] IJSRuntime js { get; set; } = null!;

        IJSObjectReference? modulo;

        private int currentCount = 0;
        private static int currentCountStatic = 0;


        [JSInvokable]
        public async Task IncrementCount()
        {
            modulo = await js.InvokeAsync<IJSObjectReference>("import", "./js/Counter.js"); //importando el modulo correspondinte
            await modulo.InvokeVoidAsync("mostrarAlerta", "Hola, mundo!"); //Solo se encuentra en el modulo counter.js


            currentCount += 1;
            currentCountStatic = currentCount;
            singleton.Valor = currentCount;
            transient.Valor = currentCount;
            await js.InvokeVoidAsync("pruebaPuntoNetStatic"); //esto es porque la referencia index.html necesita ser llamada para ejecutar
        }

        private async Task IncrementCountJavaScript()
        {
            await js.InvokeVoidAsync("pruebaPuntoNetInstancia",
                DotNetObjectReference.Create(this)); //Creando referencia a objeto .Net //this referencia a contexto donde me encuentro
        } //en este caso this pasa una instancia de la clase counter


        [JSInvokable]
        public static Task<int> ObtenerCurrentCount()
        {
            return Task.FromResult(currentCountStatic);
        }
    }
}
