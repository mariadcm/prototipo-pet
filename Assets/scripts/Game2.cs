using UnityEngine;

public class Game2Controller : MonoBehaviour
{
    public void OnVoltarClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}