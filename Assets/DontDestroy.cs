using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    [SerializeField] GameObject UI;
    bool show = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            show = !show;
        }

        if (show == true)
        {
            UI.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        if (show == false)
        {
            UI.SetActive(false);
            Cursor.visible = false;
            Time.timeScale = 1;
        }
    }

    public void Continuar()
    {
        show = false;
    }

    public void Salir()
    {
        SceneManager.LoadScene("MENU", LoadSceneMode.Single);
    }
}
