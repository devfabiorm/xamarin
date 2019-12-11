using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDrive.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentoView : ContentPage
    {
        public Agendamento Agendamento { get; set; }
        public Veiculo Veiculo 
        { 
            get 
            {
                return Agendamento.Veiculo;
            }
            set
            {
                Agendamento.Veiculo = value;
            }
        }
        public string Nome
        {
            get 
            {
                return Agendamento.Nome;
            }
            set 
            {
                Agendamento.Nome = value;
            }
        }
        public string Fone
        {
            get 
            {
                return Agendamento.Fone;
            }
            set 
            {
                Agendamento.Fone = value;
            } 
        }
        public string Email
        {
            get 
            {
                return Agendamento.Email;
            }
            set 
            {
                Agendamento.Email = value;
            }
        }

        public DateTime DataAgendamento 
        {
            get 
            {
                return Agendamento.DataAgendamento;
            }
            set 
            {
                Agendamento.DataAgendamento = value;
            } 
        }
        public TimeSpan HoraAgendamento
        {
            get
            {
                return Agendamento.HoraAgendamento;
            }
            set
            {
                Agendamento.HoraAgendamento = value;
            }
        }
        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();

            //this.Title = veiculo.Nome;
            this.Agendamento = new Agendamento();

            Agendamento.Veiculo = veiculo;

            this.BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Agendamento",
$@"Veículo: {Veiculo.Nome}
Nome: {Nome}
Fone: {Fone}
E-mail: {Email}
Data Agendada: {DataAgendamento.ToString("dd/MM/yyyy")}
Hora Agendada: {HoraAgendamento}",
        "OK");
        }
    }
}