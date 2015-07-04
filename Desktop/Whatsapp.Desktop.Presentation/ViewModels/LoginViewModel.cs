using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Whatsapp.Desktop.Presentation.ViewModels
{
    public class LoginViewModel: ViewModel
    {
        public string Number { get; set; }

        public string Password { get; set; }

        public string Message { get; set; }
    }
}
