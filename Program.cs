
using System;
using FP_Practice.Repositories;

namespace FP_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleLogger logger = new ConsoleLogger(new AlbumRepository());    
            logger.PromptUserFOrAlbumId();     
        }
    }
}
