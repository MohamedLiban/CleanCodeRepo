using Domain.Entities;
using System.Collections.Generic;

namespace Infrastructure
{
    public class FakeDatabase
    {
        private static FakeDatabase _instance;

        public static FakeDatabase Instance => _instance ??= new FakeDatabase();

        public List<Genre> Genres { get; set; } = new List<Genre>();
        public List<MusicArtist> MusicArtists { get; set; } = new List<MusicArtist>();
    }
}
