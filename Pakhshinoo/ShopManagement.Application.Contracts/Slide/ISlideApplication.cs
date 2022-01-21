using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Slide
{
    public interface ISlideApplication
    {
        OpretaionResult Create(CreateSlide command);
        OpretaionResult Edit(EditSlide command);
        OpretaionResult Remove(long id);
        OpretaionResult Restore(long id);
        EditSlide GetDetails(long id);
        List<SlideViewModel> GetList();
    }
}
