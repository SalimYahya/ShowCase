using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Views.Shared.Components.SearchBar
{
    public class SearchPager
    {
        public SearchPager()
        {

        }

        public string SearchText { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }


        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }

        public int StartRecord { get; set; }
        public int EndRecord{ get; set; }



        public SearchPager(int totalItems, int page, int pageSize = 10)
        {
            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            int currentPage = page;

            int startPage = currentPage - 5;
            int endPage = currentPage + 4;

            // Calculate the startPage
            if (startPage <= 0)
            {
                endPage -= (startPage - 1);
                startPage = 1;
            }

            // Calculate the endPage
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            // Setup the properties
            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;

            StartRecord = (CurrentPage - 1) * PageSize + 1;
            EndRecord = StartRecord - 1 + PageSize;
        }
    }
}
