namespace RawData
{
    class Tires
    {
        public Tires(double pressure, int age)
        {
            Pressure = pressure;
            Age = age;
        }
        public int Age { get; set; }
        public double Pressure { get; set; }

    }
}
