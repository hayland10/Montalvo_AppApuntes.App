namespace Montalvo_ExamenP2;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Views.Notes), typeof(Views.Notes));
    }
}
