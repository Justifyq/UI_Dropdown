using System.Linq;
using CodeBase.ElementsLogic;
using UnityEngine;

namespace CodeBase.DropdownLogic
{
    /// <summary>
    /// Спавнер эллементов выпадающего списка.
    /// </summary>
    public class DropdownListSpawner : MonoBehaviour
    {
        private const string ELEMENT_PATH = "Prefabs/Element";
        private const string DROPDOWN_PATH = "Prefabs/DropdownList";
    
        [SerializeField] private GameObject[] interactiveObjects;
        [SerializeField] private Canvas attachCanvas;

        private DropdownInitializer _dropdownListPrefab;
        private SelectableElement _elementPrefab;

        private SelectableElementsFactory _elementsFactory;
        private void Awake()
        {
            _dropdownListPrefab = Resources.Load<DropdownInitializer>(DROPDOWN_PATH);
            _elementPrefab = Resources.Load<SelectableElement>(ELEMENT_PATH);
        
            _elementsFactory = new SelectableElementsFactory(_elementPrefab);
        
            var dropdownList = Instantiate(_dropdownListPrefab, attachCanvas.transform);
            var elements = _elementsFactory.CreateElements(dropdownList.ElementsContainer, interactiveObjects);

            dropdownList.Initialize(elements.ToList());
        }


    }
}