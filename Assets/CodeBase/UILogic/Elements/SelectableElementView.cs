using CodeBase.ElementsLogic;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UILogic.Elements
{
    /// <summary>
    /// Вью для эллемента
    /// </summary>
    public class SelectableElementView : MonoBehaviour
    {
        [SerializeField] private Image selectedImage;
        [SerializeField] private Image linkedObjectImage;
        [SerializeField] private CanvasGroup elementCanvasGroup;
        [SerializeField] private SelectableElement selectableElement;

        private void Awake()
        {
            selectableElement.OnOpacityChange += ChangeOpacity;
            selectableElement.OnSelectStatusChange += UpdateSelectedView;
            selectableElement.OnLinkedObjectStatusChanged += UpdateLinkedObjectView;
        
            UpdateSelectedView(selectableElement.IsSelected);
        }

        private void OnDestroy()
        {
            selectableElement.OnOpacityChange += ChangeOpacity;
            selectableElement.OnSelectStatusChange -= UpdateSelectedView;
            selectableElement.OnLinkedObjectStatusChanged -= UpdateLinkedObjectView;
        }
    
        private void ChangeOpacity(float newOpacity) => 
            elementCanvasGroup.alpha = newOpacity;

        private void UpdateLinkedObjectView(bool status) => 
            linkedObjectImage.gameObject.SetActive(status);

        private void UpdateSelectedView(bool selected) => 
            selectedImage.gameObject.SetActive(selected);
    }
}