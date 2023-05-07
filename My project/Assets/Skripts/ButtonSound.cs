using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] soundObj = GameObject.FindGameObjectsWithTag("ButtonSound");
        if (soundObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
