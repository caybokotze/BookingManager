﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REM.ViewModels.Account
{
    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}