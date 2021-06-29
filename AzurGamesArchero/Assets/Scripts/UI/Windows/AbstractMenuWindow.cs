using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;

namespace ArcheroLike.UI
{
    public abstract class AbstractMenuWindow : MonoBehaviour
    {
        public abstract MenuController.WindowType windowType { get; }
        public abstract void OnWindowOpened();

        protected Button[] _buttons;

        protected void Awake()
        {
            _buttons = GetComponentsInChildren<Button>();
            //TODO: Common button stuff
        }

        protected void AddButtonListener(string buttonName, UnityAction action)
        {
            Button button = _buttons.FirstOrDefault(b => b.name == buttonName);
            if (button == null)
                throw new System.Exception($"There is no button \"{buttonName}\" in \"{name}\"");

            button.onClick.AddListener(action);
        }
    }
}
