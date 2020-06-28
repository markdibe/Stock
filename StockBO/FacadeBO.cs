using StockBO.IServices;
using StockBO.Services;
using StockDAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockBO
{
    
    public class FacadeBO
    {
        public IUserService userService { get; internal set; }
        private readonly FacadeDAO _facade;
        public FacadeBO(FacadeDAO facade)
        {
            _facade = facade;
            userService = new UserService(_facade);
        }
    }
}
