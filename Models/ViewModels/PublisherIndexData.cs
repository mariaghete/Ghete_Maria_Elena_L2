namespace Ghete_Maria_Elena_L2.Models.ViewModels
{
    public class PublisherIndexData
    {
        public IEnumerable<Publisher> Publishers { get; set; }
        public IEnumerable<Book> Books
        {
            get;
            set;
        }
    }
}
