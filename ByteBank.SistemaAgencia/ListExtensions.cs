using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public static class ListExtensions
    {
        public static void AddVarious<T>(this List<T> list, params T[] itens)
        {
            foreach(T item in itens)
            {
                list.Add(item);
            }
        }
    }
}
