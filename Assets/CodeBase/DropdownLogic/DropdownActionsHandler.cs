using System;
using System.Collections.Generic;
using CodeBase.ElementsLogic;
using UnityEngine;

namespace CodeBase.DropdownLogic
{
    /// <summary>
    /// Обработчик действий для выпадающего списка
    /// </summary>
    public class DropdownActionsHandler : MonoBehaviour
    {
        public event Action<bool> OnElementsSelectedChanged;
        public event Action<bool> OnObjectsActiveStatusChanged;
    
        /// <summary>
        /// Выбраны ли все эллементы
        /// </summary>
        public bool IsAllSelectedNow { get; private set; }
        
        /// <summary>
        /// Активны ли все объект приклепленные к эллементам
        /// </summary>
        public  bool IsObjectsActiveNow => IsAllActive();

        private List<SelectableElement> _elements;
        private SelectableElementsFactory _elementsFactory;
    
        private void OnDestroy()
        {
            foreach (var element in _elements)
            {
                element.OnSelectStatusChange -= UpdateTotalSelectedStatus;
                element.OnLinkedObjectStatusChanged -= UpdateTotalObjectStatus;
            }
        }
    
        /// <summary>
        /// Инициализая
        /// </summary>
        public void Initialize(List<SelectableElement> elements)
        {
            _elements = elements;
        
            foreach (var element in _elements)
            {
                element.OnSelectStatusChange += UpdateTotalSelectedStatus;
                element.OnLinkedObjectStatusChanged += UpdateTotalObjectStatus;
            }
        }
    
        /// <summary>
        /// Выставить статус эллементам.
        /// </summary>
        public void MakeSelection()
        {
            var selection = GetUpdateSelectionStatus();

            foreach (var element in _elements) 
                element.SetSelected(selection);
        
            UpdateSelection(selection);
        }

        /// <summary>
        /// Выставить статус объектов
        /// </summary>
        public void MakeObjectStatus()
        {
            var selection = GetObjectStatus();
        
            foreach (var element in GetSelectedElements()) 
                element.UpdateLinkedObjectStatus(selection);
        }
        
        /// <summary>
        /// Поменят прозрачность выбранных эллеметов
        /// </summary>
        /// <param name="opacity"></param>
        public void ChangeOpacityInSelected(float opacity)
        {
            foreach (var element in GetSelectedElements()) 
                element.ChangeOpacity(opacity);
        }

        private bool GetUpdateSelectionStatus() => 
            _elements.Count - GetSelectedCount() >= GetSelectedCount();
    
        private bool GetObjectStatus() => 
            _elements.Count - GetActiveObjectsCount() >= GetActiveObjectsCount();
    
        private void UpdateSelection(bool status)
        {
            if (IsAllSelectedNow == status)
                return;
            
            IsAllSelectedNow = status;
            OnElementsSelectedChanged?.Invoke(IsAllSelectedNow);
        }

        private void UpdateTotalSelectedStatus(bool isSelected) => 
            UpdateSelection(IsAllSelected());
    
        private void UpdateTotalObjectStatus(bool status) => 
            OnObjectsActiveStatusChanged?.Invoke(IsAllActive());
        
        private bool IsAllActive() => 
            GetActiveObjectsCount() == _elements.Count;

        private bool IsAllSelected() => 
            GetSelectedCount()  == _elements.Count;

        private int GetSelectedCount() => 
            GetSelectedElements().Count;

        private List<SelectableElement> GetSelectedElements() =>
            _elements.FindAll(element => element.IsSelected);

        private int GetActiveObjectsCount() => GetElementsWithActiveObject().Count;

        private List<SelectableElement> GetElementsWithActiveObject() => 
            _elements.FindAll(element => element.LinkedObjectStatus);
    }
}