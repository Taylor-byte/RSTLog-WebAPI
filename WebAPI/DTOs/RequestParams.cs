using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class RequestParams
    {
        //DTOs which are mapped to the domain models using automapper
        const int maxPageSize = 25;

        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;

        public int PageSize
        {
            get
            {

                return _pageSize;

            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        public int CurrentPage { get; set; }

        public int TotalCount { get; set; }

        public string SearchTerm { get; set; }
    }
}
