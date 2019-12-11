using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDrive.Models;
using TesteDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentoView : ContentPage
    {
        public AgendamentoViewModel ViewModel { get; set; }
        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();

            //this.Title = veiculo.Nome;
            
            this.ViewModel = new AgendamentoViewModel(veiculo);

            this.BindingContext = this.ViewModel;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Agendamento",
            $@"Veículo: {ViewModel.Agendamento.Veiculo.Nome}
Nome: {ViewModel.Agendamento.Nome}
Fone: {ViewModel.Agendamento.Fone}
E-mail: {ViewModel.Agendamento.Email}
Data Agendada: {ViewModel.Agendamento.DataAgendamento.ToString("dd/MM/yyyy")}
Hora Agendada: {ViewModel.Agendamento.HoraAgendamento}",
"OK");
        }
    }
}