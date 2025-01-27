﻿using System.Collections.Generic;
using ClassLibrary;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorBroker.Pages
{
    public class RealEstateDetailsBase : ComponentBase
    {
        public RealEstate RealEstate { get; set; } = new();

        [Inject]
        public IRealEstateService RealEstateService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            RealEstate = await RealEstateService.GetRealEstate(int.Parse(Id));
        }
        





    }

    
}
