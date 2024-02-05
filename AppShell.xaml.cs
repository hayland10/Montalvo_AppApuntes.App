namespace Montalvo_AppApuntes;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(Views.HM_Notes), typeof(Views.HM_Notes));
    }
}
