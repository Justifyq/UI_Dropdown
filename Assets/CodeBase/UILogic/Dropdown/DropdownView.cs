using CodeBase.DropdownLogic;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UILogic.Dropdown
{
    /// <summary>
    /// Вью выпадающего списка
    /// </summary>
    public class DropdownView : MonoBehaviour
    {
        [SerializeField] private Image selectedView;
        [SerializeField] private Image objectsView;
        [SerializeField] private DropdownActionsHandler dropdownActionHandler;

        private void Awake()
        {
            dropdownActionHandler.OnElementsSelectedChanged += UpdateSelectedView;
            dropdownActionHandler.OnObjectsActiveStatusChanged += UpdateObjectsActiveView;
        
            UpdateSelectedView(dropdownActionHandler.IsAllSelectedNow);
        }
    
        private void OnDestroy()
        {
            dropdownActionHandler.OnElementsSelectedChanged -= UpdateSelectedView;
            dropdownActionHandler.OnObjectsActiveStatusChanged -= UpdateObjectsActiveView;
        }
    
        private void UpdateObjectsActiveView(bool status) => 
            objectsView.gameObject.SetActive(status);

        private void UpdateSelectedView(bool selected) => 
            selectedView.gameObject.SetActive(selected);
    }
}