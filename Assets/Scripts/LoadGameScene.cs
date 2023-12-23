using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGameScene
    : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private string sceneGameName;

    private bool isLoading;

    private void Awake()
    {
        button.onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        if (isLoading) return;

        SceneManager.LoadSceneAsync(sceneGameName);

        isLoading = true;
    }
}

public class FadeManager : MonoBehaviour
{
    Animation animation;

    private void Start()
    {

    }

}