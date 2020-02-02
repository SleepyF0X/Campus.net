using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Shared
{
    public class PaginationDto
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
    }
}
