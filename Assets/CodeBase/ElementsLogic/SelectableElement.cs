using System;
using UnityEngine;

namespace CodeBase.ElementsLogic
{
    /// <summary>
    /// Эллемент выпадающего списка
    /// </summary>
    public class SelectableElement : MonoBehaviour
    {
        public event Action<float> OnOpacityChange;
        public event Action<bool> OnSelectStatusChange;
        public event Action<bool> OnLinkedObjectStatusChanged;
        
        /// <summary>
        /// Статус эллемента
        /// </summary>
        public bool IsSelected { get; private set; }
        
        /// <summary>
        /// Статус объекта
        /// </summary>
        public bool LinkedObjectStatus => _linkedObject != null && _linkedObject.activeSelf;
    
        private float _opacity;
        private GameObject _linkedObject;
        
        /// <summary>
        /// Установить объект
        /// </summary>
        /// <param name="linkedObject"></param>
        public void SetLinkedObject(GameObject linkedObject) => 
            _linkedObject = linkedObject;

        /// <summary>
        /// Выставить статус эллементу.
        /// </summary>
        public void SetSelected(bool selected)
        {
            if (selected == IsSelected)
                return;
            
            IsSelected = selected;
            OnSelectStatusChange?.Invoke(selected);
        }

        /// <summary>
        /// Изменить прозрачность эллемента
        /// </summary>
        public void ChangeOpacity(float opacity)
        {
            if (opacity == _opacity)
                return;
        
            _opacity = opacity;
            OnOpacityChange?.Invoke(_opacity);
        }

        /// <summary>
        /// Изменить статус объекта
        /// </summary>
        public void UpdateLinkedObjectStatus() => 
            SetLinkedObjectStatus(LinkedObjectStatus == false);
        
        /// <summary>
        /// Изменить статус объекта на заданный
        /// </summary>
        public void UpdateLinkedObjectStatus(bool status) => 
            SetLinkedObjectStatus(status);
    
        private void SetLinkedObjectStatus(bool status)
        {
            if (_linkedObject == null || status == LinkedObjectStatus)
                return;
        
            _linkedObject.SetActive(status);
            OnLinkedObjectStatusChanged?.Invoke(LinkedObjectStatus);
        }


    }
}