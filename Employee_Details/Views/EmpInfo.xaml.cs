using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Employee_Details.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmpInfo : ContentPage
    {
        public EmpInfo()
        {
            InitializeComponent();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}