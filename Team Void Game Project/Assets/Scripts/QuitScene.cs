using UnityEngine;

public class GameQuitter : MonoBehaviour
{
    public void QuitGame()
    {
        // Log to the console - helpful for testing in the editor.
        Debug.Log("Quit Game was called.");

        // If in the editor, stop playing. If in a build, quit the application.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}