using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TesteDrive.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged //Classe que possui o Handler de Eventos que pode invocar o método OnChangedProperty, que é necessário para comunicação os componentes da aplicação
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") //O modifiador CallerMemberName faz com que se nenhum parâmetro for passado para o método, o membro que o chamou seja o próprio parãmetro
        {
            PropertyChanged? /* O operador de nulo-condicional é representado pelo ?. onde se a propriedade que está chamando um método for nula, o método não é executado */
                .Invoke(this /*Fonte do evento*/,
                new PropertyChangedEventArgs(name));
        }
    }
}
