namespace Montalvo_AppApuntes;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Views.Notes), typeof(Views.Notes));
    }
}
