using System;
using Xunit;
using Domain.Entities;
using Infrastructure;
using Application.Commands.GenreNamespace;

namespace Test
{
    public class GenreTests
    {
        [Fact]
        public void AddGenreCommand_ShouldAddGenreToDatabase()
        {
            
            var fakeDatabase = new FakeDatabase();
            var command = new AddGenreCommand { Name = "Rock" };

            
            command.Execute(fakeDatabase);

            
            Assert.Single(fakeDatabase.Genres);
            Assert.Equal("Rock", fakeDatabase.Genres[0].Name);
        }

        [Fact]
        public void AddGenreCommand_ShouldThrowException_WhenNameIsEmpty()
        {
            
            var fakeDatabase = new FakeDatabase();
            var command = new AddGenreCommand { Name = "" };

            
            Assert.Throws<ArgumentException>(() => command.Execute(fakeDatabase));
        }

        [Fact]
        public void FakeDatabase_ShouldStartWithEmptyGenres()
        {
            
            var fakeDatabase = new FakeDatabase();

            
            Assert.Empty(fakeDatabase.Genres);
        }

        [Fact]
        public void AddGenreCommand_ShouldGenerateUniqueIdForEachGenre()
        {
            
            var fakeDatabase = new FakeDatabase();
            var command1 = new AddGenreCommand { Name = "Pop" };
            var command2 = new AddGenreCommand { Name = "Jazz" };

            
            command1.Execute(fakeDatabase);
            command2.Execute(fakeDatabase);

            
            Assert.NotEqual(fakeDatabase.Genres[0].Id, fakeDatabase.Genres[1].Id);
        }
    }
}
