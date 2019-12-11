using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TesteDrive.Models;
using Xamarin.Forms;

namespace TesteDrive.ViewModels
{
    public class ListagemViewModel
    {
        const string URL_GET_VEICULOS = "http://aluracar.herokuapp.com/";
        public List<Veiculo> Veiculos { get; set; }

        Veiculo veiculoSelecionado;
        public Veiculo VeiculoSelecionado
        {
            get
            {
                return veiculoSelecionado;
            }
            set
            {
                veiculoSelecionado = value;
               if (veiculoSelecionado != null)
                   MessagingCenter.Send(veiculoSelecionado, "VeiculoSelecionado");
            }
        }

        public ListagemViewModel()
        {
            this.Veiculos = new List<Veiculo>();
        }

        public void GetVeiculos()
        {
            HttpClient cliente = new HttpClient();
        }
    }
}
