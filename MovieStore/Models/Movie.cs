namespace MovieStore.Models
{
    public class Movie
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
        public int[] Ratings { get; set; }
    }
}
