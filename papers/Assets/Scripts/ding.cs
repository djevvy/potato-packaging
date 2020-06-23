using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ding : MonoBehaviour
{
    float timer = 39.5f; 
    public AudioSource Ding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 0)
        {
            Ding.Play();
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
