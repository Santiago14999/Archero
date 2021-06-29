using UnityEngine;

namespace ArcheroLike.UI
{
    public class NotificationController : MonoBehaviour
    {
        static NotificationController _instance;
        public static NotificationController Instance
        {
            private set => _instance = value;
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<NotificationController>();

                return _instance;
            }
        }

        NotificationContainer _container;

        public void ShowMessage(string messageText, float duration)
        {
            if (_container == null)
                _container = FindObjectOfType<NotificationContainer>();

            _container.ShowMessage(messageText, duration);
        }
    }
}