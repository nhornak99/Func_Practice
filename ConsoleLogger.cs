using System;
using System.Linq;
using FP_Practice.Models;
using FP_Practice.Repositories;

namespace FP_Practice {

    public class ConsoleLogger {
        IAlbumRepository _repo;

        public ConsoleLogger (IAlbumRepository repo) => _repo = repo;

        public void PromptUserFOrAlbumId () {
            Console.WriteLine ("All albums: ");
            Console.WriteLine ();
            IOrderedEnumerable<Album> allAlbums = _repo.GetAllAlbums ();
            if (allAlbums != null) {
                foreach (Album a in allAlbums) {
                    Console.WriteLine ($"{a.Name} by {a.Artist.FullName}");
                }
            }
            Console.WriteLine ();
            Console.WriteLine ("Please enter an album id");
            int albumId = int.Parse (Console.ReadLine ());
            Console.WriteLine();
            Album album = _repo.GetAlbumById (albumId);
            Console.WriteLine ($"Your album is {album.Name} by {album.Artist.FullName}");
            Console.WriteLine ();
            Console.WriteLine ("Please enter an artist's name to find their albums");
            string artist = Console.ReadLine ();
            IOrderedEnumerable<Album> albums = _repo.FindArtistAlbums (artist);
            Console.WriteLine($"{artist}'s albums:");
            Console.WriteLine();
            if (albums != null) {
                foreach (Album a in albums) {
                    Console.WriteLine (a.Name);
                }
            }
        }
    }
}