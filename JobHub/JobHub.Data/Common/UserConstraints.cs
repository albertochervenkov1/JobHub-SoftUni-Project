using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobHub.Infrastructure.Common
{
    public static class UserConstraints
    {
        public const int FIRST_NAME_MIN_LENGTH = 2;
        public const int FIRST_NAME_MAX_LENGTH = 50;

        public const int LAST_NAME_MIN_LENGTH = 2;
        public const int LAST_NAME_MAX_LENGTH = 75;
    }
}
