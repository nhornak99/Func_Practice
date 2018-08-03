using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FP_Practice.Models;

namespace FP_Practice.Repositories {
    public class AlbumRepository : IAlbumRepository {
        internal FakeContext _context = new FakeContext();
        public Album GetAlbumById (int id) {
            Func<List<Album>, int, Album> findAlbum = (x, y) => x.Find (p => p.AlbumId == y);
            return findAlbum (_context.Albums, id);
        }

        private Func<IEnumerable<Album>, Artist, IOrderedEnumerable<Album>> GetAlbumsByArtist (Expression<Func<IEnumerable<Album>, Artist, IOrderedEnumerable<Album>> > query) {
            return query.Compile();
        }

        public IOrderedEnumerable<Album> FindArtistAlbums (string artistName) {
            List<Artist> artists = _context.Artists;
            List<Album> albums = _context.Albums;
            Func<Artist, string, bool> getArtist = (x, y) => x.FullName == y;
            Artist artist = artists.Find (a => getArtist (a, artistName));
            if (artist == null) {
                Console.WriteLine ("Artist not found.");
                return null;
            }
            Func<IEnumerable<Album>, Artist, IOrderedEnumerable<Album>> findAlbums = GetAlbumsByArtist ((x, y) => x.Where (a => a.Artist.Id == y.Id).OrderBy (w => w.Name));
            return findAlbums (albums, artist);
        }

        public IOrderedEnumerable<Album> GetAllAlbums () {
            List<Album> albums = _context.Albums;
            Func<IEnumerable<Album>, IOrderedEnumerable<Album>> getAlbums = GetAllOrderedAlbums(x => x.OrderBy(a => a.Name));
            return getAlbums(albums);
        }

        private Func<IEnumerable<Album>, IOrderedEnumerable<Album>> GetAllOrderedAlbums(Expression<Func<IEnumerable<Album>, IOrderedEnumerable<Album>>> query){
            return query.Compile();
        }

        public void Dispose () {
            throw new NotImplementedException ();
        }
    }
}