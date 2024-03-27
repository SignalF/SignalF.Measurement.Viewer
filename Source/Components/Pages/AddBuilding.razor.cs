using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace SignalF.Measurement.Viewer.Components.Pages
{
    public partial class AddBuilding
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }
        [Inject]
        public SignalFDbService SignalFDbService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            building = new SignalF.Measurement.Viewer.Models.SignalFDb.Building();
        }
        protected bool errorVisible;
        protected SignalF.Measurement.Viewer.Models.SignalFDb.Building building;

        protected async Task FormSubmit()
        {
            try
            {
                await SignalFDbService.CreateBuilding(building);
                DialogService.Close(building);
            }
            catch (Exception ex)
            {
                errorVisible = true;
            }
        }

        protected async Task CancelButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}