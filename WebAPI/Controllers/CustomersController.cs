using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
         ICustomerService _customerService;

         public CustomersController(ICustomerService customerService)
         {
             _customerService = customerService;
         }

         [HttpGet("getall")]
         public IActionResult GetAll()
         {
             var result = _customerService.GetAll();
             if (result.Success)
             {
                 return Ok(result);

             }
             return BadRequest(result);
         }

         [HttpGet("getbyuserid")]
         public IActionResult GetById(int userId)
         {
             var result = _customerService.GetById(userId);
             if (result.Success)
             {
                 return Ok(result);

             }
             return BadRequest(result);
         }
        [HttpGet("getcustomerdetails")]
         public ActionResult GetCustomerDetails()
         {
             var result = _customerService.GetCustomerDetails();
             if (result.Success)
                 return Ok(result);
             return BadRequest(result);
         }

        [HttpPost("add")]
         public IActionResult Add(Customer customer)
         {
             var result = _customerService.Add(customer);
             if (result.Success)
             {
                 return Ok(result);
             }
             return BadRequest(result);
         }

         [HttpPost("delete")]
         public IActionResult Delete(Customer customer)
         {
             var result = _customerService.Delete(customer);
             if (result.Success)
             {
                 return Ok(result);
             }

             return BadRequest(result);
         }

         [HttpPost("update")]
         public IActionResult Update(Customer customer)
         {
             var result = _customerService.Update(customer);
             if (result.Success)
             {
                 return Ok(result);
             }

             return BadRequest(result);
         }
    }
}
