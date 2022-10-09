namespace Blog.Domain.Entities
{
    public class MediaType : BaseEntity
    {
        public MediaType()
        {
            this.Medias = new HashSet<Media>();
        }

        public string Title { get; set; }

        public string MimeType { get; set; }

        public string FileExtension { get; set; }
        
        public string Icon { get; set; }
        
        public string Color { get; set; }

        public string UploadDir { get; set; }

        public virtual ICollection<Media> Medias { get; set; }
    }
}
