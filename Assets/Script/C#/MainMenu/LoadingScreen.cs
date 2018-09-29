using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour {

    void Update()
    {
        if (Input.anyKey)
        {
            Application.LoadLevel(1);
        }
    }
}
