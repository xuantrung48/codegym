namespace JSON
{
    class Numbers
    {
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }
        public override string ToString()
        {
            return $"{{a: {a}, b: {b}, c: {c}}},";
        }
        public Numbers MultiWith(int number)
        {
            return new Numbers()
            {
                a = a * number,
                b = b * number,
                c = c * number
            };
        }
        public int Total()
        {
            return a + b + c;
        }
    }
}
