using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMuerte : MonoBehaviour
{
    public string escenaVolver;
    public void Boton()
    {
        SceneManager.LoadScene(escenaVolver, LoadSceneMode.Single);
    }

    private void Start()
    {
        Cursor.visible = true;
    }
}
