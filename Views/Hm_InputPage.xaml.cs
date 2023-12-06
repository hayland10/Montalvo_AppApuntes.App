using Montalvo_AppApuntes.Models;

namespace Montalvo_ExamenP2.Views;

public partial class Hm_InputPage : ContentPage
{
	public Hm_InputPage()
	{
		InitializeComponent();
        BindingContext = new HM_InputData();
    }
    private void Calcular_Clicked(object sender, EventArgs e)
    {
        
    }
    private void Limpiar_Clicked(object sender, EventArgs e)
    {


        BindingContext = new HM_InputData();
       
    }
}