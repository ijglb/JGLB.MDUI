using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 可扩展面板
    /// </summary>
    public class Panel : AbstractSimpleComponent
    {
        protected override string _Tag => "div";

        protected override string _CSS => "mdui-panel";
        /// <summary>
        /// 移除打开的面板和其他面板之间的间距
        /// </summary>
        [Parameter]
        public bool Gapless { get; set; }
        /// <summary>
        /// 使打开的面板具有弹出效果
        /// </summary>
        [Parameter]
        public bool Popout { get; set; }
        /// <summary>
        /// 是否启用手风琴效果
        /// 为 true 时，最多只能有一个面板项处于打开状态，打开一个面板项时会关闭其他面板项。
        /// 为 false 时，可同时打开多个面板项。
        /// </summary>
        [Parameter]
        public bool Accordion { get; set; }

        private IJSObjectReference? _JsInstance;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper
                .If("mdui-panel-gapless", () => Gapless)
                .If("mdui-panel-popout", () => Popout)
                ;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _JsInstance = await Js.InvokeAsync<IJSObjectReference>("mduiblazor.Panel", Ref, new { accordion = Accordion });
            }
        }

        #region 公开方法
        /// <summary>
        /// 打开面板项
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public async Task Open(int index)
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("open", index);
            }
        }
        /// <summary>
        /// 打开面板项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Open(string id)
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("open", $"#{id}");
            }
        }
        /// <summary>
        /// 关闭面板项
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public async Task Close(int index)
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("close", index);
            }
        }
        /// <summary>
        /// 关闭面板项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Close(string id)
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("close", $"#{id}");
            }
        }
        /// <summary>
        /// 切换面板项状态
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public async Task Toggle(int index)
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("toggle", index);
            }
        }
        /// <summary>
        /// 切换面板项状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Toggle(string id)
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("toggle", $"#{id}");
            }
        }
        /// <summary>
        /// 打开所有面板项。该方法仅在 Accordion 为 false 时有效
        /// </summary>
        /// <returns></returns>
        public async Task OpenAll()
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("openAll");
            }
        }
        /// <summary>
        /// 关闭所有面板项
        /// </summary>
        /// <returns></returns>
        public async Task CloseAll()
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("closeAll");
            }
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            _JsInstance?.DisposeAsync();
            base.Dispose(disposing);
        }
    }
}
