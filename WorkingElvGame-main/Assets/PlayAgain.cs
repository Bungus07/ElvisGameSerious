using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAgain : MonoBehaviour
{
    public void LoadDemoScene()
    {
        SceneManager.LoadScene("DemoScene");
        Debug.Log("HasBeenClicked");
    }
}
