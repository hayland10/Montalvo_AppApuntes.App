using CommunityToolkit.Mvvm.Input;
using Montalvo_AppApuntes.ViewModels;
using Montalvo_AppApuntes.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Montalvo_AppApuntes.ViewModels;

internal class HM_NotesViewModel : IQueryAttributable
{
    public ObservableCollection<ViewModels.HM_NoteViewModel> AllNotes { get; }
    public ICommand NewCommand { get; }
    public ICommand SelectNoteCommand { get; }

    public HM_NotesViewModel()
    {
        AllNotes = new ObservableCollection<ViewModels.HM_NoteViewModel>(Models.Note.LoadAll().Select(n => new HM_NoteViewModel(n)));
        NewCommand = new AsyncRelayCommand(NewNoteAsync);
        SelectNoteCommand = new AsyncRelayCommand<ViewModels.HM_NoteViewModel>(SelectNoteAsync);
    }

    private async Task NewNoteAsync()
    {
        await Shell.Current.GoToAsync(nameof(Views.HM_Notes));
    }

    private async Task SelectNoteAsync(ViewModels.HM_NoteViewModel note)
    {
        if (note != null)
            await Shell.Current.GoToAsync($"{nameof(Views.HM_Notes)}?load={note.Identifier}");
    }

    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("deleted"))
        {
            string noteId = query["deleted"].ToString();
            HM_NoteViewModel matchedNote = AllNotes.Where((n) => n.Identifier == noteId).FirstOrDefault();

            // If note exists, delete it
            if (matchedNote != null)
                AllNotes.Remove(matchedNote);
        }
        else if (query.ContainsKey("saved"))
        {
            string noteId = query["saved"].ToString();
            HM_NoteViewModel matchedNote = AllNotes.Where((n) => n.Identifier == noteId).FirstOrDefault();

            // If note is found, update it
            if (matchedNote != null) { 
                 matchedNote.Reload();
                AllNotes.Move(AllNotes.IndexOf(matchedNote), 0);
            }
                
                

            // If note isn't found, it's new; add it.
            else
                AllNotes.Insert(0, new HM_NoteViewModel(Models.Note.Load(noteId)));

        }
    }
}