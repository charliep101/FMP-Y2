using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{

    public AudioSource footstep;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            footstep.enabled = true;
        }

        else
        {
            footstep.enabled = false;
        }
    }
}
