﻿namespace Blog.Domain.Entities
{
    public class MediaType : BaseEntity
    {
        public MediaType()
        {
            this.Medias = new HashSet<Media>();
        }

        public string Title { get; set; }

        public string MimeType { get; set; }

        public virtual ICollection<Media> Medias { get; set; }
    }
}
