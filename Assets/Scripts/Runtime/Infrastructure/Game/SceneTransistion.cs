using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransistion : MonoBehaviour
{
    public static SceneTransistion _instance;

    private void Awake()
    {
        _instance = this;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SceneLoad(int _sceneID)
    {
        SceneManager.LoadScene(_sceneID);
        CursorManager._instance._cursorState = CursorManager.CursorState.UnLocked;
    }
}