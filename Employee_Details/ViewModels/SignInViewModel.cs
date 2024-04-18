using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;
using Employee_Details.Model;
using Employee_Details.Views;
using Employee_Details.Commands;

namespace Employee_Details.ViewModels
{
    class SignInViewModel:ViewModelBasic
    {
        SQLiteConnection con;
        public SignInViewModel()
        {
            con = DependencyService.Get<ISQLite>().GetConnection();

        }
        private string email_Id=null;

        public string Email_ID
        {
            get { return email_Id; }
            set { email_Id = value;
                OnPropertyChanged(nameof(Email_ID));
            }
        }

        public MyCommand LoginCommand
        {
            get
            {
                return new MyCommand(login);
            }
        }

        private string password=null;

        public string Password
        {
            get { return password; }
            set { password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public MyCommand SignupCommand
        {
            get
            {
                return new MyCommand(signup);
            }
        }
        public void signup(Object Parameter)
        {
            App.Current.MainPage.Navigation.PushAsync(new Signup());
        }
        public void login(Object Parameter)
        {
          EmpDetails existingRecord = con.Table<EmpDetails>()
              .Where(x => x.email == Email_ID && x.password == Password).FirstOrDefault();


            if (Password!=null &&Email_ID!=null)
            {
                if(existingRecord!=null)
                {
                    App.Current.MainPage.DisplayAlert("Login", "Login Successful!", "ok");
                 
                   
                    App.Current.MainPage.Navigation.PushAsync(new UserPage());
                    MessagingCenter.Send<EmpDetails>(existingRecord, "Received");
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Login", "Invalid Login Credential", "ok");
                }

            }
            else
            {
                App.Current.MainPage.DisplayAlert("Login", "Enter ID and Password", "ok");
            }
           
        }


    }
}

