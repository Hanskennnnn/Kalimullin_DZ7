
namespace Tumakov_DZ
{
    class Song
    {
        private string name; 
        private string author; 
        private Song prev; 


        public void SetName(string songName)
        {
            name = songName;
        }

  
        public void SetAuthor(string songAuthor)
        {
            author = songAuthor;
        }

   
        public void SetPrev(Song previousSong)
        {
            prev = previousSong;
        }

  
        public string Title()
        {
            return $"{name} by {author}";
        }


        public override bool Equals(object obj)
        {
            if (obj is Song otherSong)
            {
                return this.name == otherSong.name && this.author == otherSong.author;
            }
            return false;
        }
    }
}
