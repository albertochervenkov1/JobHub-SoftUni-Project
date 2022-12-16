using JobHub.Core.Contracts;
using JobHub.Core.Models.Job;
using JobHub.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobHub.Controllers
{
    public class UploadFileController:BaseController
    {
        private readonly IFileService fileService;

        public UploadFileController(IFileService _fileService)
        {
            fileService=_fileService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> UploadFile([Bind("Name,fromFileUrl,formFile")] UploadFileViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            //var resultInBytes = ConvertToBytes(file);
            MemoryStream ms = new MemoryStream();
            using (ms)
            {
                await model.formFile.CopyToAsync(ms);
            }
            

            var newFileModel = new UploadFileModel()
            {
                Name = model.formFile.FileName,
                MemoryStream = ms,
                JobId = id,
            };

            await fileService.UploadFile(newFileModel);


            return Content("Thanks for uploading the file");
        }

        private byte[] ConvertToBytes(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.OpenReadStream().CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult UploadedSuccessfully()
        {
            return View();
        }
    }
}
