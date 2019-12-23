using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TesteDrive.Models;
using TesteDrive.Views;
using Xamarin.Forms;

namespace TesteDrive
{
    public class LoginService
    {
		public async Task FazerLogin(Login login)
		{
			try
			{
				using (var cliente = new HttpClient())
				{
					var camposFormulario = new FormUrlEncodedContent(new[]
					{
						new KeyValuePair<string, string>("email", login.email),
						new KeyValuePair<string, string>("senha", login.senha)
				});
					cliente.BaseAddress = new Uri("https://aluracar.herokuapp.com");
					var resultado = await cliente.PostAsync("/login", camposFormulario);
					if (resultado.IsSuccessStatusCode)
					{
						var conteudoResultado = await resultado.Content.ReadAsStringAsync();
						var resultadoLogin = JsonConvert.DeserializeObject<ResultadoLogin>(conteudoResultado);
						MessagingCenter.Send<Usuario>(resultadoLogin.usuario, "SucessoLogin");
					}
					else
						MessagingCenter.Send<LoginExcepetion>(new LoginExcepetion("Usuário ou Senha incorretos"), "FalhaLogin");
				}
			}
			catch
			{

				MessagingCenter.Send<LoginExcepetion>(new LoginExcepetion(@"Ocorreu um erro de comunicação com o servidor.
Por favor verifique sua conexão e tente mais tarde"), "FalhaLogin");
			}
		}
	}

	public class LoginExcepetion : Exception
	{
		public LoginExcepetion(string message) : base(message)
		{

		}
	}
}
