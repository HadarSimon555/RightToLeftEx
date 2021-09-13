using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RightToLeftEx.ViewModel
{
    class MainPageViewModel : ModelViewBase
    {
        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                ValidateName() ;
                OnPropertyChanged("Name");
            }
        }

        private bool showNameError;
        public bool ShowNameError
        {
            get => showNameError;
            set
            {
                showNameError = value;
                OnPropertyChanged("ShowNameError");
            }
        }

        private string nameError;
        public string NameError
        {
            get => nameError;
            set
            {
                nameError = value;
                OnPropertyChanged("NameError");
            }
        }

        private void ValidateName ()
        {
            ShowNameError = string.IsNullOrEmpty(Name);
            NameError = "שדה לא יכול להיות ריק";
        }

        public MainPageViewModel()
        {
            name = "";
            nameError = "";
        }

        public ICommand SaveDataCommand { get; protected set; }
        private bool ValidateForm()
        {
            ValidateName();
            return showNameError; 
        }

        private async void SaveData()
        {
            if (ValidateForm())
                await App.Current.MainPage.DisplayAlert("שמירת נתונים", "הנתונים נבדקו ונשמרו", "אישור", FlowDirection.RightToLeft);
            else
                await App.Current.MainPage.DisplayAlert("שמירת נתונים", "יש בעיה עם הנתונים", "אישור", FlowDirection.RightToLeft);
        }
    }
}
