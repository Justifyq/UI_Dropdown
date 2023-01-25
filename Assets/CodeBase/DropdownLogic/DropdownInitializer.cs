using System.Collections.Generic;
using CodeBase.ElementsLogic;
using UnityEngine;

namespace CodeBase.DropdownLogic
{
    /// <summary>
    /// Иницализатор выпадающего списка.
    /// </summary>
    public class DropdownInitializer : MonoBehaviour
    {
        [SerializeField] private DropdownActionsHandler dropdownActionsHandler;
        [SerializeField] private Transform elementsContainer;
        [SerializeField] private RectTransform dropdownRect;
        [SerializeField] private int elementHeight;
    
        /// <summary>
        /// Контейнер для эллеметов.
        /// </summary>
        public Transform ElementsContainer => elementsContainer;

        /// <summary>
        /// Инициализирвать dropdown
        /// </summary>
        /// <param name="elements"></param>
        public void Initialize(List<SelectableElement> elements)
        {
            dropdownRect.sizeDelta = new Vector2(dropdownRect.rect.width, dropdownRect.rect.height + elementHeight * elements.Count); 
            dropdownActionsHandler.Initialize(elements);
        }
    }
}