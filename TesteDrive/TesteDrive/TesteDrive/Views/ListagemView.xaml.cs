using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDrive.Models;
using Xamarin.Forms;

namespace TesteDrive.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ListagemView : ContentPage
    {
        public ListagemView()
        {
            InitializeComponent();
        }

        /* private void ListViewVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
         {
             var veiculo = (Veiculo)e.Item;

             //DisplayAlert("Test Drive", $"Você selecionou o carro {veiculo.Nome}, que custa {veiculo.Preco}", "OK");

             Navigation.PushAsync(new DetalheView(veiculo));
         } */

        protected override void OnAppearing() //Esse método é chamado na hora que a página
        {
            base.OnAppearing();
            //Subscribe é um método que procura  uma mensagem no MessagingCEnter com determinado nome para usar
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado",
                (msg) => {
                    Navigation.PushAsync(new DetalheView(msg));
                });
        }

        //Unsubscribe é um método que procura  uma mensagem no MessagingCEnter com determinado nome para deixar de usar
        protected override void OnDisappearing() 
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
        }
    }
}
