using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ticket : MonoBehaviour
{
    float timer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(timer < 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    private void OnMouseDown() 
    {
        Destroy(this.gameObject);
    }
}
