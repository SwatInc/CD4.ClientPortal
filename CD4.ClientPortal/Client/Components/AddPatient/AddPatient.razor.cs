using CD4.ClientPortal.Shared.Models;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CD4.ClientPortal.Client.Components.AddPatient
{
    public partial class AddPatient
    {
        #region Fileds
        private MudChip _mudchip;
        private string _nidPp;
        private string _fullname;
        private string _selectedGender;
        private string _patientNationality;
        private DateTime? _sampleCollectedDate;
        private DateTime? _sampleCollectedTime;
        private bool _isDisplayAddressVisible;
        private AddressModel _addressPassedIn;
        private string[] errors = Array.Empty<string>();
        private IList<IBrowserFile> files = new List<IBrowserFile>();
        private bool _canSavePatient { get { return _success == false || _isDisplayAddressVisible == false; } }
        bool _success;
        private DateTime? _birthdate;
        MudForm _form;
        #endregion

        #region Constructor
        public AddPatient()
        {
            _isDisplayAddressVisible = true;
        }

        #endregion

        #region Full Properties
        private bool mandatory = true;
        private MudChip SelectedPatientType
        {
            get { return _mudchip; }
            set
            {
                _mudchip = value;
                Console.WriteLine($"selected chip: {_mudchip.Text}");
            }
        }
        private string SelectedGender
        {
            get { return _selectedGender; }
            set { _selectedGender = value; Console.WriteLine($"Gender: {_selectedGender}"); }
        }
        private string PatientNationality
        {
            get { return _patientNationality; }
            set { _patientNationality = value; }
        }
        private DateTime? Birthdate
        {
            get { return _birthdate; }
            set { _birthdate = value; Console.WriteLine($"Birthdate: {_birthdate}"); }
        }
        private string NidPp
        {
            get { return _nidPp; }
            set { _nidPp = value; Console.WriteLine($"NidPp: {_nidPp}"); }
        }
        private string Fullname
        {
            get { return _fullname; }
            set { _fullname = value; Console.WriteLine($"Fullname: {_fullname}"); }
        }

        #region sample collected date and time
        public DateTime? SampleCollectedDate
        {
            get { return _sampleCollectedDate; }
            set { _sampleCollectedDate = value; }
        }


        public DateTime? SampleCollectedTime
        {
            get { return _sampleCollectedTime; }
            set { _sampleCollectedTime = value; }
        }


        #endregion

        #endregion

        #region Methods
        private async Task<IEnumerable<string>> NationalityLookup(string value)
        {
            //get countries data during initialization
            var nationalities = new List<string>() { "Maldives", "Malaysia" };

            await Task.Delay(1);
            return nationalities.FindAll((x) => x.ToLower().Contains(value.Trim().ToLower()))
                .ToList();
        }
        private void UploadFiles(InputFileChangeEventArgs e)
        {
            foreach (var file in e.GetMultipleFiles())
            {
                files.Add(file);
            }
            Console.WriteLine($"Number of files: {files.Count}");
            //TODO upload the files to the server
        }
        private void OnAddressChangeRequested(AddressModel addressCommunicationModel)
        {
            _addressPassedIn = null;
            _addressPassedIn = addressCommunicationModel;
            _isDisplayAddressVisible = false;

        }
        private void OnAddressChanged(AddressModel address)
        {
            _addressPassedIn = address;
            _isDisplayAddressVisible = true;
        }

        #endregion

    }

}
