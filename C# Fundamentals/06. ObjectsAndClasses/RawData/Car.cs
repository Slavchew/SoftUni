namespace RawData
{
    class Car
    {
        public Car(Model model, Cargo cargo, Tires[] tires)
        {
            CarModel = model;
            Cargo = cargo;
            this.carTyres = tires;
        }

        public Model CarModel { get; set; }
        public Cargo Cargo { get; set; }

        private Tires[] carTyres = new Tires[4];
        public Tires[] CarTyres
        {
            get { return carTyres; }
            set { carTyres = value; }
        }
    }
}
