using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    public static class JSRuntimeExtensions
    {
        /// <summary>
        /// 显示Snackbar弹出窗
        /// </summary>
        /// <param name="js"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<Snackbar> Snackbar(this IJSRuntime js, SnackbarOptions options) => await new Snackbar(js).Show(options);
        /// <summary>
        /// 打开一个对话框
        /// </summary>
        /// <param name="js"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<CommonDialog> Dialog(this IJSRuntime js, CommonDialogOptions options) => await new CommonDialog(js).Open(options);
        /// <summary>
        /// 打开一个警告框，可以包含标题、内容和一个确认按钮
        /// </summary>
        /// <param name="js"></param>
        /// <param name="text">文本</param>
        /// <param name="options">可选参数</param>
        /// <returns></returns>
        public static async Task<CommonDialog> AlertDialog(this IJSRuntime js, string text, AlertDialogOptions? options = null)
        {
            if (options == null) options = new AlertDialogOptions();
            CommonDialogOptions dialogOptions = new CommonDialogOptions
            {
                title = options.title,
                content = text,
                cssClass = "mdui-dialog-alert",
                history = options.history,
                modal = options.modal,
                closeOnEsc = options.closeOnEsc,
            };
            dialogOptions.buttons.Add(new DialogButton
            {
                text = options.confirmText,
                bold = false,
                close = options.closeOnConfirm,
                onClick = (internalTag) => options.onConfirm?.Invoke()
            });
            return await new CommonDialog(js).Open(dialogOptions);
        }
        /// <summary>
        /// 打开一个确认框，可以包含标题、内容、一个确认按钮和一个取消按钮
        /// </summary>
        /// <param name="js"></param>
        /// <param name="text">文本</param>
        /// <param name="options">可选参数</param>
        /// <returns></returns>
        public static async Task<CommonDialog> ConfirmDialog(this IJSRuntime js, string text, ConfirmDialogOptions? options = null)
        {
            if (options == null) options = new ConfirmDialogOptions();
            CommonDialogOptions dialogOptions = new CommonDialogOptions
            {
                title = options.title,
                content = text,
                cssClass = "mdui-dialog-confirm",
                history = options.history,
                modal = options.modal,
                closeOnEsc = options.closeOnEsc,
            };
            dialogOptions.buttons.Add(new DialogButton
            {
                text = options.cancelText,
                bold = false,
                close = options.closeOnCancel,
                onClick = (internalTag) => options.onCancel?.Invoke()
            });
            dialogOptions.buttons.Add(new DialogButton
            {
                text = options.confirmText,
                bold = false,
                close = options.closeOnConfirm,
                onClick = (internalTag) => options.onConfirm?.Invoke()
            });
            return await new CommonDialog(js).Open(dialogOptions);
        }
        /// <summary>
        /// 打开一个提示用户输入的对话框，可以包含标题、内容、文本框、一个确认按钮和一个取消按钮
        /// </summary>
        /// <param name="js"></param>
        /// <param name="label">文本框浮动标签的文本</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<PromptDialog> PromptDialog(this IJSRuntime js, string label, PromptDialogOptions? options = null)
        {
            if (options == null) options = new PromptDialogOptions();
            options.label = label;
            return await new PromptDialog(js).Open(options);
        }
    }
}
