using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// Tab项
    /// </summary>
    public partial class TabItem : MDUIComponentBase
    {
        private const string DefaultActiveClass = "mdui-tab-active";
        private string _hrefAbsolute;
        /*private static readonly RenderFragment<string> _IconRenderFragment = icon => new RenderFragment(builder => 
        {
            builder.OpenComponent
        });*/
        [CascadingParameter]
        private Tab Parent { get; set; }
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> Attributes { get; set; }
        /// <summary>
        /// 路由
        /// </summary>
        [Parameter]
        public string RouterLink { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [Parameter]
        public string Icon { get; set; }
        /// <summary>
        /// 文本
        /// </summary>
        [Parameter]
        public string Label { get; set; }
        /// <summary>
        /// 激活状态
        /// </summary>
        [Parameter]
        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
        private bool _IsActive;
        /// <summary>
        /// 禁用状态
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; }
        /// <summary>
        /// 微软NavLink Match配置
        /// </summary>
        [Parameter]
        public NavLinkMatch Match { get; set; } = NavLinkMatch.Prefix;
        /// <summary>
        /// 切换到选项时，事件将被触发。
        /// </summary>
        [Parameter]
        public EventCallback<TabShowEventArgs> OnShow {get;set;}

        [Inject]
        private NavigationManager NavigationManger { get; set; }

        private bool _FirstRun = true;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Parent.AddTabItem(this);
            NavigationManger.LocationChanged += OnLocationChanged;

            SetClassMap();
        }

        protected override void OnParametersSet()
        {
            if (Match != NavLinkMatch.All && RouterLink == "/")
            {
                Match = NavLinkMatch.All;
            }

            // Update computed state
            _hrefAbsolute = RouterLink == null ? null : NavigationManger.ToAbsoluteUri(RouterLink).AbsoluteUri;

            if (_FirstRun)
            {
                _IsActive = ShouldMatch(NavigationManger.Uri);
            }
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (builder != null)
            {
                builder.OpenElement(0, "a");
                builder.AddAttribute(1, "id", Id);
                builder.AddAttribute(2, "class", ClassMapper.Class);
                builder.AddAttribute(3, "style", Style);
                //使用href作为路由与mdui js冲突
                /*if (!string.IsNullOrWhiteSpace(RouterLink)) 
                {
                    builder.AddAttribute(4, "href", RouterLink);
                }*/
                builder.AddAttribute(5, "disabled", Disabled);
                builder.AddMultipleAttributes(6, Attributes);
                if (string.IsNullOrWhiteSpace(Icon))
                {
                    builder.AddContent(7, Label);
                }
                else
                {
                    //带图标组件
                    builder.OpenComponent<Icon>(7);
                    builder.AddAttribute(8, "ChildContent", (RenderFragment)(b => b.AddContent(0, Icon)));
                    builder.CloseComponent();
                    builder.OpenElement(9, "label");
                    builder.AddContent(10, Label);
                    builder.CloseElement();
                }
                builder.CloseElement();
            }
        }

        protected override void Dispose(bool disposing)
        {
            // To avoid leaking memory, it's important to detach any event handlers in Dispose()
            NavigationManger.LocationChanged -= OnLocationChanged;
            base.Dispose(disposing);
        }
        private void OnLocationChanged(object? sender, LocationChangedEventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(RouterLink))
            {
                // We could just re-render always, but for this component we know the
                // only relevant state change is to the _isActive property.
                bool shouldBeActiveNow = ShouldMatch(args.Location);
                if (shouldBeActiveNow != _IsActive)
                {
                    _IsActive = shouldBeActiveNow;

                    if (Parent != null && _IsActive)
                    {
                        Parent.Show(Id);
                    }
                }
            }
        }
        private bool ShouldMatch(string currentUriAbsolute)
        {
            if (EqualsHrefExactlyOrIfTrailingSlashAdded(currentUriAbsolute))
            {
                return true;
            }
            if (Match == NavLinkMatch.Prefix
            && IsStrictlyPrefixWithSeparator(currentUriAbsolute, _hrefAbsolute))
            {
                return true;
            }
            return false;
        }
        private bool EqualsHrefExactlyOrIfTrailingSlashAdded(string currentUriAbsolute)
        {
            if (string.Equals(currentUriAbsolute, _hrefAbsolute, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            if (currentUriAbsolute.Length == _hrefAbsolute.Length - 1)
            {
                // Special case: highlight links to http://host/path/ even if you're
                // at http://host/path (with no trailing slash)
                //
                // This is because the router accepts an absolute URI value of "same
                // as base URI but without trailing slash" as equivalent to "base URI",
                // which in turn is because it's common for servers to return the same page
                // for http://host/vdir as they do for host://host/vdir/ as it's no
                // good to display a blank page in that case.
                if (_hrefAbsolute[^1] == '/'
                && _hrefAbsolute.StartsWith(currentUriAbsolute, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        private static bool IsStrictlyPrefixWithSeparator(string value, string prefix)
        {
            int prefixLength = prefix.Length;
            if (value.Length > prefixLength)
            {
                return value.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)
                && (
                // Only match when there's a separator character either at the end of the
                // prefix or right after it.
                // Example: "/abc" is treated as a prefix of "/abc/def" but not "/abcdef"
                // Example: "/abc/" is treated as a prefix of "/abc/def" but not "/abcdef"
                prefixLength == 0
                || !char.IsLetterOrDigit(prefix[prefixLength - 1])
                || !char.IsLetterOrDigit(value[prefixLength])
                );
            }
            else
            {
                return false;
            }
        }

        protected void SetClassMap()
        {
            ClassMapper.Add("mdui-ripple")
                .If(DefaultActiveClass, () => IsActive)
                ;
        }

        internal void SetActive(bool isActive)
        {
            if (_IsActive != isActive)
            {
                _IsActive = isActive;
                InvokeAsync(StateHasChanged);
                if (isActive)
                {
                    //如果有路由，进行路由跳转
                    if (!string.IsNullOrWhiteSpace(RouterLink))
                    {
                        NavigationManger.NavigateTo(RouterLink);
                    }
                    if (OnShow.HasDelegate) 
                    {
                        OnShow.InvokeAsync(new TabShowEventArgs { Instance = this });
                    }
                }
            }
        }
    }
}
