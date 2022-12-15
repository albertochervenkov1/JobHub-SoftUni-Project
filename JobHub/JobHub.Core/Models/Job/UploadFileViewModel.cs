using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobHub.Core.Models.Job
{
    public class UploadFileViewModel
    {
        
        public string Name { get; set; }
        [NotMapped]
        public IFormFile formFile { get; set; }
    }
}
