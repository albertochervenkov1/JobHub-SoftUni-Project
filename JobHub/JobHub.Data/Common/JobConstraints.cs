using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobHub.Infrastructure.Common
{
    public static class JobConstraints
    {
        public const int JOB_TITLE_MIN_LENGTH = 5;
        public const int JOB_TITLE_MAX_LENGTH = 75;

        public const int JOB_DESCRIPTION_MIN_LENGTH = 1;
        public const int JOB_DESCRIPTION_MAX_LENGTH = 5000;

        public const int JOB_CITY_MIN_LENGTH = 3;
        public const int JOB_CITY_MAX_LENGTH = 50;

    }
}
