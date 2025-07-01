using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void JogarJogo1()
    {
        SceneManager.LoadScene("Game1");
    }

    public void JogarJogo2()
    {
        SceneManager.LoadScene("Game2");
    }
}