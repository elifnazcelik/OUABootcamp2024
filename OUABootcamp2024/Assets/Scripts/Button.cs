using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{

    public void StartGame()
    {

        SceneManager.LoadScene("EgeLevel");
    }


    public void QuitGame()
    {

        Application.Quit();


#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

