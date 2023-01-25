using CodeBase.DropdownLogic;
using UnityEngine;

namespace CodeBase.UILogic.Dropdown
{
    /// <summary>
    /// Кнопка изменения прозрачности
    /// </summary>
    public class OpacityChangeButton : AbstractButtonView
    {
        [SerializeField] private float opacity;
        [SerializeField] private DropdownActionsHandler dropdownActionsHandler;

        protected override void OnButtonClick() =>
            dropdownActionsHandler.ChangeOpacityInSelected(opacity);
    }
}