using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashbackBeer.Domain.Pagination
{
    public class GeneralPagination<T>
    {
        public int PageAmount { get; set; }
        public T[] Items { get; set; } = new T[] { };

        public GeneralPagination(int pageAmount, T[] items)
        {
            PageAmount = pageAmount;
            Items = items;
        }
    }
}
