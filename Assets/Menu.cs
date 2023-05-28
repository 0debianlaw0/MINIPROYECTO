using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Inicio()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }

    // Update is called once per frame
    public void Salir()
    {
        Application.Quit();
    }

    private void Start()
    {
        Cursor.visible = true;
    }

    public void LVL1()
    {
        SceneManager.LoadScene("LVL1", LoadSceneMode.Single);
    }
    public void LVL2()
    {
        SceneManager.LoadScene("LVL2", LoadSceneMode.Single);
    }
    public void LVL3()
    {
        SceneManager.LoadScene("LVL3", LoadSceneMode.Single);
    }
    public void MenuS()
    {
        SceneManager.LoadScene("MENU", LoadSceneMode.Single);
    }
}
