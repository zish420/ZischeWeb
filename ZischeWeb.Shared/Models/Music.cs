namespace ZischeWeb.Shared.Models
{
    public class Music
    {
        public int Id { get; set; }                    // Unique identifier for the music item
        public string Title { get; set; }              // Title of the music item
        public string Artist { get; set; }             // Artist name (if you collaborate with others)
        public string CoverImageUrl { get; set; }      // URL of the cover image
        public string Description { get; set; }        // Description or notes about the music item
        public string SpotifyLink { get; set; }        // Link to Spotify
        public string AppleMusicLink { get; set; }     // Link to Apple Music
        public string YouTubeLink { get; set; }        // Link to YouTube
    }

}
