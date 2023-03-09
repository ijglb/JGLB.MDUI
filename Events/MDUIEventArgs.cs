using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    public class MDUIEventArgs<T> : EventArgs
    {
        public T Instance { get; set; }
    }
}
