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
    public partial class DetalheView : ContentPage
    {
        public Veiculo Veiculo { get; set; }
        public string TextoFreioABS
        {
            get
            {
                return $"Freio ABS - R$ {Veiculo.FREIO_ABS}";
            }
        }

        public string TextoArCondicionado
        {
            get
            {
                return $"Ar Condicionado R$ {Veiculo.AR_CONDICIONADO}";
            }
        }

        public string TextoMP3Player
        {
            get
            {
                return $"MP3 Player - R$ {Veiculo.MP3_PLAYER}";
            }
        }

        public bool TemFreioABS 
        { 
            get 
            {
                return Veiculo.TemFreioABS;
            }
            set
            {
                Veiculo.TemFreioABS = value; //valor que vem pelo Binding

                //OnPropertyChanged(); //Monitora a mudança na propriedade atual
                OnPropertyChanged(nameof(ValorTotal)); //Monitora a mudança do propriedade matual e aciona a que foi passada como parâmetro
            }   
        }

        public bool TemArCondicionado
        {
            get
            {
                return Veiculo.TemArCondicionado;
            }
            set
            {
                Veiculo.TemArCondicionado = value; //valor que vem pelo Binding
            
                //OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public bool TemMP3Player
        {
            get
            {
                return Veiculo.TemMP3Player;
            }
            set
            {
                Veiculo.TemMP3Player = value; //valor que vem pelo Binding

                //OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public string ValorTotal
        {
            get
            {
                return Veiculo.PrecoTotalFormatado;
            }
        }

        public DetalheView(Veiculo veiculo)
        {
            InitializeComponent();

            //this.Title = veiculo.Nome;

            this.Veiculo = veiculo;

            this.BindingContext = this;
        }

        private void BotaoProximo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoView(Veiculo));
        }
    }
}