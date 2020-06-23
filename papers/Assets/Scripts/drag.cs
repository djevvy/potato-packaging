using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour
{
public bool isgood;
    int click;

    Vector2 cursorPosition;

    public GameObject packageb;

    public LineRenderer lr;

    public Sprite packageopen;
    public Sprite packageclose;

    public GameObject particle;

    bool open;


    public Sprite[] goodw;
    public Sprite[] badw;

    public Sprite window;

    public SpriteRenderer windows;
    bool mouse;
    bool xray;
    Transform oldplayer;

    public SpringJoint2D spring;
 
      
     void Awake()
     {
 
        spring = this.gameObject.GetComponent<SpringJoint2D>(); //"spring" is the SpringJoint2D component that I added to my object
        
        spring.connectedAnchor = gameObject.transform.position;//i want the anchor position to start at the object's position
     
     }


    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "Package";
        lr.enabled = false;
        
        mouse = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(xray == true)
        // {
        //     gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            
        //     transform.Translate(transform.right * 2 * Time.deltaTime);
        //     particle.SetActive(true);
        // }
        // else
        // {
        //     particle.SetActive(false);
        // }

        // if(open == true)
        // {
        //     gameObject.GetComponent<SpriteRenderer>().sprite = packageopen;
        // }
        // else
        // {
        //     gameObject.GetComponent<SpriteRenderer>().sprite = packageclose;
        // }
    }

    void OnMouseDrag()        
     {
     
        if (spring.enabled == true) 
        {

            cursorPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);//getting cursor position
                
            spring.connectedAnchor = cursorPosition;//the anchor get's cursor's position
                
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, cursorPosition);
            
        }

        

        if (Input.GetKeyUp(KeyCode.Space))
        {
 
            if(open == true)
            {
                open = false;
            }
            else if(open == false)
            {
                open = true;
            }
        }
    }


    private void OnMouseDown() 
    {

        lr.enabled = true;
        
        spring.enabled = true;//I'm reactivating the SpringJoint2D component each time I'm clicking on my object becouse I'm disabling it after I'm releasing the mouse click so it will fly in the direction i was moving my mouse

        
    }

    public void Open()
    {
        Debug.Log("opened");
    }

    private void OnMouseUp() 
    {
        lr.enabled = false;
        spring.enabled = false;//disabling the spring component
        //gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
    }

    // private void OnTriggerEnter2D(Collider2D other) 
    // {
    //     if(other.gameObject.CompareTag("box"))
    //     {
    //         Instantiate(packageb, new Vector3(0,0,0), Quaternion.identity);
    //         Destroy(this.gameObject);
    //     }
    //     else if(other.gameObject.CompareTag("bin"))
    //     {
    //         Instantiate(packageb, new Vector3(0,0,0), Quaternion.identity);
    //         Destroy(this.gameObject);
    //     }
    // }

    // private void OnCollisionEnter2D(Collision2D other) 
    // {
    //     if(other.gameObject.CompareTag("belt"))
    //     {
    //         mouse = false;
    //         xray = true;
    //     }
    // }

    // private void OnTriggerStay2D(Collider2D other) 
    // {
    //     if(other.gameObject.CompareTag("xray"))
    //     {
    //         transform.eulerAngles = new Vector3(0,0,0);
    //         int random = Random.Range(0,1);


    //         if(isgood == true)
    //         {
    //             windows.sprite = goodw[random];
    //         } 
    //         else if(isgood == false)
    //         {
    //             windows.sprite = badw[random];
    //         }
    //     }
    // }

    // private void OnCollisionExit2D(Collision2D other) 
    // {   
    //     windows.sprite = window;
    //     gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
    //     xray = false;
        
    //     mouse = true;
        
    // }
}
