using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorPeliculas.Client.Pages
{
    public partial class Counter
    {

        [Inject] ServiciosSingleton singleton { get; set; } = null!;
        [Inject] ServiciosTransient transient { get; set; } = null!;
        [Inject] IJSRuntime js { get; set; } = null!; 

        private int currentCount = 0;
        private static int currentCountStatic = 0;

        private async Task IncrementCount()
        {
            currentCount += 1;
            currentCountStatic = currentCount;
            singleton.Valor = currentCount;
            transient.Valor = currentCount;
            await js.InvokeVoidAsync("pruebaPuntoNetStatic"); //esto es porque la referencia index.html necesita ser llamada para ejecutar
        }

        [JSInvokable]
        public static Task<int> ObtenerCurrentCount()
        {
            return Task.FromResult(currentCountStatic);
        }
    }
}
