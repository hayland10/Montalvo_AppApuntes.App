using Montalvo_AppApuntes.Models;

namespace Montalvo_ExamenP2.Views;

public partial class Hm_InputPage : ContentPage
{
	public Hm_InputPage()
	{
		InitializeComponent();
        BindingContext = new HM_InputData();
    }
    
}