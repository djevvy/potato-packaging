using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intheray : MonoBehaviour
{
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        particle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        particle.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        particle.SetActive(false);
    }
}
