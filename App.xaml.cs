namespace Montalvo_AppApuntes;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Views.HM_Notes), typeof(Views.HM_Notes));
    }
}
