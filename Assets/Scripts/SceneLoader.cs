using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string initialSceneName = "InitialScene";
    public string[] otherScenes; // Array to hold names of other scenes to load

    private bool initialSceneLoaded = false;

    void Start()
    {
        // Load the initial scene
        SceneManager.LoadScene(initialSceneName, LoadSceneMode.Additive);
    }

    public void LoadNextScene()
    {
        // Check if the initial scene is loaded and has not been unloaded yet
        if (SceneManager.GetSceneByName(initialSceneName).isLoaded && !initialSceneLoaded)
        {
            SceneManager.UnloadSceneAsync(initialSceneName);
            initialSceneLoaded = true;
        }

        // Load other scenes in the array
        foreach (string sceneName in otherScenes)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
    }
}
