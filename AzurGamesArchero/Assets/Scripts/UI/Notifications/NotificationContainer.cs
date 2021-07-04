using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ArcheroLike.UI
{
    public class NotificationContainer : MonoBehaviour
    {
        [SerializeField] Vector2 _hidingPosition;
        [SerializeField] Vector2 _showingPosition;
        [SerializeField] float _popupTime;

        TMPro.TMP_Text _notifictaionText;
        Coroutine _animationCoroutine;
        RectTransform _rectTransform;

        public void ShowMessage(string messageText, float duration)
        {
            if (_notifictaionText == null)
            {
                _rectTransform = GetComponent<RectTransform>();
                _notifictaionText = GetComponentInChildren<TMPro.TMP_Text>();
                if (_notifictaionText == null)
                {
                    Debug.LogError("Notification container must contain a child with Text component.");
                    return;
                }
            }

            _notifictaionText.text = messageText;
            if (_animationCoroutine != null)
                StopCoroutine(_animationCoroutine);

            _animationCoroutine = StartCoroutine(NotificationAnimationCorotuine(duration));
        }

        IEnumerator NotificationAnimationCorotuine(float duration)
        {
            _rectTransform.anchoredPosition = _hidingPosition;
            float endTime = Time.time + _popupTime;
            while (endTime > Time.time)
            {
                _rectTransform.anchoredPosition = Vector3.Lerp(_hidingPosition, _showingPosition, 1f - ((endTime - Time.time) / _popupTime));
                yield return new WaitForEndOfFrame();
            }

            _rectTransform.anchoredPosition = _showingPosition;

            yield return new WaitForSeconds(duration);

            endTime = Time.time + _popupTime;
            while (endTime > Time.time)
            {
                _rectTransform.anchoredPosition = Vector3.Lerp(_showingPosition, _hidingPosition, 1f - ((endTime - Time.time) / _popupTime));
                yield return new WaitForEndOfFrame();
            }

            _rectTransform.anchoredPosition = _hidingPosition;

            _animationCoroutine = null;
        }
    }
}
