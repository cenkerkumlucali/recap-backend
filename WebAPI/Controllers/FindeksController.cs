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
    public class FindeksController : ControllerBase
    {
        private IFindeksService _findeksService;

        public FindeksController(IFindeksService findeksService)
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
        [HttpGet("getfindeksdetail")]
        public IActionResult GetFindeksDetail()
        {
            var result = _findeksService.GetFindeksDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getfindeksdetailbyuserid")]
        public IActionResult GetFindeksDetailByUserId(int userId)
        {
            var result = _findeksService.GetFindeksDetailByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getfindeksdetailbyid")]
        public IActionResult GetFindeksDetailByFindeksId(int findeksId)
        {
            var result = _findeksService.GetFindeksDetailByFindeksId(findeksId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
