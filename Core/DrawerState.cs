﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 抽屉栏状态
    /// </summary>
    public enum DrawerState
    {
        /// <summary>
        /// 开始打开
        /// </summary>
        opening,
        /// <summary>
        /// 完成打开
        /// </summary>
        opened,
        /// <summary>
        /// 开始关闭
        /// </summary>
        closing,
        /// <summary>
        /// 完成关闭
        /// </summary>
        closed,
        /// <summary>
        /// 未知
        /// </summary>
        unknown = -1
    }
}
