using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class DetalheView : ContentPage
  {
    private const int FREIO_ABS = 800;
    private const int AR_CONDICIONADO = 1000;
    private const int MP3_PLAYER = 500;
    private bool temFreioABS;
    private bool temArCondicionado;
    private bool temMP3Player;

    public Veiculo Veiculo { get; set; }
    public string TextoFreioABS { get => $"Freio ABS - R$ {FREIO_ABS}"; }
    public string TextoArCondicionado { get => $"Ar Condicionado = R$ {AR_CONDICIONADO}"; }
    public string TextoMP3Player { get => $"MP3 Player = R$ {MP3_PLAYER}"; }
    public bool TemFreioABS
    {
      get => temFreioABS;
      set
      {
        temFreioABS = value;
        OnPropertyChanged(); //Notifica a página que houve uma mudança nessa propriedade que faz parte do binding
        OnPropertyChanged(nameof(ValorTotal));
      }
    }
    public bool TemArCondicionado
    {
      get => temArCondicionado;
      set
      {
        temArCondicionado = value;
        OnPropertyChanged();
        OnPropertyChanged(nameof(ValorTotal));
      }
    }
    public bool TemMP3Player
    {
      get => temMP3Player;
      set
      {
        temMP3Player = value;
        OnPropertyChanged();
        OnPropertyChanged(nameof(ValorTotal));
      }
    }
    public string ValorTotal
    {
      get => $"Valor total {Veiculo.Preco + (temFreioABS ? FREIO_ABS : 0) + (temArCondicionado ? AR_CONDICIONADO : 0) + (temMP3Player ? MP3_PLAYER : 0)}";
    }

    public DetalheView(Veiculo veiculo)
    {
      InitializeComponent();

      this.Veiculo = veiculo;

      this.BindingContext = this;
    }

    private void buttonProximo_Clicked(object sender, EventArgs e)
    {
      Navigation.PushAsync(new AgendamentoView(this.Veiculo));
    }
  }
}
