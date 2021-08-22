using System;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace Avalonia.DragDrop
{
    /// <summary>
    /// Container class for attached properties. Must inherit from <see cref="AvaloniaObject"/>.
    /// </summary>
    public partial class DragDrop : AvaloniaObject
    {
        public static readonly AttachedProperty<bool> IsDragSourceProperty = AvaloniaProperty.RegisterAttached<Interactive, bool>("IsDragSource", typeof(DragDrop), inherits: false);

        /// <summary>
        /// Gets a value indicating whether the given element can be used as the source of a drag-and-drop operation. 
        /// </summary>
        public static bool GetIsDragSource(Interactive interactive)
        {
            return interactive.GetValue(IsDragSourceProperty);
        }

        /// <summary>
        /// Sets a value indicating whether the given interactive can be used as the source of a drag-and-drop operation. 
        /// </summary>
        public static void SetIsDragSource(Interactive interactive, bool value)
        {
            interactive.SetValue(IsDragSourceProperty, value);
        }

        public static readonly AttachedProperty<bool> IsDropTargetProperty = AvaloniaProperty.RegisterAttached<Interactive, bool>("IsDropTarget", typeof(DragDrop), inherits: false);

        /// <summary>
        /// Gets a value indicating whether the given element can be used as the target of a drag-and-drop operation. 
        /// </summary>
        public static bool GetIsDropTarget(Interactive interactive)
        {
            return interactive.GetValue(IsDropTargetProperty);
        }

        /// <summary>
        /// Sets a value indicating whether the given interactive can be used as the target of a drag-and-drop operation. 
        /// </summary>
        public static void SetIsDropTarget(Interactive interactive, bool value)
        {
            interactive.SetValue(IsDropTargetProperty, value);
        }

        static DragDrop()
        {
            IsDragSourceProperty.Changed.Subscribe(x =>
            {
                if (x.NewValue.GetValueOrDefault<bool>())
                {
                }
                else
                {
                }
            });

            IsDropTargetProperty.Changed.Subscribe(x =>
            {
                if (x.NewValue.GetValueOrDefault<bool>())
                {
                    x.Sender.SetValue(Input.DragDrop.AllowDropProperty, true);
                }
                else
                {
                    x.Sender.SetValue(Input.DragDrop.AllowDropProperty, false);
                }
            });
        }
    }
}