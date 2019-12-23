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

        /*private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Agendamento",
            $@"Veículo: {ViewModel.Agendamento.Veiculo.Nome}
Nome: {ViewModel.Agendamento.Nome}
Fone: {ViewModel.Agendamento.Fone}
E-mail: {ViewModel.Agendamento.Email}
Data Agendada: {ViewModel.Agendamento.DataAgendamento.ToString("dd/MM/yyyy")}
Hora Agendada: {ViewModel.Agendamento.HoraAgendamento}",
"OK");
        }*/

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Agendamento>(this, "Agendamento", async (msg) =>
            {
                var confirma = await DisplayAlert("Agendar", "Deseja confirmar agendamento?", "SIM", "NÂO");

                if (confirma)
                {
                    ViewModel.SalvarAgendamento();
                }    
            });

            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento", (msg) => 
            {
                DisplayAlert("Agendamento", "Test Drive agendado com sucesso", "OK");
            });

            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaAgendamento", (msg) =>
            {
                DisplayAlert("Agendamento", "Falha ao tentar agendar Test Drive. Verifique os dados e tente novamente mais tarde.", "OK");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");

            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");

            MessagingCenter.Unsubscribe<ArgumentException>(this, "FalhaAgendamento");
        }
    }
}