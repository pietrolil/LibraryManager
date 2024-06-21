﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.ViewModels
{
    public class MessageBookReceiveViewModel
    {
        public MessageBookReceiveViewModel(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}
