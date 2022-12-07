using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace JobHub.Core.Models.Job
{
    public class UploadFileViewModel
    {
        public int JobId { get; set; }
        [Required] 
        public IFormFile File { get; set; } = null!;
        
    }
}
