using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{


    [SerializeField] private Button _playMultiplayerButton;
    [SerializeField] private Button _playSingleplayerButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _optionsButton;


    private void Awake()
    {
        _playMultiplayerButton.onClick.AddListener(() => 
        {
            GameMultiplayer.PlayMultiplayer = true;
            Loader.Load(Loader.Scene.LobbyScene);
        });
        _playSingleplayerButton.onClick.AddListener(() => 
        {
            GameMultiplayer.PlayMultiplayer = false;
            Loader.Load(Loader.Scene.LobbyScene);
        });
        _quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        _optionsButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.OptionsMenu);
        });

        Time.timeScale = 1f;
    }

}