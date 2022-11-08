using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobHub.Infrastructure.Common
{
    public static class CompanyConstraints
    {
        public const int NAME_MIN_LENGTH = 2;
        public const int NAME_MAX_LENGTH = 50;


        public const int PHONE_NUMBER_MAX_LENGTH = 15;
        public const int PHONE_NUMBER_MIN_LENGTH = 7;
    }
}
