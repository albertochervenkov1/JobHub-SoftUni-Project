using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobHub.Infrastructure.Data.Models
{
	public class CvFile
	{
		[Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public byte[] FileContext { get; set; } = null!;
        
        public int JobId { get; set; }

        [ForeignKey(nameof(JobId))] 
        public Job Job { get; set; } = null!;
        
    }
}
