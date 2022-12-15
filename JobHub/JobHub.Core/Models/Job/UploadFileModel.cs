using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JobHub.Core.Models.Job
{
    public class UploadFileModel
    {
        public string Name { get; set; }
        public byte[] Content { get; set; } = null!;
        
        public int JobId { get; set; }
        public MemoryStream MemoryStream { get; set; }
    }
}
