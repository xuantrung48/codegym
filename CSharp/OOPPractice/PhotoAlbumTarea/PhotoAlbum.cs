using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbumTarea
{
    class PhotoAlbum
    {
        private int numberOfPages;
        public int GetNumberOfPages()
        {
            return numberOfPages;
        }
        public void SetNumberOfPages(int numberOfPages)
        {
            this.numberOfPages = numberOfPages;
        }
        public PhotoAlbum()
        {
            numberOfPages = 16;
        }
        public PhotoAlbum(int numberOfPages)
        {
            this.numberOfPages = numberOfPages;
        }
    }
}
