using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneButtonScript : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
