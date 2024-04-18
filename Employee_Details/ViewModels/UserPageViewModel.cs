using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Employee_Details.Model;
using Employee_Details.Commands;
namespace Employee_Details.ViewModels
{
    class UserPageViewModel:ViewModelBasic
    {

        public UserPageViewModel()
        {
            MessagingCenter.Subscribe<EmpDetails>(this, "Received", (value) => { Name = value.firstname; });
           
        }
   
   
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

       public MyCommand cmd
        {
            get
            {
                return new MyCommand(set);
            }
        }

        public void set(Object obj)
        {
            MessagingCenter.Subscribe<EmpDetails>(this, "Received", (value) => { Name = value.firstname; });
        }
        
    }
    
   
}
