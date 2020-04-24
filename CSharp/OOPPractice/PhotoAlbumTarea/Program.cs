using System;

namespace PhotoAlbumTarea
{
    class Program
    {
        static void Main(string[] args)
        {
            PhotoAlbum AlbumTest = new PhotoAlbum(24);
            Console.WriteLine($"Number of pages: {AlbumTest.GetNumberOfPages()}");
            BigPhotoAlbum bigPhotoAlbum = new BigPhotoAlbum();
            Console.WriteLine($"Number of pages: {bigPhotoAlbum.GetNumberOfPages()}");
        }
    }
}
