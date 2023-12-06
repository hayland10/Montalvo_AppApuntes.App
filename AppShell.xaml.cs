namespace Montalvo_ExamenP2;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(Views.Notes), typeof(Views.Notes));
    }
}
