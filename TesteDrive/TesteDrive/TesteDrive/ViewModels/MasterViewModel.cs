using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TesteDrive.Media;
using TesteDrive.Models;
using TesteDrive.Views;
using Xamarin.Forms;

namespace TesteDrive.ViewModels
{
    public class MasterViewModel : BaseViewModel
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

		private bool editando = false;

		public bool Editando
		{
			get { return editando; }
			set 
			{ 
				editando = value;
				OnPropertyChanged();
			}
		}


		private ImageSource fotoPerfil = "perfil.png";

		public ImageSource FotoPerfil
		{
			get { return fotoPerfil; }
			set { fotoPerfil = value; }
		}


		public ICommand EditarPerfilCommand { get; private set; }

		public ICommand SalvarCommand { get; private set; }

		public ICommand EditarCommand { get; private set; }

		public ICommand TirarFotoCommand { get; private set; }

		private readonly Usuario usuario;
		public MasterViewModel(Usuario usuario)
		{
			this.usuario = usuario;
			DefinirComandos(usuario);
		}

		private void DefinirComandos(Usuario usuario)
		{
			this.EditarPerfilCommand = new Command(() =>
			{
				MessagingCenter.Send<Usuario>(usuario, "EditarPerfil");
			});

			this.SalvarCommand = new Command(() =>
			{
				Editando = false;
				MessagingCenter.Send<Usuario>(this.usuario, "SucessoSalvarPerfil");
			});

			this.EditarCommand = new Command(() => 
			{
				Editando = true;
			});

			this.TirarFotoCommand = new Command(() => 
			{
				DependencyService.Get<ICamera>().TirarFoto(); //Para um classe ser incluída no DependecyService ela precisa ter uma anotação no seu name space, como foi feita no MainActivity do projeto Droid
			});
		}
	}
}
