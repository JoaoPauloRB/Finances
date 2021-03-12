using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Web.Components.Toast;

namespace Web.Pages
{
    public partial class Toasts : ComponentBase
    {
        [Parameter]
        public int Limit { get; set; }
        private List<Toast> ToastList;
    }
}