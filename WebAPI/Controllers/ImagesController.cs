using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private IImagesService _imagesService;
        public static IWebHostEnvironment _webHostEnvironment;

        public ImagesController(IImagesService imagesService,IWebHostEnvironment webHostEnvironment)
        {
            _imagesService = imagesService;
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _imagesService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getimagesbyid")]
        public IActionResult GetImagesById(int id)
        {
            var result = _imagesService.GetImagesByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Images images)
        {
            var result = _imagesService.Add(images,".jpeg");
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("add2")]
        public async Task<IActionResult> AddAsync([FromForm(Name = ("Image"))] IFormFile file, [FromForm] Images images)
        {
            System.IO.FileInfo ff = new System.IO.FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            var path = Path.GetTempFileName();
            if (file.Length > 0)
                using (var stream = new FileStream(path, FileMode.Create))
                    await file.CopyToAsync(stream);

            var carimage = new Images { CarId = images.CarId, ImagePath = path, Date = DateTime.Now };


            var result = _imagesService.Add(carimage, fileExtension);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        public class FileUpload
        {
            public IFormFile files { get; set; }

            public IFormFile carid { get; set; }
        }

        [HttpPost("add3")]
        public async Task<string> Add3([FromForm] FileUpload file, [FromForm] Images carImage)
        {


            System.IO.FileInfo ff = new System.IO.FileInfo(file.files.FileName);
            string fileExtension = ff.Extension;


            var createdUniqueFilename = Guid.NewGuid().ToString("N")
                                        + "_" + DateTime.Now.Month + "_"
                                        + DateTime.Now.Day + "_"
                                        + DateTime.Now.Year + fileExtension;


            string path = "";
            if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\uploads\\"))
            {
                Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\uploads\\");
            }
            using (FileStream fs = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\uploads\\" + createdUniqueFilename))
            {
                await file.files.CopyToAsync(fs);

                path = _webHostEnvironment.WebRootPath + "\\uploads\\" + createdUniqueFilename;

                fs.Flush();
            }


            await AddAsync(file.files, carImage);

            return "\\uploads\\" + createdUniqueFilename;


        }

    }
}
