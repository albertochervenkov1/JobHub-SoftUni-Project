using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobHub.Infrastructure.Data.Models
{
	public class CvFile
	{
		[Key]
        public int Id { get; set; }

        public byte[] Name { get; set; } = null!;
        public string UserId { get; set; } = null!;

    }
}
