using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Employee_Details.Model;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;

using Employee_Details.Commands;
namespace Employee_Details.ViewModels
{
    class SignupViewModel:ViewModelBasic
    {
        SQLiteConnection con;
        EmpDetails emp;

       public SignupViewModel()
       {
          
            con = DependencyService.Get<ISQLite>().GetConnection();
            con.CreateTable<EmpDetails>();
            
            
          
           
            
            
       }

        public MyCommand submitCommand
        {
            get { return new MyCommand(Submit); }
        }

       
    
        private string _firstname=null;

        public string FirstName
        {
            get { return _firstname; }
            set { _firstname = value;
                OnPropertyChanged(nameof(FirstName)); }
        }
        private string  _lastname=null;

        public string  LatName
        {
            get { return _lastname; }
            set { _lastname = value;
                OnPropertyChanged(nameof(LatName));
            }
        }

        private string _email=null;

        public string Email
        {
            get { return _email; }
            set { _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _moblileno=null;

        public string MoblileNo
        {
            get { return _moblileno; }
            set { _moblileno = value;
                OnPropertyChanged(nameof(MoblileNo));
            }
        }

        private string _password=null;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public  void Submit(Object parameter)
        {
            emp = new EmpDetails(FirstName,LatName,Email,MoblileNo,Password);
            
            var existingRecord = con.Table<EmpDetails>()
                .Where(x => x.email == Email || x.mobileno == MoblileNo).FirstOrDefault();
            if(FirstName!=null&&LatName!=null&&Email!=null&&MoblileNo!=null&&Password!=null)
            {
                con.Insert(emp);
                App.Current.MainPage.DisplayAlert("Submit", "Record Successfully Added", "Ok");
                FirstName = null;
                LatName = null;
                Email = null;
                MoblileNo = null;
                Password = null;

            }
            else if(existingRecord!=null)
            {
                App.Current.MainPage.DisplayAlert("Submit", "Duplicate Record", "Ok");
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Submit", "first fill all details", "Ok");
            }
               
        }


    }
}
