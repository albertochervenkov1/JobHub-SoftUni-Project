using JobHub.Core.Models.Job;
using JobHub.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobHub.Core.Contracts
{
    public interface IFileService
    {
        Task UploadFile(UploadFileModel model);
        Task<CvFile> FileById(int id);
    }
}
