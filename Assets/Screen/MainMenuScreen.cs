using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField] private AudioClip mainMusic;

    void Start()
    {
        AudioManager.Instance.PlayMusic(mainMusic);
    }

    public void OnPlay()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
