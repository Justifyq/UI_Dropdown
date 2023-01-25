using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UILogic.Dropdown
{
    /// <summary>
    /// Анимация открытия/закрытия
    /// </summary>
    public class ShowHideAnimation : MonoBehaviour
    {
        [SerializeField] private RectTransform self;
        [SerializeField] private Button startAnimationButton;
    
        private float width => self.rect.width;
    
        private Vector2 _closedPosition;
        private Coroutine _animationCoroutine;

        private void Awake()
        {
            _closedPosition.x = -width;
            startAnimationButton.onClick.AddListener(PlayAnimation);
        }

        private void OnDestroy()
        {
            if (_animationCoroutine != null)
                StopCoroutine(_animationCoroutine);
        
            startAnimationButton.onClick.AddListener(PlayAnimation);
        }

        private void PlayAnimation() => 
            _animationCoroutine ??= StartCoroutine(ChangePositionLerp(GetAnimationPosition()));


        private IEnumerator ChangePositionLerp(Vector3 to)
        {
            var from = self.anchoredPosition;
        
            for (float t = 0; t <= 1; t += Time.deltaTime)
            {
                self.anchoredPosition = Vector2.Lerp(from, to, t);
                yield return null;
            }

            yield return null;
            self.anchoredPosition = to;

            _animationCoroutine = null;
        }
    
        private Vector2 GetAnimationPosition() => 
            self.anchoredPosition.x == -width ? Vector2.zero : _closedPosition;
    }
}
