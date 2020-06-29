using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockBO;
using StockBO.BO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly FacadeBO _facade;
        public AuthenticationsController(FacadeBO facade)
        {
            _facade = facade;
        }
        // GET: api/<AuthenticationsController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_facade.userService.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // GET api/<AuthenticationsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_facade.userService.GetById(id));
        }

        // POST api/<AuthenticationsController>
        [HttpPost]
        public IActionResult Post([FromBody] UserBO user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok(_facade.userService.Create(user));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            return BadRequest("Model State is Not Valid");

        }

        // PUT api/<AuthenticationsController>/5
        [HttpPut]
        public IActionResult Put([FromBody] UserBO user)
        {
            if (!ModelState.IsValid) { return BadRequest("Invalid Model State!"); }
            try
            {
                var _user = _facade.userService.Update(user);
                return Ok(_user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<AuthenticationsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                return Ok(_facade.userService.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("IsValidLogin")]
        public IActionResult IsValidaLogin([FromBody] UserBO user)
        {
            try
            {
                return Ok(_facade.userService.IsCorrectLogin(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
