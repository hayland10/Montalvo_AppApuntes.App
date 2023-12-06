
using Montalvo_ExamenP2.Views;
using System.Collections.ObjectModel;

namespace Montalvo_ExamenP2.Models
{
    internal class AllNotes
    {
        public ObservableCollection<Note> Lista { get; set; } = new ObservableCollection<Note>();

        public AllNotes() =>
            LoadNotes();

        public void LoadNotes()
        {
            Lista.Clear();

            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<Note> notes = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, "*.notes.txt")

                                        // Each file name is used to create a new Note
                                        .Select(filename => new Note()
                                        {
                                            Filename = filename,
                                            Text = File.ReadAllText(filename),
                                            Date = File.GetCreationTime(filename)
                                        })

                                        // With the final collection of notes, order them by date
                                        .OrderBy(note => note.Date);

            // Add each note into the ObservableCollection
            foreach (Note note in notes)
                Lista.Add(note);
        }
    }
}
