namespace ArcheroLike.UI
{
    public class SettingsWindow : AbstractMenuWindow
    {
        public override MenuController.WindowType windowType => MenuController.WindowType.Settings;

        new void Awake()
        {
            base.Awake();
            AddButtonListener("BackButton", OnBackButtonPressed);
        }

        void OnBackButtonPressed()
        {
            MenuController.Instance.SwitchWindow(MenuController.WindowType.MainMenu, windowType);
        }

        public override void OnWindowOpened()
        {
            print("TODO: Update audio volume");
        }
    }
}
