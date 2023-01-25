using UnityEngine;

namespace CodeBase.ElementsLogic
{
    /// <summary>
    /// Фабрика эллементов для выпадающего списка
    /// </summary>
    public class SelectableElementsFactory
    {
        private readonly SelectableElement _prefab;

        public SelectableElementsFactory(SelectableElement prefab)
        {
            _prefab = prefab;
        }


        /// <summary>
        /// Создать эллементы для выпадающего списка
        /// </summary>
        public SelectableElement[] CreateElements(Transform container, GameObject[] attachObjects)
        {
            var elements = new SelectableElement[attachObjects.Length];

            for (var i = 0; i < elements.Length; i++)
            {
                elements[i] = CreateElement(container);
                elements[i].SetLinkedObject(attachObjects[i]);
            }

            return elements;
        }

        private SelectableElement CreateElement(Transform container) => 
            Object.Instantiate(_prefab, container);
    }
}