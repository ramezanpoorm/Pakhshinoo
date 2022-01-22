
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SliderAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;
        public SlideApplication(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }
        public OpretaionResult Create(CreateSlide command)
        {
            var operation = new OpretaionResult();
            var slide = new Slide(command.Picture, command.PictureAlt, command.PictureTitle, command.Heading, command.Title, command.Text, command.BtnText, command.Link);
            _slideRepository.Create(slide);
            _slideRepository.SaveChanges();
            return operation.Successeded();
        }

        public OpretaionResult Edit(EditSlide command)
        {
            var operation = new OpretaionResult();
            var slide = _slideRepository.Get(command.Id);
            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            slide.Edit(command.Picture, command.PictureAlt, command.Title, command.Heading, command.Title, command.Text, command.BtnText, command.Link);
            _slideRepository.SaveChanges();
            return operation.Successeded();
        }

        public EditSlide GetDetails(long id)
        {
            return _slideRepository.GetDetails(id);
        }

        public List<SlideViewModel> GetList()
        {
            return _slideRepository.GetList();
        }

        public OpretaionResult Remove(long id)
        {
            var operation = new OpretaionResult();
            var slide = _slideRepository.Get(id);
            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            slide.Remove();
            _slideRepository.SaveChanges();
            return operation.Successeded();
        }

        public OpretaionResult Restore(long id)
        {
            var operation = new OpretaionResult();
            var slide = _slideRepository.Get(id);
            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            slide.Restore();
            _slideRepository.SaveChanges();
            return operation.Successeded();
        }
    }
}
