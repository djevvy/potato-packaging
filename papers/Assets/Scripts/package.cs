using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class package : MonoBehaviour
{

    public static bool isgood;
    public static bool frompotato;
    public static bool ismilitary;
    public static bool hasweapon;
    public static bool hasperson;
    public static bool hasrightstamp;
    public static bool realplace;

    Vector2 cursorPosition;
    public GameObject packageb;
    public LineRenderer lr;
    public Sprite packageopen;
    public Sprite packageclose;

    

    bool open;


    public Sprite[] goodw;
    public Sprite[] badw;

    public Sprite window;

    public SpriteRenderer windows;
    bool mouse;
    bool xray;

    int ran;

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
        
        transform.Translate(0,1,0);

        windows = GameObject.Find("Window").GetComponent<SpriteRenderer>();

        gameObject.GetComponent<SpriteRenderer>().sprite = packageclose;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(xray == true)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            
            transform.Translate(transform.right * 2 * Time.deltaTime);

        }
        else
        {

        }

        

        // if(ran == 0)
        // {
        //     isgood = true;
            
        // }
        // else
        // {
        //     isgood = false;
        // }

        if(open == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = packageopen;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = packageclose;
        }
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
    //     if(other.gameObject.CompareTag("out"))
    //     {
    //         Instantiate(packageb, new Vector3(-7,0,0), Quaternion.identity);
    //         Destroy(this.gameObject);
    //     }

    // }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("belt"))
        {
            int ran = Random.Range(0,5);
            // if(ran == 0)
            // {
            //     Ticket();
            //     //transform.position = new Vector3(-7,0,0);
            // }
            mouse = false;
            xray = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("xray"))
        {
            transform.eulerAngles = new Vector3(0,0,0);
            int random = Random.Range(0,1);

            // if(open == true)
            // {
            //     gameObject.GetComponent<SpriteRenderer>().color = new Color(0,1,0);
            // }
            // else
            // {
            //     gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1);
            // }

            if(isgood == true)
            {
                windows.sprite = goodw[random];
            } 
            else
            {
                windows.sprite = badw[random];
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {   
        windows.sprite = window;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
        xray = false;
        
        mouse = true;
        
    }
}
