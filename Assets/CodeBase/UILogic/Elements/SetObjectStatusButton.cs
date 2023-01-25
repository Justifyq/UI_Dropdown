using CodeBase.ElementsLogic;
using UnityEngine;

namespace CodeBase.UILogic.Elements
{
    /// <summary>
    /// Кнопка для выставления статуса объекту у конкретного эллемента
    /// </summary>
    public class SetObjectStatusButton : AbstractButtonView
    {
        [SerializeField] private SelectableElement selectableElement;

        protected override void OnButtonClick() => 
            selectableElement.UpdateLinkedObjectStatus();
    
    }
}