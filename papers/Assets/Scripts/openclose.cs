using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openclose : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        anim.SetBool("open", true);
    }

    public void Close()
    {
        anim.SetBool("open", false);
    }
}
