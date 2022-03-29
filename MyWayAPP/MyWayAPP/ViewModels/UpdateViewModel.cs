using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using MyWayAPP.Services;
using MyWayAPP.Models;
using Xamarin.Essentials;
using System.Linq;
using MyWayAPP.Views;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;
using System.Collections.ObjectModel;

namespace MyWayAPP.ViewModels
{
    class UpdateViewModel: INotifyPropertyChanged
    {


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion



        #region FirstName
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

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                ValidateName();
                OnPropertyChanged("Name");
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

        private void ValidateName()
        {
            this.ShowNameError = string.IsNullOrEmpty(Name);
        }
        #endregion

        #region LastName
        private bool showLastNameError;
        public bool ShowLastNameError
        {
            get => showLastNameError;
            set
            {
                showLastNameError = value;
                OnPropertyChanged("ShowLastNameError");
            }
        }

        private string lastName;
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                ValidateLastName();
                OnPropertyChanged("LastName");
            }
        }

        private string lastNameError;
        public string LastNameError
        {
            get => lastNameError;
            set
            {
                lastNameError = value;
                OnPropertyChanged("LastNameError");
            }
        }

        private void ValidateLastName()
        {
            this.ShowLastNameError = string.IsNullOrEmpty(LastName);
        }
        #endregion

        #region Password
        private bool showPasswordError;
        public bool ShowPasswordError
        {
            get => showPasswordError;
            set
            {
                showPasswordError = value;
                OnPropertyChanged("ShowPasswordError");
            }
        }

        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                ValidatePassword();
                OnPropertyChanged("Password");
            }
        }

        private string passwordError;
        public string PasswordError
        {
            get => passwordError;
            set
            {
                passwordError = value;
                OnPropertyChanged("PasswordError");
            }
        }

        private void ValidatePassword()
        {
            this.ShowPasswordError = string.IsNullOrEmpty(Password);
            if (!this.ShowPasswordError)
            {
                if (this.Password.Length < 6)
                {
                    this.ShowPasswordError = true;
                   // this.PasswordError = ERROR_MESSAGES.SHORT_PASS;
                }
            }
            else { }
               // this.PasswordError = ERROR_MESSAGES.REQUIRED_FIELD;
        }
        #endregion

        #region UserName
        private bool showUserNameError;
        public bool ShowUserNameError
        {
            get => showUserNameError;
            set
            {
                showUserNameError = value;
                OnPropertyChanged("ShowUserNameError");
            }
        }

        private string userName;
        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                ValidateUserName();
                OnPropertyChanged("UserName");
            }
        }

        private string userNameError;
        public string UserNameError
        {
            get => userNameError;
            set
            {
                userNameError = value;
                OnPropertyChanged("UserNameError");
            }
        }

        private void ValidateUserName()
        {
            this.ShowUserNameError = string.IsNullOrEmpty(UserName);
        }
        #endregion

        #region Email
        private bool showEmailError;
        public bool ShowEmailError
        {
            get => showEmailError;
            set
            {
                showEmailError = value;
                OnPropertyChanged("ShowEmailError");
            }
        }

        private string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                ValidateEmail();
                OnPropertyChanged("Email");
            }
        }

        private string emailError;
        public string EmailError
        {
            get => emailError;
            set
            {
                emailError = value;
                OnPropertyChanged("EmailError");
            }
        }

        private void ValidateEmail()
        {
            this.ShowEmailError = string.IsNullOrEmpty(Email);
            if (!this.ShowEmailError)
            {
                if (!Regex.IsMatch(this.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                {
                    this.ShowEmailError = true;
                    //this.EmailError = ERROR_MESSAGES.BAD_EMAIL;
                }
            }
            else { }
               // this.EmailError = ERROR_MESSAGES.REQUIRED_FIELD;
        }




        #region BirthDate
        private bool showBirthDateError;
        public bool ShowBirthDateError
        {
            get => showBirthDateError;
            set
            {
                showBirthDateError = value;
                OnPropertyChanged("ShowBirthDateError");
            }
        }

        private DateTime birthDate;
        public DateTime BirthDate
        {
            get => birthDate;
            set
            {
                birthDate = value;
                ValidateBirthDate();
                OnPropertyChanged("BirthDate");
            }
        }

        private string birthDateError;
        public string BirthDateError
        {
            get => birthDateError;
            set
            {
                birthDateError = value;
                OnPropertyChanged("BirthDateError");
            }
        }

        private const int MIN_AGE = 18;
        private void ValidateBirthDate()
        {
            TimeSpan ts = DateTime.Now - this.BirthDate;
            this.ShowBirthDateError = ts.TotalDays < (MIN_AGE * 365);
        }
        #endregion


        public Command SaveDataCommand { protected set; get; }
        public ICommand ProfilePageCommand { protected set; get; }
        public ICommand LogOutCommand { protected set; get; }


        #region Constructor
        public UpdateViewModel()
        {


            App theApp = (App)App.Current;

           
            Client currentUser = theApp.CurrentUser;

          

            this.Email = currentUser.ClientsEmail;
            this.UserName = currentUser.ClientsUsername;
            this.Password = currentUser.ClientsPassword;
            this.Name = currentUser.ClientName;
            this.LastName = currentUser.ClientsLastName;
            this.BirthDate = currentUser.ClientsBirthDay;

            
            
            

            //set the path url to the contact photo
            MyWayAPIProxy proxy = MyWayAPIProxy.CreateProxy();
           

            //this.EmailError = ERROR_MESSAGES.BAD_EMAIL;
            //this.UserNameError = ERROR_MESSAGES.REQUIRED_FIELD;
            //this.PasswordError = ERROR_MESSAGES.SHORT_PASS;
            //this.NameError = ERROR_MESSAGES.REQUIRED_FIELD;
            //this.LastNameError = ERROR_MESSAGES.REQUIRED_FIELD;
            //this.BirthDateError = ERROR_MESSAGES.BAD_DATE;
          

            this.ShowEmailError = false;
            this.ShowUserNameError = false;
            this.ShowPasswordError = false;
            this.ShowNameError = false;
            this.ShowLastNameError = false;
            this.ShowBirthDateError = false;
            

            this.SaveDataCommand = new Command(() => SaveData());
           
            ProfilePageCommand = new Command(OnHome);
           
            LogOutCommand = new Command(OnLogOut);
        }
        #endregion

        #region ValidateForm
        private bool ValidateForm()
        {
            //Validate all fields first
            ValidatePassword();
            ValidateName();
            ValidateLastName();
            ValidateBirthDate();
           

            //check if any validation failed
            if (ShowPasswordError || ShowNameError || ShowLastNameError
                || ShowBirthDateError )
                return false;
            return true;
        }
        #endregion

        #region SaveData
        private async void SaveData()
        {
            if (ValidateForm())
            {
              
                App theApp = (App)App.Current;
                Client newUser = new Client()
                {
                    ClientId = theApp.CurrentUser.ClientId,
                    ClientsEmail = this.Email,
                    ClientsUsername = this.UserName,
                    ClientsPassword = this.Password,
                    ClientName = this.Name,
                    ClientsLastName = this.LastName,
                    ClientsBirthDay = this.BirthDate,
                    
                };

                MyWayAPIProxy proxy = MyWayAPIProxy.CreateProxy();
                Client user = await proxy.UpdateUser(newUser);

                if (user == null)


                {
                    await App.Current.MainPage.Navigation.PopModalAsync();
                    await App.Current.MainPage.DisplayAlert("שגיאה", "העדכון נכשל", "אישור", FlowDirection.RightToLeft);
                }
                else
                {
                   

                    theApp.CurrentUser = user;
                    await App.Current.MainPage.Navigation.PopModalAsync();

                    Page page;

                    page = new ProfilePage();
                   
                    App.Current.MainPage = new NavigationPage(page) { BarBackgroundColor = Color.FromHex("#81cfe0") };
                    await App.Current.MainPage.DisplayAlert("עדכון", "העדכון בוצע בהצלחה", "אישור", FlowDirection.RightToLeft);
                }
            }
            else
                await App.Current.MainPage.DisplayAlert("שמירת נתונים", " יש בעיה עם הנתונים בדוק ונסה שוב", "אישור", FlowDirection.RightToLeft);
        }
        #endregion


        #region OnHome
        public async void OnHome()
        {
            App theApp = (App)App.Current;
            Page page = new ShowMap();
           

            await App.Current.MainPage.Navigation.PopToRootAsync();
            //while (App.Current. != App.Current.MainPage)
            //await App.Current.MainPage.Navigation.PushAsync(page);
        }
        #endregion



        #region OnLogOut
        public async void OnLogOut()
        {
            bool answer = await App.Current.MainPage.DisplayAlert("התנתקות", "האם ברצונך להתנתק?", "התנתק", "ביטול", FlowDirection.RightToLeft);
            if (answer)
            {
                App theApp = (App)App.Current;
                theApp.CurrentUser = null;

                Page page = new LandingPage();
               
                App.Current.MainPage = new NavigationPage(page) ;
            }
        }
        #endregion
    }
}
#endregion