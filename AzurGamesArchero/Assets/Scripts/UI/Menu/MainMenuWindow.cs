using UnityEngine.SceneManagement;

namespace ArcheroLike.UI
{
    public class MainMenuWindow : AbstractMenuWindow
    {
        public override MenuController.WindowType windowType => MenuController.WindowType.MainMenu;

        new void Awake()
        {
            base.Awake();
            AddButtonListener("PlayButton", OnPlayButtonPressed);
            //AddButtonListener("SettingsButton", OnSettingsButtonPressed);
        }

        void OnPlayButtonPressed()
        {
            SceneManager.LoadScene(1);
        }

        void OnSettingsButtonPressed()
        {
            MenuController.Instance.SwitchWindow(MenuController.WindowType.Settings, windowType);
        }

        public override void OnWindowOpened()
        {
            print("TODO: Update score in main menu");
        }
    }
}