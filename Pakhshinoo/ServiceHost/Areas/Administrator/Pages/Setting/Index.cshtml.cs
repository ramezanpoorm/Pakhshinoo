using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Setting;

namespace ServiceHost.Areas.Administrator.Pages.Setting
{
    public class IndexModel : PageModel
    {
        private readonly ISettingApplication _settingApplication;
        public EditSetting setting;

        public IndexModel(ISettingApplication settingApplication)
        {
            _settingApplication = settingApplication;
        }

        public void OnGet()
        {
            setting = _settingApplication.GetDetails(2);
        }
        
        public IActionResult OnPost(EditSetting command)
        {
            var result = _settingApplication.Edit(command);
            return RedirectToPage("/Index");
        }
    }
}
