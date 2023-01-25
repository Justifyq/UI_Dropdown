using CodeBase.DropdownLogic;
using UnityEngine;

namespace CodeBase.UILogic.Dropdown
{
    /// <summary>
    /// Кнопка изменения статуса всех эллементов
    /// </summary>
    public class ActionSelectionButton : AbstractButtonView
    {
        [SerializeField] private DropdownActionsHandler dropdownActionHandler;
    
        protected override void OnButtonClick() => 
            dropdownActionHandler.MakeSelection();
    }
}