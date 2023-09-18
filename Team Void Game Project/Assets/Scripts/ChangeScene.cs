using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeSceneToTest()
    {
        Debug.Log("Attempting to load TestScene");  // Debugging line
        SceneManager.LoadScene("TestScene");
    }
}