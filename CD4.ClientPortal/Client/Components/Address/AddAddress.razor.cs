using CD4.ClientPortal.Shared.Models;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CD4.ClientPortal.Client.Components.Address
{
    public partial class AddAddress
    {
        private bool _success;
        private MudForm _form;
        private string[] _errors;
        private string _address;
        private string _selectedAtoll;
        private string _selectedIsland;

        public AddAddress()
        {
            AtollsAndIslands = new();
            DistinctAtolls = new();
            FilteredIslands = new();

            InitializeDemoData();
            ExtractDistinctAtolls();
        }

        private void ExtractDistinctAtolls()
        {
            foreach (var data in AtollsAndIslands)
            {
                var addedAtoll = DistinctAtolls.Find((x) => x == data.Atoll);
                if (addedAtoll == null) { DistinctAtolls.Add(data.Atoll); }
            }
        }
        private void InitializeDemoData()
        {
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
        
        private string SelectedAtoll 
        {
            get { return _selectedAtoll; }
            set
            {
                if (_selectedAtoll != value)
                {
                    _selectedAtoll = value;
                    Console.WriteLine($"Selected Atoll: {value}");
                    FilterIslands();
                }
            }
        }
        private void FilterIslands()
        {
            _selectedIsland = "";
            FilteredIslands.Clear();
            Console.WriteLine("Clearaed filtered islands");

            var islands  = AtollsAndIslands.Where((x) => x.Atoll == SelectedAtoll).ToList();
            foreach (var islanddata in islands)
            {
                FilteredIslands.Add(islanddata.Island);
                Console.WriteLine($"Added to filtered island List: {islands}");
            }
            StateHasChanged();
        }

        private List<AtollAndIslandsData> AtollsAndIslands { get; set; }

        private List<string> DistinctAtolls;
        private List<string> FilteredIslands;
    }
}
