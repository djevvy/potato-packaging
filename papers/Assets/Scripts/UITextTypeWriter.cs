
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

// attach to UI Text component (with the full text already there)

public class UITextTypeWriter : MonoBehaviour 
{


    TextMeshProUGUI txt;
	string story;
    
    float timer;

    public bool ta;
    public bool tb;
    public bool tc;
    bool timerdone;
    
    private void Start() 
    {
        if(ta == true)
        {   
            
        }
        else if(tb == true)
        {
            timer = 2.5f;
        }
        else if(tc == true)
        {
            timer = 36.125f;
        }
    }
	void Awake () 
	{
		txt = GetComponent<TextMeshProUGUI>();
		story = txt.text;
		txt.text = "";

        Debug.Log(timer);

        
        
		
	}

    private void Update() 
    {
        if(timer < 0 && timerdone == false)
        { 
            StartCoroutine ("PlayText");
            timerdone = true;
        }
        else 
        {
            timer -= Time.deltaTime;
        }
    }


	IEnumerator PlayText()
	{
		foreach (char c in story) 
		{
			txt.text += c;
			yield return new WaitForSeconds (0.125f);
		}
	}

}
