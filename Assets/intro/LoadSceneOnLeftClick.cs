using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LoadSceneOnLeftClick : MonoBehaviour
{
    // Scene number to load
    public int sceneNumber = 15;

    void Update()
    {
        // Check if left mouse button is clicked
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // Check if the scene number is valid
            if (sceneNumber >= 0 && sceneNumber < SceneManager.sceneCountInBuildSettings)
            {
                // Load scene number
                SceneManager.LoadScene(sceneNumber);
            }
            else
            {
                Debug.LogError("Scene number is out of range!");
            }
        }
    }
}
