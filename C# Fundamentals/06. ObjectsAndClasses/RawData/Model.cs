namespace RawData
{
    class Model
    {
        public Model(string carModel, int engineSpeed, int power)
        {
            CarModel = carModel;
            EngineSpeed = engineSpeed;
            EnginePower = power;
        }

        public string CarModel { get; set; }
        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }
    }
}
