using System.Collections.Generic;
using FP_Practice.Models;

namespace FP_Practice.Repositories
{
    public class FakeContext {

        public List<Album> Albums = new List<Album> () {
            new Album () { AlbumId = 1, Name = "Satellite Flight: The Journey To Mother Moon", Artist = new Artist () { FirstName = "Scott", LastName = "Mescudi", Id = 1 } },
            new Album () { AlbumId = 2, Name = "Yeezus", Artist = new Artist () { FirstName = "Kanye", LastName = "West", Id = 2 } },
            new Album () { AlbumId = 3, Name = "The Wall", Artist = new Artist () { FirstName = "Pink Floyd", Id = 3 } },
            new Album () { AlbumId = 1, Name = "Speedin' Bullet 2 Heaven", Artist = new Artist () { FirstName = "Scott", LastName = "Mescudi", Id = 1 } },
        };

        public List<Artist> Artists = new List<Artist> () {
            new Artist () { FirstName = "Scott", LastName = "Mescudi", Id = 1 },
            new Artist () { FirstName = "Kanye", LastName = "West", Id = 2 },
            new Artist () { FirstName = "Pink Floyd", Id = 3 }
        };
    }
}