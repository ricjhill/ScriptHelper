namespace ScriptHelper
{
    public class NotesMovieText
    {
        public string myMovieText { get; set; }
        public string myNote { get; set; }

        public string myLabel { get; set; } 

        public NotesMovieText(string x,string y, string z)
        {
            myMovieText = x;
            myNote = y;
            myLabel = z;
        }
    }
}
