#pragma checksum "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\Controls\AlertComponent.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "904ae077f6480c75341dc4fb918fa03fcd1e4323"
// <auto-generated/>
#pragma warning disable 1591
namespace WebApp.Controls
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\_Imports.razor"
using WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\_Imports.razor"
using WebApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\_Imports.razor"
using Core.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\_Imports.razor"
using MyApp.ApplicationLogic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\_Imports.razor"
using WebApp.Controls;

#line default
#line hidden
#nullable disable
    public partial class AlertComponent : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "alert alert-danger");
            __builder.AddAttribute(2, "style", 
#nullable restore
#line 2 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\Controls\AlertComponent.razor"
              $"display: {display}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(3, "role", "alert");
#nullable restore
#line 4 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\Controls\AlertComponent.razor"
__builder.AddContent(4, ErrorMessage);

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(5, "\r\n    ");
            __builder.OpenElement(6, "button");
            __builder.AddAttribute(7, "type", "button");
            __builder.AddAttribute(8, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 6 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\Controls\AlertComponent.razor"
                      Dismiss

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "class", "close");
            __builder.AddAttribute(10, "data-dismiss", "alert");
            __builder.AddAttribute(11, "aria-label", "Close");
            __builder.AddMarkupContent(12, "<span aria-hidden=\"true\">&times;</span>");
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 12 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\Controls\AlertComponent.razor"
       
    string display = "none";
    
    public string ErrorMessage { get; set; }

    public void Show()
    {
        display = "block";
        StateHasChanged();
    }

    public void Dismiss()
    {
        display = "none";
        ErrorMessage = string.Empty;
    }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
