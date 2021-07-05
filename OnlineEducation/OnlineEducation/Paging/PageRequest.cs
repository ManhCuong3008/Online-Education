using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineEducation.Paging
{
    public class PageRequest
    {

        private int page;
        private int maxPageItem;

        public PageRequest()
        {
        }

        public PageRequest(int page, int maxPageItem)
        {
            this.page = page;
            this.maxPageItem = maxPageItem;
        }

        public int getPage()
        {
            if (this.page == 0)
            {
                return 1;
            }
            return this.page;
        }

        public int getOffset()
        {
            if (this.page != 0 && this.maxPageItem != 0)
            {
                return (this.page - 1) * this.maxPageItem;
            }
            else
            {
                return 0;
            }
        }

        public int getLimit()
        {
            if (this.maxPageItem == 0)
            {
                return 4;
            }
            return this.maxPageItem;
        }


    }
}