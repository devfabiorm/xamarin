using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TesteDrive.Models;
using TesteDrive.Views;
using Xamarin.Forms;

namespace TesteDrive.ViewModels
{
    public class MasterViewModel
    {
		private string nome;

		public string Nome
		{
			get { return this.usuario.Nome; }
			set { this.usuario.Nome = value; }
		}

		private string email;

		public string Email
		{
			get { return this.usuario.Email; }
			set { this.usuario.Email = value; }
		}

		private string telefone;

		public string Telefone
		{
			get { return this.usuario.Telefone; }
			set { this.usuario.Telefone = value; }
		}

		private string dataNascimento;

		public string DataNascimento
		{
			get { return this.usuario.DataNascimento; }
			set { this.usuario.DataNascimento = value; }
		}

		public ICommand EditarPerfilCommand { get; private set; }

		public ICommand SalvarPefilCommand { get; private set; }

		private readonly Usuario usuario;
		public MasterViewModel(Usuario usuario)
		{
			this.usuario = usuario;
			Comandos(usuario);
		}

		private void Comandos(Usuario usuario)
		{
			this.EditarPerfilCommand = new Command(() =>
			{
				MessagingCenter.Send<Usuario>(usuario, "EditarPerfil");
			});

			this.SalvarPefilCommand = new Command(() =>
			{
				MessagingCenter.Send<Usuario>(this.usuario, "SucessoSalvarPerfil");
			});
		}
	}
}
