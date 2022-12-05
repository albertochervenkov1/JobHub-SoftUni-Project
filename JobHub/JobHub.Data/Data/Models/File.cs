using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobHub.Infrastructure.Data.Models
{
	public class File
	{
		[Key]
        public int Id { get; set; }

        public byte[] Name { get; set; } = null!;
        public int UserId { get; set; }

    }
}
