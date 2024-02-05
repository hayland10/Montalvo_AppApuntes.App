namespace Montalvo_AppApuntes.Views;

public partial class HM_AllNotesPage : ContentPage
{
    public HM_AllNotesPage()
    {
        InitializeComponent();

    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        notesCollection.SelectedItem = null;
    }
}