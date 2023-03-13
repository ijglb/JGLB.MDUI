using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 确认框可选参数
    /// </summary>
    public class ConfirmDialogOptions : AlertDialogOptions
    {
        /// <summary>
        /// 取消按钮的文本
        /// </summary>
        public string cancelText { get; set; } = "cancel";
        /// <summary>
        /// 是否在按下取消按钮时是否关闭对话框
        /// </summary>
        public bool closeOnCancel { get; set; } = true;
        /// <summary>
        /// 点击取消按钮的回调
        /// </summary>
        public Action? onCancel { get; set; }
    }
}
