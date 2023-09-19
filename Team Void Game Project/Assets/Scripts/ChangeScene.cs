using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        Debug.Log("Attempting to load " + sceneName);  // Debugging line
        SceneManager.LoadScene(sceneName);
    }
}