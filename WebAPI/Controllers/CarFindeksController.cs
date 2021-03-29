using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFindeksController : ControllerBase
    {
        private ICarFindeksService _findeksService;

        public CarFindeksController(ICarFindeksService findeksService)
        {
            _findeksService = findeksService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _findeksService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcarfindeksdetail")]
        public IActionResult GetFindeksDetail()
        {
            var result = _findeksService.GetCarFindeksDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcarfindeksdetailbycarid")]
        public IActionResult GetFindeksDetailByUserId(int carId)
        {
            var result = _findeksService.GetCarFindeksDetailByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcarfindeksdetailbyid")]
        public IActionResult GetFindeksDetailByFindeksId(int findeksId)
        {
            var result = _findeksService.GetCarFindeksDetailById(findeksId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
