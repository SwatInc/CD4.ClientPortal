using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CD4.ClientPortal.Client.Pages.AddPatient
{
    public partial class AddPatient
    {
        private MudChip _mudchip;
        private string _nidPp;
        private string _fullname;
        private string _selectedGender;
        private string _patientNationality;
        private DateTime? _sampleCollectedDate;
        private DateTime? _sampleCollectedTime;

        private DateTime? _birthdate;

        bool mandatory = true;
        MudChip SelectedPatientType
        {
            get { return _mudchip; }
            set
            {
                _mudchip = value;
                Console.WriteLine($"selected chip: {_mudchip.Text}");
            }
        }
        public string SelectedGender
        {
            get { return _selectedGender; }
            set { _selectedGender = value; Console.WriteLine($"Gender: {_selectedGender}"); }
        }


        public string PatientNationality
        {
            get { return _patientNationality; }
            set { _patientNationality = value; }
        }


        public DateTime? Birthdate
        {
            get { return _birthdate; }
            set { _birthdate = value; Console.WriteLine($"Birthdate: {_birthdate}"); }
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

        public string NidPp
        {
            get { return _nidPp; }
            set { _nidPp = value; Console.WriteLine($"NidPp: {_nidPp}"); }
        }

        public string Fullname
        {
            get { return _fullname; }
            set { _fullname = value; Console.WriteLine($"Fullname: {_fullname}"); }
        }


        bool success;
        string[] errors = Array.Empty<string>();
        MudForm form;

        private async Task<IEnumerable<string>> NationalityLookup(string value)
        {
            //get countries data during initialization
            var nationalities = new List<string>() { "Maldives", "Malaysia" };

            await Task.Delay(1);
            return nationalities.FindAll((x) => x.ToLower().Contains(value.Trim().ToLower()))
                .ToList();
        }

        IList<IBrowserFile> files = new List<IBrowserFile>();
        private void UploadFiles(InputFileChangeEventArgs e)
        {
            foreach (var file in e.GetMultipleFiles())
            {
                files.Add(file);
            }
            Console.WriteLine($"Number of files: {files.Count}");
            //TODO upload the files to the server
        }
    }

}
