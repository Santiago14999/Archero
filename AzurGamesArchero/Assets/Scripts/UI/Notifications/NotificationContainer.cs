using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ArcheroLike.UI
{
    public class NotificationContainer : MonoBehaviour
    {
        [SerializeField] Vector3 _hidingPosition; //TODO: Rect transform
        [SerializeField] Vector3 _showingPosition; //TODO: Rect transform
        [SerializeField] float _popupTime;

        Text _notifictaionText;
        Coroutine _animationCoroutine;

        public void ShowMessage(string messageText, float duration)
        {
            if (_notifictaionText == null)
            {
                _notifictaionText = GetComponentInChildren<Text>();
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
            transform.position = _hidingPosition;
            float endTime = Time.time + _popupTime;
            while (endTime > Time.time)
            {
                transform.position = Vector3.Lerp(_hidingPosition, _showingPosition, 1f - ((endTime - Time.time) / _popupTime));
                yield return new WaitForEndOfFrame();
            }

            transform.position = _showingPosition;

            yield return new WaitForSeconds(duration);

            endTime = Time.time + _popupTime;
            while (endTime > Time.time)
            {
                transform.position = Vector3.Lerp(_showingPosition, _hidingPosition, 1f - ((endTime - Time.time) / _popupTime));
                yield return new WaitForEndOfFrame();
            }

            _animationCoroutine = null;
        }
    }
}
