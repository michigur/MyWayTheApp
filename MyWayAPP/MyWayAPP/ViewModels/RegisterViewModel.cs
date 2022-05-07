using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using MyWayAPP.Services;
using MyWayAPP.Views;
using MyWayAPP.Models;
using Xamarin.Essentials;
using System.Linq;
using System.Net.Mail;

namespace MyWayAPP.ViewModels
{
    class RegisterViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                ValidateEmail();
                OnPropertyChanged("Email");
            }

        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                ValidateFirstName();
                OnPropertyChanged("FirstName");
            }
        }


        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                ValidateLastName();
                OnPropertyChanged("LastName");
            }
        }


       


        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                ValidatePassword();
                OnPropertyChanged("Password");
            }
        }
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                ValidateUsername();
                OnPropertyChanged("Username");
            }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        private string cvv;
        public string CVV
        {
            get { return cvv; }
            set
            {
                cvv = value;
                ValidateCVV();
                OnPropertyChanged("CVV");
            }
        }

       

        private String creditNum;
        public String CreditNum
        {
            get { return creditNum; }
            set
            {
                creditNum = value;
                OnPropertyChanged("CreditNum");
            }
        }


        private String gender;
        public String Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }


        private DateTime birthDate;
        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                birthDate = value;
                ValidateAge();
                OnPropertyChanged("BirthDate");
            }
        }

        private DateTime cardDate;
        public DateTime CardDate
        {
            get { return cardDate; }
            set
            {
                cardDate = value;
                OnPropertyChanged("CardDate");
            }
        }

      

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
            ShowPasswordError = true;
            if (string.IsNullOrEmpty(Password))
                PasswordError = "Password cannot be blank";
            else if (Password.Length < 6)
                PasswordError = "Password must be more than 8 characters";
            else
                ShowPasswordError = false;
        }

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
            ShowEmailError = true;
            if (!IsValid(Email))
                EmailError = "Email is not valid";
           
            else
                ShowEmailError = false;
        }
        public bool IsValid(string emailaddress)
        {
            if(emailaddress=="")return false;
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        private bool showUsernameError;

        public bool ShowUsernameError
        {
            get => showUsernameError;
            set
            {
                showUsernameError = value;
                OnPropertyChanged("ShowUsernameError");
            }
        }

        private string usernameError;

        public string UsernameError
        {
            get => usernameError;
            set
            {
                usernameError = value;
                OnPropertyChanged("UsernameError");
            }
        }

        private void ValidateUsername()
        {
            ShowUsernameError = false;


            if (string.IsNullOrEmpty(Username))
            {
                UsernameError = "Username cannot be blank";
                ShowUsernameError = true;
            }
        }



        private bool showGenderError;

        public bool ShowGenderError
        {
            get => showGenderError;
            set
            {
                showGenderError = value;
                OnPropertyChanged("ShowGenderError");
            }
        }

        private string genderError;

        public string GenderError
        {
            get => genderError;
            set
            {
                genderError = value;
                OnPropertyChanged("GenderError");
            }
        }

        private void ValidateGender()
        {
            ShowGenderError = false;


            if (string.IsNullOrEmpty(Gender))
            {
                GenderError = "Gender cannot be blank";
                ShowGenderError = true;
            }
        }






        private bool showfirstNameError;

        public bool ShowFirstNameError
        {
            get => showfirstNameError;
            set
            {
                showfirstNameError = value;
                OnPropertyChanged("ShowFirstNameError");
            }
        }

        private string firstNameError;

        public string FirstNameError
        {
            get => firstNameError;
            set
            {
                firstNameError = value;
                OnPropertyChanged("FirstNameError");
            }
        }

        private void ValidateFirstName()
        {
            ShowFirstNameError = false;


            if (string.IsNullOrEmpty(FirstName))
            {
                FirstNameError = "First Name cannot be blank";
                ShowFirstNameError = true;
            }
        }





        private bool showlastNameError;

        public bool ShowLastNameError
        {
            get => showlastNameError;
            set
            {
                showlastNameError = value;
                OnPropertyChanged("ShowLastNameError");
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
            ShowLastNameError = false;


            if (string.IsNullOrEmpty(LastName))
            {
                LastNameError = "Last Name cannot be blank";
                ShowLastNameError = true;
            }
        }





        private bool showAgeError;

        public bool ShowAgeError
        {
            get => showAgeError;
            set
            {
                showAgeError = value;
                OnPropertyChanged("ShowAgeError");
            }
        }
        private string ageError;

        public string AgeError
        {
            get => ageError;
            set
            {
                ageError = value;
                OnPropertyChanged("AgeError");
            }
        }
        private void ValidateAge()
        {
            ShowAgeError = true;
            if (DateTime.Now.Year-BirthDate.Year < 13)
                AgeError = "You must be older than 13 to sign up";
           
            else
                ShowAgeError = false;
        }

        private bool showCVVError;

        public bool ShowCVVError
        {
            get => showCVVError;
            set
            {
                showCVVError = value;
                OnPropertyChanged("ShowCVVError");
            }
        }
        private string cvvError;

        public string CVVError
        {
            get => cvvError;
            set
            {
                cvvError = value;
                OnPropertyChanged("CVVError");
            }
        }
        private void ValidateCVV()
        {
            ShowCVVError = true;
            if (CVV.Length > 4 || CVV.Length < 3)
                CVVError = "CVV Must Have 3-4 Digits";

            else
                ShowCVVError = false;
        }

        private bool showGeneralError;

        public bool ShowGeneralError
        {
            get => showGeneralError;
            set
            {
                showGeneralError = value;
                OnPropertyChanged("ShowGeneralError");
            }
        }

        private bool showCardDateError;

        public bool ShowCardDateError
        {
            get => showCardDateError;
            set
            {
                showCardDateError = value;
                OnPropertyChanged("ShowCardDateError");
            }
        }

        private string cardDateError;

        public string CardDateError
        {
            get => cardDateError;
            set
            {
                cardDateError = value;
                OnPropertyChanged("CardDateError");
            }
        }
        private void ValidateCardDate()
        {
            ShowCardDateError = true;
            if (DateTime.Now.Year - BirthDate.Year < 13)
                CardDateError = "Card is expired";

            else
                ShowAgeError = false;
        }

        private bool ValidateForm()
        {
            ValidateCardDate();
            ValidateGender();
            ValidateLastName();
           // ValidateFirstName();
            ValidatePassword();
            ValidateUsername();
            ValidateAge();
            ValidateCardDate();
            ValidateCVV();
            

            return !(ShowPasswordError || ShowUsernameError || ShowAgeError);
        }
        public ICommand SubmitCommand { protected set; get; }

        public RegisterViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }



        public async void OnSubmit()
        {
            if (ValidateForm())
            {
                MyWayAPIProxy proxy = MyWayAPIProxy.CreateProxy();
                Client u = new Client
                {
                    ClientName = FirstName,
                    ClientsLastName = LastName,
                    ClientsGenedr = Gender,
                    ClientsEmail = Email,
                    ClientsPassword = Password,
                    ClientsUsername = Username,
                    ClientCurrentLocation = Address,
                    ClientsBirthDay = BirthDate,
                    ClientCreditCardNumber = CreditNum,
                    ClientCreditCardDate = CardDate,
                    ClientCreditCardCvv =Convert.ToInt32(CVV),
                   
                };

                bool isReturned = await proxy.RegisterUser(u);

                if (isReturned == false)
                {
                    await Application.Current.MainPage.DisplayAlert("Sign Up Failed!", "Invalid input", "OK");

                }
                else
                {
                    App theApp = (App)Application.Current;
                    Page p = new ShowMap();
                    App.Current.MainPage = p;
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Sign Up Failed!", "Invalid input", "OK");
            }
        }
           

        public ICommand NevigateToSignIn => new Command(ToSignIn);
        void ToSignIn()
        {

            Page p = new LogInPage();
            App.Current.MainPage = p;
        }
    }
}
