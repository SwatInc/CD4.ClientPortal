using CD4.ClientPortal.Shared.Models;
using System;

namespace CD4.ClientPortal.Client.Components.Address
{
    public partial class AddressDisplay
    {
        public AddressDisplay()
        {
            InitializeDemoData();
        }

        private void InitializeDemoData()
        {
            Address = "SOme Address";
            LoggedInSiteAddress = new AtollAndIslandsData()
            { Id = 1, Atoll = "S", Island = "Hithadhoo" };
        }

        public string Address { get; set; }
        public AtollAndIslandsData LoggedInSiteAddress { get; set; }
    }
}
