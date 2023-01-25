using CodeBase.DropdownLogic;
using UnityEngine;

namespace CodeBase.UILogic.Dropdown
{
    /// <summary>
    /// Кнопка для изменения статуса всем объектам.
    /// </summary>
    public class ActionSetObjectsStatusButton : AbstractButtonView
    {
        [SerializeField] private DropdownActionsHandler dropdownActionsHandler;
    
        protected override void OnButtonClick() => 
            dropdownActionsHandler.MakeObjectStatus();
    }
}