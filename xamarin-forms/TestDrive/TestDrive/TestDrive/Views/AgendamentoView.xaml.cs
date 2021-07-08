using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class AgendamentoView : ContentPage
  {
    private DateTime dataAgendamento = DateTime.Today;

    public Veiculo Veiculo { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public DateTime DataAgendamento { get => dataAgendamento; set => dataAgendamento = value; }
    public TimeSpan HoraAgendamento { get; set; }

    public AgendamentoView(Veiculo veiculo)
    {
      InitializeComponent();

      this.Veiculo = veiculo;

      this.BindingContext = this;
    }

    private void buttonAgendar_Clicked(object sender, EventArgs e)
    {
      DisplayAlert("Agendamento", $@"Nome: {Nome}
                                     Telefone: {Telefone}
                                     E-mail: {Email}
                                     Data Agendamento: {DataAgendamento:dd/MM/yyyy}
                                     Hora Agendamento: {HoraAgendamento}", "Ok");
    }
  }
}
