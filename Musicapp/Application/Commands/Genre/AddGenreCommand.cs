using System;
using Domain.Entities;
using Infrastructure;

namespace Application.Commands.GenreNamespace
{
    public class AddGenreCommand
    {
        public string Name { get; set; }

        public void Execute(FakeDatabase database)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException("Genre name cannot be null or empty.", nameof(Name));
            }

            var newGenre = new Genre
            {
                Id = Guid.NewGuid(),
                Name = this.Name
            };

            database.Genres.Add(newGenre);
        }
    }
}
