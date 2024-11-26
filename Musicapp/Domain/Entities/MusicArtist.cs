using System;

namespace Domain.Entities
{
    public class MusicArtist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid GenreId { get; set; }
    }
}
