
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Car;
using ShopManagement.Domain.CarAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class CarApplication : ICarApplication
    {
        private readonly ICarRepository _carRepository;

        public CarApplication(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public OpretaionResult Create(CreateCar command)
        {
            var operation = new OpretaionResult();
            if (_carRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var car = new Car(command.Name, command.Description);
            _carRepository.Create(car);
            _carRepository.SaveChanges();
            return operation.Successeded();
        }

        public OpretaionResult Edit(EditCar command)
        {
            var operation = new OpretaionResult();
            var car = _carRepository.Get(command.Id);

            if (car == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_carRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            car.Edit(command.Name, command.Description);
            
            _carRepository.SaveChanges();
            return operation.Successeded();
        }

        public List<CarViewModel> GetCar()
        {
            return _carRepository.GetCars();
        }

        public EditCar GetDetails(long id)
        {
            return _carRepository.GetDetails(id);
        }

        public List<CarViewModel> Search(CarSearchModel searchModel)
        {
            return _carRepository.Search(searchModel);
        }
    }
}
