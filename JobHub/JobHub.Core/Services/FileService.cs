using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobHub.Core.Contracts;
using JobHub.Core.Models.Job;
using JobHub.Infrastructure.Data.Common;
using JobHub.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobHub.Core.Services
{
    public class FileService:IFileService
    {
        private readonly IRepository repo;

        public FileService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task UploadFile(UploadFileModel model)
        {
            var file = new CvFile()
            {
                FileContext = model.MemoryStream.ToArray(),
                Name = model.Name,
                JobId = model.JobId
            };
            await repo.AddAsync(file);
            await repo.SaveChangesAsync();
        }

        public async Task<CvFile> FileById(int id)
        {
            return await repo.AllReadonly<CvFile>()
                .Where(f => f.Id == id)
                .FirstAsync();
        }
    }
}
