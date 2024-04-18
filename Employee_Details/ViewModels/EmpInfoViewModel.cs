using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Employee_Details.Model;
using SQLite;
using Xamarin.Forms;
using Employee_Details.Commands;
namespace Employee_Details.ViewModels
{
    class EmpInfoViewModel : ViewModelBasic
    {

        SQLiteConnection con;
        public EmpInfoViewModel()
        {
            con = DependencyService.Get<ISQLite>().GetConnection();
            var list = from details in con.Table<EmpDetails>() select details;
            EmpList = list.ToList();

        }

        public List<EmpDetails> emp;
        public List<EmpDetails> EmpList
        {
            get
            {
                //var list = from details in con.Table<EmpDetails>() select details;
                //return list.ToList();
                return emp;

            }
            set
            {
                emp = value;
                OnPropertyChanged(nameof(EmpList));
            }




        }

        public MyCommand Searchcmd
         {
            get
            {
                return new MyCommand(search);
            }
         }

        private string searchtext;

        public string SearchText
        {
            get { return searchtext; }
            set { searchtext = value; }
        }


        public void search(Object obj)
        {
            List<EmpDetails> templist = EmpList.Where(x => x.firstname.Contains(SearchText)).ToList();
            EmpList = templist;
            
            

        }
        private EmpDetails selectedemp;

        public EmpDetails SelectedEmp
        {
            get { return selectedemp; }
            set
            {
                selectedemp = value;
                OnPropertyChanged(nameof(selectedemp));
                
            }
        }

        public MyCommand DeleteCommand
        {
            get
            {
                return new MyCommand(delete);
            }
        }

        public void delete(Object Parameter)
        {
             //var query = con.Table<EmpDetails>().Delete(emp=> emp.email == selectedemp.email);
            if(SelectedEmp!=null)
            {
                con.Delete(SelectedEmp);
                var list = from details in con.Table<EmpDetails>() select details;
                EmpList = list.ToList();
                App.Current.MainPage.DisplayAlert("Delete", "Record Successfully Deleted", "Ok");
                

            }else
            {
                App.Current.MainPage.DisplayAlert("Delete", "First Select Record", "Ok");
            }








        }
    }
}
