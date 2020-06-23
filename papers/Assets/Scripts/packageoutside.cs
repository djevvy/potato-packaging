using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class packageoutside : MonoBehaviour
{
    public TextMeshProUGUI tickets;
    public TextMeshProUGUI scores;
    public TextMeshProUGUI ruletext;
    int ticketi;
    public GameObject ticket;
    public GameObject p;
    public GameObject info;
    public static bool isnewday;
    GameObject packageclone;
    int score;
    public static int day;
    int ran;
    

    // Start is called before the first frame update
    void Start()
    {
        //packageclone = GameObject.Find("Package");
        if(day < 1)
        {
            NewDay();
        }
        packageclone = Instantiate(p, new Vector3(-7,0,0), Quaternion.identity);
        RandomPackage();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(isnewday == true)
        {
            info.SetActive(true);
            isnewday = false;
        }

        tickets.text = ("tickets: " + ticketi);
        scores.text = ("score: " + score);

        if(ticketi > 4)
        {
            SceneManager.LoadScene("homeless");
        }
        else if(ticketi == 4)
        {
            tickets.color = new Color(255,0,0);
        }


        if(day == 1)
        {
            ruletext.text = "Day 1: Only packages from potatoville.";
            if(package.frompotato == true)
            {
                package.isgood = true;
            }
            else
            {
                package.isgood = false;
            }
        }
        else if(day == 2)
        {
            ruletext.text = "Day 1: Only packages from potatoville." + "\n" + "Day 2: Only ismilitary packages should be allowed.";
            if(package.frompotato == true && package.ismilitary == true)
            {
                package.isgood = true;
            }
            else
            {
                package.isgood = false;
            }
        }
        else if(day == 3)
        {
            if(package.frompotato == true && package.ismilitary == true && package.hasperson == false)
            {
                package.isgood = true;
            }
            else
            {
                package.isgood = false;
            }
            ruletext.text = "Day 1: Only packages from potatoville." + "\n" + "Day 2: Only ismilitary packages should be allowed." + "\n" + "Day 3: All people trying to sneak in should be imprisoned.";
        }
        else if(day == 4)
        {
            if(package.frompotato == true && package.ismilitary == true && package.hasperson == false && package.realplace == true)
            {
                package.isgood = true;
            }
            else
            {
                package.isgood = false;
            }
            ruletext.text = "Day 1: Only packages from potatoville." + "\n" + "Day 2: Only ismilitary packages should be allowed." + "\n" + "Day 3: All people trying to sneak in should be imprisoned." + "\n" + "Day 4: Only packages with a package to real places.";
        }
        else if(day == 5)
        {
            if(package.frompotato == true && package.ismilitary == true && package.hasperson == false && package.realplace == true && package.hasrightstamp == true)
            {
                package.isgood = true;
            }
            else
            {
                package.isgood = false;
            }
            ruletext.text = "Day 1: Only packages from potatoville." + "\n" + "Day 2: Only ismilitary packages should be allowed." + "\n" + "Day 3: All people trying to sneak in should be imprisoned." + "\n" + "Day 4: Only packages with a package to real places." + "\n" + "Day 5: Only packages with a (bribe) stamp should be allowed.";
        }


    }

    public void openinfo()
    {
        info.SetActive(true);
    }

    public void closeinfo()
    {
        info.SetActive(false);
    }

    public void yes()
    {
        if(package.isgood == false)
        {
            Ticket();


            
        }
        else
        {
            Good();
        }

        

    }

    public static void NewDay()
    {
        day += 1;
        isnewday = true;
    }

    public void no()
    {
        if(package.isgood == true)
        {
            
            Ticket();
        }
        else
        {
            Good();
        }
    }

    public void RandomPackage()
    {
        ran = Random.Range(0,3);
        if(ran == 0)
        {
            package.frompotato =true;
        }
        else
        {
            package.frompotato = false;
        }
        ran = Random.Range(0,3);
        
        if(ran == 0)
        {
            package.ismilitary =true;
        }
        else
        {
            package.ismilitary = false;
        }
        ran = Random.Range(0,3);

        if(ran == 0)
        {
            package.hasweapon =true;
        }
        else
        {
            package.hasweapon = false;
        }
        ran = Random.Range(0,3);

        if(ran == 0)
        {
            package.hasperson =true;
        }
        else
        {
            package.hasperson = false;
        }
        ran = Random.Range(0,3);

        if(ran == 0)
        {
            package.hasrightstamp =true;
        }
        else
        {
            package.hasrightstamp = false;
        }

    }

    public void Ticket()
    {
        
        Destroy(packageclone.gameObject);
        Instantiate(ticket);
        ticketi +=1;
        //Instantiate(p, new Vector3(-7,0,0), Quaternion.identity);
        packageclone = Instantiate(p, new Vector3(-7,0,0), Quaternion.identity);
        RandomPackage();
    }

    public void Good()
    {
        score ++;
        Destroy(packageclone.gameObject);
        //Instantiate(p, new Vector3(-7,0,0), Quaternion.identity);
        packageclone = Instantiate(p, new Vector3(-7,0,0), Quaternion.identity);
        RandomPackage();
    }

    
}
