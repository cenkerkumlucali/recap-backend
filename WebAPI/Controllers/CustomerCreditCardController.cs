using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCreditCardController : ControllerBase
    {
        private ICustomerCreditCardService _customerCreditCardService;

        public CustomerCreditCardController(ICustomerCreditCardService customerCreditCardService)
        {
            _customerCreditCardService = customerCreditCardService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerCreditCardService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var result = _customerCreditCardService.GetByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("add")]
        public IActionResult Add(CustomerCreditCard customerCreditCard)
        {
            var result = _customerCreditCardService.Add(customerCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("delete")]
        public IActionResult Delete(CustomerCreditCard customerCreditCard)
        {
            var result = _customerCreditCardService.Delete(customerCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("update")]
        public IActionResult Update(CustomerCreditCard customerCreditCard)
        {
            var result = _customerCreditCardService.Update(customerCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
