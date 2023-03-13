using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 通用动画打开关闭事件
    /// </summary>
    public class StateChangeEventArgs<T> : MDUIEventArgs<T>
    {
        public OpenCloseState State { get; set; }
    }
}
