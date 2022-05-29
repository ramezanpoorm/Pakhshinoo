
using _01_PakhshinoQuery.Contract.Brand;
using System.Collections.Generic;

namespace _01_PakhshinoQuery.Contract.Car
{
    public interface ICarQuery
    {
        List<CarQueryModel> GetCar();
    }
}
