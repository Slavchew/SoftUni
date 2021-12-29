namespace ValidationAttributes
{
    internal class Person
    {
        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        [MyRequired]
        public string FullName { get; set; }


        [MyRange(12, 90)]
        public int Age { get; set; }
    }
}