using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UILogic
{
    /// <summary>
    /// Абстрактная кнопка.
    /// </summary>
    public abstract class AbstractButtonView : MonoBehaviour
    {
        [SerializeField] protected Button button;
    
        protected  virtual void Awake() => 
            button.onClick.AddListener(OnButtonClick);

        protected  virtual void OnDestroy() => 
            button.onClick.RemoveListener(OnButtonClick);

        protected abstract void OnButtonClick();
    }
}