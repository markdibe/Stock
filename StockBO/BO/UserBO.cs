﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StockBO.BO
{
    public class UserBO
    {
        public string UserId { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string EncriptionKey { get; set; }
    }
}
