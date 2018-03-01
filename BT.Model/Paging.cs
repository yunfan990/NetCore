using System;
using System.Collections.Generic;
using System.Text;

namespace BT.Model
{
    public class Paging<T> where T : class
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public List<T> Entities { get; set; }
    }
}
