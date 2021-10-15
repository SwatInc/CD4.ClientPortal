using CD4.ClientPortal.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;

namespace CD4.ClientPortal.Client.Components.Address
{
    public partial class AddressDisplay
    {
        #region Parameters
        [Parameter]
        public EventCallback<AddressModel> OnAddressChangeRequested { get; set; }
        [Parameter]
        public AddressModel PassedInAddress
        {
            get { return _passedInAddress; }
            set
            {
                if (value is null)
                {
                    return;
                }

                if (_passedInAddress != value)
                {
                    _passedInAddress = value; 
                    DisplaySiteAddress = _passedInAddress;
                }
            }
        }

        #endregion

        #region Fileds
        private AddressModel _passedInAddress;
        #endregion

        #region Constructor
        public AddressDisplay()
        {
            InitializeDemoData();
        }
        #endregion

        #region Full Properties
        public AddressModel DisplaySiteAddress { get; set; }

        #endregion

        #region Methods
        private void InitializeDemoData()
        {
            DisplaySiteAddress = new AddressModel()
            {Address = "SomeAddress", Id = 1, Atoll = "S", Island = "Hithadhoo" };
        }
        private void RequestAddressChange()
        {
            OnAddressChangeRequested.InvokeAsync(new AddressModel() 
            {
                IsAddressEditingEnabled = true,
                Address = DisplaySiteAddress.Address,
                Id = DisplaySiteAddress.Id,
                Atoll = DisplaySiteAddress.Atoll,
                Island = DisplaySiteAddress.Island
            });
        }

        #endregion

    }
}
