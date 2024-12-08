using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Wrappers
{
    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }

        public PagedResponse(T data, int pageNumer, int pageSize, int totalRecords)
        {
            PageNumber = pageNumer;
            PageSize = pageSize;
            TotalRecords = totalRecords;
            Data = data;
            Message = null;
            Succeded = true;
            Errors = null;
        }
    }
}
