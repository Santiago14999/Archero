using System.Collections.Generic;
using UnityEngine;

namespace ArcheroLike.UI
{
    public class MenuController : MonoBehaviour
    {
        public enum WindowType { MainMenu, Settings }
        Dictionary<WindowType, AbstractMenuWindow> _windows;

        static MenuController _instance;
        public static MenuController Instance
        {
            private set => _instance = value;
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<MenuController>();
                    if (_instance == null)
                    {
                        _instance = new GameObject("[MenuController]", typeof(MenuController)).GetComponent<MenuController>();
                        DontDestroyOnLoad(_instance);
                    }
                }
                if (!_instance._isInit)
                    _instance.Init();

                return _instance;
            }
        }

        bool _isInit = false;

        void Init()
        {
            _isInit = true;
            _windows = new Dictionary<WindowType, AbstractMenuWindow>();
            AbstractMenuWindow[] windows = GetComponentsInChildren<AbstractMenuWindow>(true);
            foreach (var window in windows)
            {
                _windows.Add(window.windowType, window);
                window.gameObject.SetActive(false);
            }

            OpenWindow(WindowType.MainMenu);
        }

        public void SwitchWindow(WindowType windowToOpen, WindowType windowToClose)
        {
            _windows[windowToClose].gameObject.SetActive(false);
            OpenWindow(windowToOpen);
        }

        void OpenWindow(WindowType window)
        {
            _windows[window].gameObject.SetActive(true);
            _windows[window].OnWindowOpened();
        }
    }
}