using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentoView : ContentPage
    {
        public Veiculo Veiculo { get; set; }
        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();

            //this.Title = veiculo.Nome;
            this.Veiculo = veiculo;

            this.BindingContext = this;
        }
    }
}