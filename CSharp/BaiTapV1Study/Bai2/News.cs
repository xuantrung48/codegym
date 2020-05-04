using System;

namespace Bai2
{
    class News : INews
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public float AverageRate { get; set; }
        public float[] RateList = new float[3];
        public void Display()
        {
            Console.WriteLine($"Title: {Title}\nPublish Date: {PublishDate.ToShortDateString()}\nAuthor: {Author}\nContent: {Content}\nAverage Rate: {AverageRate}");
        }
        public void Calculate()
        {
            AverageRate = (RateList[0] + RateList[1] + RateList[2]) / 3;
        }
    }
}
