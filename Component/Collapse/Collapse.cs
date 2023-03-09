using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 折叠内容块插件
    /// </summary>
    public class Collapse : AbstractSimpleComponent
    {
        protected override string _Tag => Tag;

        protected override string _CSS => "mdui-collapse";
        /// <summary>
        /// html标签
        /// </summary>
        [Parameter]
        public string Tag { get; set; } = "div";
        /// <summary>
        /// 是否启用手风琴效果。
        /// 为 true 时，最多只能有一个内容块处于打开状态，打开一个内容块时会关闭其他内容块。
        /// 为 false 时，可同时打开多个内容块。
        /// </summary>
        [Parameter]
        public bool Accordion { get; set; }

        private IJSObjectReference? _JsInstance;
        private readonly List<CollapseItem> _Items = new List<CollapseItem>();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _JsInstance = await Js.InvokeAsync<IJSObjectReference>("mduiblazor.Collapse", Ref, new { accordion = Accordion });
            }
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (builder != null)
            {
                int seq = 0;
                builder.CreateCascadingValue(ref seq, this, builder2 =>
                {
                    builder2.OpenElement(seq++, _Tag);
                    builder2.AddMultipleAttributes(seq++, AdditionalAttributes);
                    builder2.AddAttribute(seq++, "id", Id);
                    builder2.AddAttribute(seq++, "class", ClassMapper.Class);
                    builder2.AddAttribute(seq++, "style", Style);
                    builder2.AddElementReferenceCapture(seq++, x => Ref = x);
                    builder2.AddContent(seq++, ChildContent);
                    builder2.CloseElement();
                }, true);
            }
        }

        internal void AddItem(CollapseItem item)
        {
            _Items.Add(item);
        }

        #region 公开方法
        /// <summary>
        /// 打开内容块
        /// </summary>
        /// <param name="index">索引号</param>
        /// <returns></returns>
        public async Task Open(int index)
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("open", index);
            }
        }
        /// <summary>
        /// 打开内容块
        /// </summary>
        /// <param name="id">元素Id</param>
        /// <returns></returns>
        public async Task Open(string id)
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("open", $"#{id}");
            }
        }
        /// <summary>
        /// 关闭内容块
        /// </summary>
        /// <param name="index">索引号</param>
        /// <returns></returns>
        public async Task Close(int index)
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("close", index);
            }
        }
        /// <summary>
        /// 关闭内容块
        /// </summary>
        /// <param name="id">元素Id</param>
        /// <returns></returns>
        public async Task Close(string id)
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("close", $"#{id}");
            }
        }
        /// <summary>
        /// 切换内容块状态
        /// </summary>
        /// <param name="index">索引号</param>
        /// <returns></returns>
        public async Task Toggle(int index)
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("toggle", index);
            }
        }
        /// <summary>
        /// 切换内容块状态
        /// </summary>
        /// <param name="id">元素Id</param>
        /// <returns></returns>
        public async Task Toggle(string id)
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("toggle", $"#{id}");
            }
        }
        /// <summary>
        /// 打开所有内容块。该方法仅在 Accordion 为 false 时有效。
        /// </summary>
        /// <returns></returns>
        public async Task OpenAll()
        {
            if (_JsInstance != null && !Accordion)
            {
                await _JsInstance.InvokeVoidAsync("openAll");
            }
        }
        /// <summary>
        /// 关闭所有内容块
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
    }
}
