using CD4.ClientPortal.Shared.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CD4.ClientPortal.Client.Components.Address
{
    public partial class AddAddress
    {
        #region Injected Services
        [Inject] private IDialogService _dialogService { get; set; }

        #endregion

        #region Parameters
        [Parameter]
        public AddressModel PassedInAddress
        {
            get { return _passedInAddress; }
            set
            {
                _passedInAddress = value;
                SetInitialAddress();
            }
        }
        [Parameter]
        public EventCallback<AddressModel> OnAddressChanged { get; set; }

        #endregion

        #region Fileds
        private bool _success;
        private MudForm _form;
        private string[] _errors;
        private AddressModel _passedInAddress;
        private List<string> _distinctAtolls;
        private List<string> _filteredIslands;
        #endregion

        #region Constructor
        public AddAddress()
        {
            AtollsAndIslands = new();
            _distinctAtolls = new();
            _filteredIslands = new();

            InitializeDemoData();
            ExtractDistinctAtolls();
        }

        #endregion

        #region Full Properties
        private string SelectedAtoll
        {
            get { return _passedInAddress.Atoll; }
            set
            {
                if (_passedInAddress.Atoll != value)
                {
                    _passedInAddress.Atoll = value;
                    Console.WriteLine($"Selected Atoll: {value}");
                }

                FilterIslands();
            }
        }
        private List<AtollAndIslandsData> AtollsAndIslands { get; set; }

        #endregion

        #region Methods
        private void SetInitialAddress()
        {
            PassedInAddress.Address = _passedInAddress.Address;
            Console.WriteLine(_passedInAddress.Atoll);
            Console.WriteLine(_passedInAddress.Island);

            //look for Atoll and Island
            var atollAndIsland = AtollsAndIslands.FirstOrDefault((x) => 
            {
                return x.Atoll == _passedInAddress.Atoll &&
                       x.Island == _passedInAddress.Island;
            });

            if (atollAndIsland == null) {
                _dialogService.ShowMessageBox("Address not found",
                    "The default address set for the site cannot be found." +
                    $"\nAtoll: {_passedInAddress.Atoll} \nIsland:{_passedInAddress.Island}");
                return;
            }

            SelectedAtoll = atollAndIsland.Atoll;
            PassedInAddress.Island = atollAndIsland.Island;
        }
        private void ApplyAddressChanges()
        {
            OnAddressChanged.InvokeAsync(PassedInAddress);
        }
        private void ExtractDistinctAtolls()
        {
            foreach (var data in AtollsAndIslands)
            {
                var addedAtoll = _distinctAtolls.Find((x) => x == data.Atoll);
                if (addedAtoll == null) { _distinctAtolls.Add(data.Atoll); }
            }
        }
        private void InitializeDemoData()
        {
            //load this data from database
            AtollsAndIslands.AddRange(new List<AtollAndIslandsData>()
            {
                new AtollAndIslandsData() {Id=1, Atoll="S", Island="Hithadhoo"},
                new AtollAndIslandsData() {Id=2, Atoll="S", Island="Maradhoo"},
                new AtollAndIslandsData() {Id=3, Atoll="S", Island="Feydhoo"},
                new AtollAndIslandsData() {Id=4, Atoll="K", Island="Male'"},
                new AtollAndIslandsData() {Id=5, Atoll="K", Island="Villingilii'"},
                new AtollAndIslandsData() {Id=6, Atoll="K", Island="Hulhumale'"}
            });
        }
        private void FilterIslands()
        {
            PassedInAddress.Island = "";
            _filteredIslands.Clear();
            Console.WriteLine("Clearaed filtered islands");

            var islands = AtollsAndIslands.Where((x) => x.Atoll == SelectedAtoll).ToList();
            foreach (var islanddata in islands)
            {
                _filteredIslands.Add(islanddata.Island);
                Console.WriteLine($"Added to filtered island List: {islands}");
            }
            StateHasChanged();
        }

        #endregion


    }
}
