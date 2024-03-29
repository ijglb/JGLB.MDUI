﻿//https://github.com/dotnet/aspnetcore/blob/main/src/Components/Web/src/Forms/InputRadioGroup.cs
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 单选框 <see cref="Radio{TValue}"/> 子组
    /// </summary>
    public class RadioGroup<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TValue> : InputBase<TValue>
    {
        private readonly string _defaultGroupName = Guid.NewGuid().ToString("N");
        private InputRadioContext? _context;

        /// <summary>
        /// Gets or sets the child content to be rendering inside the <see cref="InputRadioGroup{TValue}"/>.
        /// </summary>
        [Parameter] public RenderFragment? ChildContent { get; set; }

        /// <summary>
        /// Gets or sets the name of the group.
        /// </summary>
        [Parameter] public string? Name { get; set; }

        [CascadingParameter] private InputRadioContext? CascadedContext { get; set; }

        /// <inheritdoc />
        protected override void OnParametersSet()
        {
            // On the first render, we can instantiate the InputRadioContext
            if (_context is null)
            {
                var changeEventCallback = EventCallback.Factory.CreateBinder<string?>(this, __value => CurrentValueAsString = __value, CurrentValueAsString);
                _context = new InputRadioContext(CascadedContext, changeEventCallback);
            }
            else if (_context.ParentContext != CascadedContext)
            {
                // This should never be possible in any known usage pattern, but if it happens, we want to know
                throw new InvalidOperationException("An InputRadioGroup cannot change context after creation");
            }

            // Mutate the InputRadioContext instance in place. Since this is a non-fixed cascading parameter, the descendant
            // InputRadio/InputRadioGroup components will get notified to re-render and will see the new values.
            _context.GroupName = !string.IsNullOrEmpty(Name) ? Name : _defaultGroupName;
            _context.CurrentValue = CurrentValue;
            _context.FieldClass = EditContext?.FieldCssClass(FieldIdentifier);
        }

        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            Debug.Assert(_context != null);

            // Note that we must not set IsFixed=true on the CascadingValue, because the mutations to _context
            // are what cause the descendant InputRadio components to re-render themselves
            builder.OpenComponent<CascadingValue<InputRadioContext>>(0);
            builder.AddAttribute(2, "Value", _context);
            builder.AddAttribute(3, "ChildContent", ChildContent);
            builder.CloseComponent();
        }

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string? validationErrorMessage)
            => this.TryParseSelectableValueFromString(value, out result, out validationErrorMessage);
    }
}
