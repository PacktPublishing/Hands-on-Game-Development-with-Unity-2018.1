
#define IS_DEMO
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startGameButton;

    private void OnEnable()
    {
        #if IS_DEMO
        Debug.Log("DEMO");
        #endif
        startGameButton.onClick.AddListener(StartGame);
    }

    private void OnDisable()
    {
        startGameButton.onClick.RemoveAllListeners();
    }

    private void StartGame()
    {
        GoToLevel("HudSandbox");
    }

    public void GoToLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

}
