using FP_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FP_Practice.Repositories
{
    public interface IAlbumRepository : IDisposable{
        IOrderedEnumerable<Album> GetAllAlbums();

        Album GetAlbumById(int id);

        IOrderedEnumerable<Album> FindArtistAlbums(string artistName);
    }
}
