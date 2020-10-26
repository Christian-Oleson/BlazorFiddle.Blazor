using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorFiddle.Blazor
{
    public class BaseBlazorFiddle : BlazorComponent
    {
        protected ElementRef Ref;

        [Parameter]
        protected string Code { get; set; }

        [Parameter]
        protected string Template { get; set; } = null;

        private bool isFirstRender = true;

        protected async override Task OnInitAsync()
        {
            await base.OnInitAsync();
        }

        protected override async Task OnAfterRenderAsync()
        {
            if (isFirstRender)
            {
                isFirstRender = true;
                await JSRuntime.Current.InvokeAsync<object>("blazorFiddle.create", Ref, new
                {
                    Text = this.Code,
                    Template = this.Template,
                });
            }
        }
    }
}