using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobHub.Core.Models.Job
{
    public class UploadFileModel
    {
        public byte[] Name { get; set; } = null!;


        public string UserId { get; set; } = null!;
    }
}
