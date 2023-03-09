//https://github.com/dotnet/aspnetcore/blob/main/src/Components/Web/src/Forms/InputSelect.cs
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI.Component
{
    /// <summary>
    /// 下拉选择
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public class Select<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TValue> : MduiInputBase<TValue>
    {
        /// <summary>
        /// 选择菜单所处位置。包括 auto、top、bottom
        /// </summary>
        [Parameter]
        public string Position { get; set; } = "auto";
        /// <summary>
        /// 选择菜单距离窗口上下边框至少保持多少间距，单位为 px。该参数仅在 Position 为 auto 时有效。
        /// </summary>
        [Parameter]
        public int Gutter { get; set; } = 16;

        private IJSObjectReference? _JsInstance;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _JsInstance = await Js.InvokeAsync<IJSObjectReference>("mduiblazor.Select", Ref, new { position = Position, gutter = Gutter });
            }
        }

        #region 公开方法
        /// <summary>
        /// 打开下拉菜单
        /// </summary>
        /// <returns></returns>
        public async Task Open()
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("open");
            }
        }
        /// <summary>
        /// 关闭下拉菜单
        /// </summary>
        /// <returns></returns>
        public async Task Close()
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("close");
            }
        }
        /// <summary>
        /// 切换下拉菜单的打开状态
        /// </summary>
        /// <returns></returns>
        public async Task Toggle()
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("toggle");
            }
        }
        /// <summary>
        /// 当你动态修改了 Select 元素的内容时，需要调用该方法来重新生成下拉菜单。
        /// </summary>
        /// <returns></returns>
        public async Task HandleUpdate()
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("handleUpdate");
            }
        }
        #endregion

        #region aspnetcore
        private readonly bool _isMultipleSelect;
        public Select()
        {
            _isMultipleSelect = typeof(TValue).IsArray;
        }
        [Parameter] public RenderFragment? ChildContent { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "select");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddAttribute(2, "class", $"{ClassMapper} {CssClass}");
            builder.AddAttribute(3, "multiple", _isMultipleSelect);

            if (_isMultipleSelect)
            {
                builder.AddAttribute(4, "value", BindConverter.FormatValue(CurrentValue)?.ToString());
                builder.AddAttribute(5, "onchange", EventCallback.Factory.CreateBinder<string?[]?>(this, SetCurrentValueAsStringArray, default));
                builder.SetUpdatesAttributeName("value");
            }
            else
            {
                builder.AddAttribute(6, "value", CurrentValueAsString);
                builder.AddAttribute(7, "onchange", EventCallback.Factory.CreateBinder<string?>(this, __value => CurrentValueAsString = __value, default));
                builder.SetUpdatesAttributeName("value");
            }

            builder.AddElementReferenceCapture(8, __selectReference => Ref = __selectReference);
            builder.AddContent(9, ChildContent);

            builder.AddAttribute(10, "id", Id);
            builder.AddAttribute(11, "style", Style);

            builder.CloseElement();
        }

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string? validationErrorMessage)
            => this.TryParseSelectableValueFromString(value, out result, out validationErrorMessage);

        /// <inheritdoc />
        protected override string? FormatValueAsString(TValue? value)
        {
            // We special-case bool values because BindConverter reserves bool conversion for conditional attributes.
            if (typeof(TValue) == typeof(bool))
            {
                return (bool)(object)value! ? "true" : "false";
            }
            else if (typeof(TValue) == typeof(bool?))
            {
                return value is not null && (bool)(object)value ? "true" : "false";
            }

            return base.FormatValueAsString(value);
        }

        private void SetCurrentValueAsStringArray(string?[]? value)
        {
            CurrentValue = BindConverter.TryConvertTo<TValue>(value, CultureInfo.CurrentCulture, out var result)
                ? result
                : default;
        }
        #endregion
    }
}
