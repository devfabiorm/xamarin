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
    public partial class DetalheView : ContentPage
    {
        private const int FREIO_ABS = 800;
        private const int AR_CONDICIONADO = 10000;
        private const int MP3_PLAYER = 500;
        bool temFreioABS;
        bool temArCondicionado;
        bool temMP3Player;
        public Veiculo Veiculo { get; set; }
        public string TextoFreioABS
        {
            get
            {
                return $"Freio ABS - R$ {FREIO_ABS}";
            }
        }

        public string TextoArCondicionado
        {
            get
            {
                return $"Ar Condicionado R$ {AR_CONDICIONADO}";
            }
        }

        public string TextoMP3Player
        {
            get
            {
                return $"MP3 Player - R$ {MP3_PLAYER}";
            }
        }

        public bool TemFreioABS 
        { 
            get 
            {
                return temFreioABS;
            } 
            set 
            {
                temFreioABS = value; //valor que vem pelo Binding

                if (temFreioABS)
                {
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(ValorTotal));
                }
            }
        }

        public bool TemArCondicionado
        {
            get
            {
                return temArCondicionado;
            }
            set
            {
                temArCondicionado = value; //valor que vem pelo Binding

                if (temArCondicionado)
                {
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(ValorTotal));
                }
            }
        }

        public bool TemMP3Player
        {
            get
            {
                return temMP3Player;
            }
            set
            {
                temMP3Player = value; //valor que vem pelo Binding

                if (temMP3Player)
                {
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(ValorTotal));
                }
            }
        }

        public string ValorTotal
        {
            get
            {
                return $"Total R${Veiculo.Preco + (temFreioABS ? FREIO_ABS : 0)}";
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