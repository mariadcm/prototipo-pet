using UnityEngine;

public class Game1Controller : MonoBehaviour
{
    public void OnVoltarClicked() 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); 
    }
}