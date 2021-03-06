#pragma checksum "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\Pages\TicketsComponent.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe6393ada3534fc566619966b3b986ea0fe29290"
// <auto-generated/>
#pragma warning disable 1591
namespace WebApp.Pages
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
#nullable restore
#line 7 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\Pages\TicketsComponent.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/projects/{projectId:int}/tickets")]
    public partial class TicketsComponent : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Tickets</h3>\r\n<br>\r\n\r\n");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "row");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "col-auto");
            __builder.OpenElement(5, "input");
            __builder.AddAttribute(6, "type", "text");
            __builder.AddAttribute(7, "class", "form-control");
            __builder.AddAttribute(8, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 14 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\Pages\TicketsComponent.razor"
                                                             searchFilter

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => searchFilter = __value, searchFilter));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n    ");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "col-auto");
            __builder.OpenElement(13, "button");
            __builder.AddAttribute(14, "type", "button");
            __builder.AddAttribute(15, "class", "btn btn-light");
            __builder.AddAttribute(16, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 17 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\Pages\TicketsComponent.razor"
                                                              OnSearch

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(17, "Search");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n    ");
            __builder.OpenElement(19, "div");
            __builder.AddAttribute(20, "class", "col-auto");
            __builder.OpenElement(21, "div");
            __builder.AddAttribute(22, "class", "form-check form-check-inline");
            __builder.OpenElement(23, "input");
            __builder.AddAttribute(24, "class", "form-check-input");
            __builder.AddAttribute(25, "type", "checkbox");
            __builder.AddAttribute(26, "id", "myticket");
            __builder.AddAttribute(27, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 21 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\Pages\TicketsComponent.razor"
                                                                                       ViewMyTickets

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(28, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => ViewMyTickets = __value, ViewMyTickets));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(29, "\r\n            ");
            __builder.AddMarkupContent(30, "<label class=\"form-check-label\" for=\"myticket\">View My Tickets</label>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n<br>\r\n\r\n");
            __builder.OpenElement(32, "table");
            __builder.AddAttribute(33, "class", "table");
            __builder.AddMarkupContent(34, "<thead><tr><th>Title</th>\r\n            <th>Owner</th>\r\n            <th>Description</th>\r\n            <th>Report Date</th>\r\n            <th>Due Date</th></tr></thead>\r\n    ");
            __builder.OpenElement(35, "tbody");
#nullable restore
#line 39 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\Pages\TicketsComponent.razor"
         if (tickets != null)
        {
             

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\Pages\TicketsComponent.razor"
              foreach (var ticket in tickets)
             {

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<WebApp.Controls.TicketRowComponent>(36);
            __builder.AddAttribute(37, "ticket", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Core.Models.Ticket>(
#nullable restore
#line 43 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\Pages\TicketsComponent.razor"
                                             ticket

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
#nullable restore
#line 44 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\Pages\TicketsComponent.razor"
             }

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\Pages\TicketsComponent.razor"
              
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 51 "D:\Tutorial IT 2022\Project\.Net Core\LearnWebApplicationAPI\WebApp\Pages\TicketsComponent.razor"
       
    IEnumerable<Ticket> tickets;

    [Parameter]
    public int ProjectId { get; set; }
    string searchFilter;
    bool viewMyTickets = false;
    public bool ViewMyTickets { 
        get => viewMyTickets;
        set
        {
            viewMyTickets = value;
            Task.Run(async () =>
            {
                if (viewMyTickets)
                    tickets = await TicketsScreenUseCases.ViewOwnersTickets(ProjectId, "Strange");
                else 
                    tickets = await TicketsScreenUseCases.ViewTickets(ProjectId);
                StateHasChanged();
            });
            
        }    
    }

    protected override async Task OnParametersSetAsync()
    {
        tickets = await TicketsScreenUseCases.ViewTickets(ProjectId);
    }

    private async Task OnSearch()
    {
        tickets = await TicketsScreenUseCases.SearchTicketsByProjectId(searchFilter, ProjectId);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ITicketsScreenUseCases TicketsScreenUseCases { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
