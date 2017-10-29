using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public int SceneToLoad;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel(SceneToLoad);
        }
    }
}
