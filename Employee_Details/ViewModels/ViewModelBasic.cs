using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
namespace Employee_Details.ViewModels
{
    class ViewModelBasic:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
   
    }
}
