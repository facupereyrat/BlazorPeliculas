using Microsoft.AspNetCore.Components;

namespace BlazorPeliculas.Client.Pages
{
    public partial class Counter
    {

        [Inject] ServiciosSingleton singleton { get; set; } = null!;
        [Inject] ServiciosTransient transient { get; set; } = null!;

        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount += 2;
            singleton.Valor = currentCount;
            transient.Valor = currentCount;
        }
    }
}
