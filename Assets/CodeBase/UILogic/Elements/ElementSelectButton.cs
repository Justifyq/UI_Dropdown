using CodeBase.ElementsLogic;
using UnityEngine;

namespace CodeBase.UILogic.Elements
{
    /// <summary>
    /// Кнопка для выбора конкретного эллемнта
    /// </summary>
    public class ElementSelectButton : AbstractButtonView
    {
        [SerializeField] private SelectableElement selectableElement;
    
        protected override void OnButtonClick() => 
            selectableElement.SetSelected(!selectableElement.IsSelected);
    }
}