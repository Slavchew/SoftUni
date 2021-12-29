using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern.Contracts
{
    interface ICarBuilder
    {
        ICarBuilder BuildTyres(Car car);

        ICarBuilder BuildEngine(Car car);

        ICarBuilder BuildSpeedBox(Car car);


    }
}
