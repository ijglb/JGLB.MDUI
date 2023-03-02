using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JGLB.MDUI
{
    /// <summary>
    /// Tab组件
    /// </summary>
    public partial class Tab : MDUIComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [CascadingParameter]
        private Appbar? Appbar { get; set; }
        /// <summary>
        /// 使选项卡可以横向滚动，常用于移动端选项较多的场景。
        /// </summary>
        [Parameter]
        public bool Scrollable { get; set; }
        /// <summary>
        /// 使选项卡在平板/PC 上居中对齐。
        /// </summary>
        [Parameter]
        public bool Centered { get; set; }
        /// <summary>
        /// 使选项卡始终占据 100% 的宽度，且每个选项卡宽度相等。
        /// </summary>
        [Parameter]
        public bool FullWidth { get; set; }
        [Parameter]
        public TabOptions? Options { get; set; }
        /// <summary>
        /// 切换选项时，事件将被触发。
        /// </summary>
        [Parameter]
        public EventCallback<TabChangeEventArgs> OnChange { get; set; }

        /// <summary>
        /// 含有有图标的tabItem
        /// </summary>
        internal bool HasIcon { get; set; }

        private readonly List<TabItem> _TabItems = new List<TabItem>();
        private int _ActiveIndex = -1;
        private IJSObjectReference? _JsInstance;
        [Inject]
        ILogger<Error> Logger { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Appbar != null) Appbar.Tab = this;

            SetClassMap();
        }

        protected void SetClassMap()
        {
            ClassMapper.Add("mdui-tab")
                .If("mdui-tab-scrollable", () => Scrollable)
                .If("mdui-tab-centered", () => Centered)
                .If("mdui-tab-full-width", () => FullWidth)
                ;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            //await base.OnAfterRenderAsync(firstRender);
            if (firstRender) 
            {
                /*try
                {
                    _JsInstance = await Js.InvokeAsync<IJSObjectReference>("mduiblazor.Tab", Ref, Options);
                }
                catch (JSException jsex)
                {
                    Logger.LogError(jsex, "mduiblazor.Tab");
                }*/
                //需要修改mdui.js Tab init时不调用setActive
                _JsInstance = await Js.InvokeAsync<IJSObjectReference>("mduiblazor.Tab", Ref, Options);

            }
        }

        /// <summary>
        /// 切换到上一个选项
        /// </summary>
        /// <returns></returns>
        public async Task Prev()
        {
            /*if (_ActiveIndex == -1) 
            {
                return;
            }
            if (_ActiveIndex > 0)
            {
                _ActiveIndex--;
            }
            else if (Options != null && Options.Loop) 
            {
                _ActiveIndex = _TabItems.Count - 1;
            }

            SetActive();*/
            if (_JsInstance != null) 
            {
                await _JsInstance.InvokeVoidAsync("prev");
            }
        }
        /// <summary>
        /// 切换到下一个选项
        /// </summary>
        public async Task Next() 
        {
            /*if (_ActiveIndex == -1)
            {
                return;
            }
            if (_TabItems.Count > _ActiveIndex + 1)
            {
                _ActiveIndex++;
            }
            else if (Options != null && Options.Loop)
            {
                _ActiveIndex = 0;
            }

            SetActive();*/
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("next");
            }
        }

        /// <summary>
        /// 显示指定的选项。
        /// </summary>
        /// <param name="index">索引</param>
        public async Task Show(int index) 
        {
            /*if (_ActiveIndex == -1)
            {
                return;
            }
            if (index >= 0 && index < _TabItems.Count) 
            {
                _ActiveIndex = index;
                SetActive();
            }*/
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("show", index);
            }
        }
        /// <summary>
        /// 显示指定的选项。
        /// </summary>
        /// <param name="id">ID</param>
        public async Task Show(string id)
        {
            /*if (_ActiveIndex == -1)
            {
                return;
            }
            int tempIndex = _TabItems.FindIndex(x => x.Id == id);
            if (tempIndex != -1)
            {
                _ActiveIndex = tempIndex;
                SetActive();
            }*/
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("show", id);
            }
        }

        /// <summary>
        /// 当父元素的宽度发生变化时，需要调用该方法重新设置指示器位置。当在选项卡中动态添加了新的选项时，也需要调用该方法使新的选项生效。
        /// </summary>
        /// <returns></returns>
        public async Task HandleUpdate() 
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("handleUpdate");
            }
        }

        private async Task OnMduiTabChange(TabChangeEventArgs args)
        {
            args.Instance = this;
            _ActiveIndex = args.Index;
            SetActive();
            if (OnChange.HasDelegate) 
            {
                await OnChange.InvokeAsync(args);
            }
        }

        internal void SetActive()
        {
            if (_ActiveIndex != -1)
            {
                var tab = _TabItems[_ActiveIndex];
                tab.SetActive(true);
                _TabItems.ForEach(tabItem =>
                {
                    if (tabItem.Id != tab.Id)
                    {
                        tabItem.SetActive(false);
                    }
                });
            }
        }

        internal void AddTabItem(TabItem tabItem)
        {
            _TabItems.Add(tabItem);
            if (tabItem.IsActive && _ActiveIndex == -1)
            {
                _ActiveIndex = _TabItems.Count - 1;
            }
            HasIcon = _TabItems.Any(x => !string.IsNullOrWhiteSpace(x.Icon));
        }

        private string getOptionsStr() => Options == null ? "" : Options.ToString();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _JsInstance?.DisposeAsync();
        }

    }

    public class TabOptions
    {
        /// <summary>
        /// 切换选项卡的触发方式。 click: 点击切换（默认） hover: 鼠标悬浮切换 
        /// </summary>
        public string Trigger { get; set; } = "click";

        /// <summary>
        /// 是否启用循环切换，若为 true，则最后一个选项激活时调用 next 方法将回到第一个选项，第一个选项激活时调用 prev 方法将回到最后一个选项。
        /// </summary>
        public bool Loop { get; set; }

        public override string ToString()
        {
            return $"{{trigger:'{Trigger}',loop:{Loop}}}";
        }
    }
}
