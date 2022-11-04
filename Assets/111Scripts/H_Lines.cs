using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class H_Lines : MonoBehaviour
{
    public Button[] buttons;
    
    public static H_Lines instance;
    
        public enum LinesPhase
        {
            h0,
            h1,
            h2,
            h3,
            h4,
            h5,
            h6,
            h7

        };
        public LinesPhase currentLine = LinesPhase.h0;
        //public int h1, h2, h3, h4, h5, h6, h7, h8;
        
        
        public int active;
        
        
        
    void Awake()
    {
        instance = this;

     
    }
    void OnEnable()
    {
     

     
        
        

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentLine)
        {
            case LinesPhase.h0:
                for (int i = 0; i <= 5; i++)
                { 
                    buttons[i].transform.gameObject.SetActive(false);
                }
                break;
            case LinesPhase.h1:
                buttons[0].transform.gameObject.SetActive(true);
                break;
            case LinesPhase.h2:
                buttons[1].transform.gameObject.SetActive(true);
                break;
            case LinesPhase.h3:
                buttons[2].transform.gameObject.SetActive(true);
                break;
            case LinesPhase.h4:
                buttons[3].transform.gameObject.SetActive(true);
                break;
            case LinesPhase.h5:
                buttons[4].transform.gameObject.SetActive(true);
                break;
            case LinesPhase.h6:
                buttons[5].transform.gameObject.SetActive(true);
                break;
            case LinesPhase.h7:
                for (int i = 0; i < 5; i++)
                {
                    buttons[i].transform.gameObject.SetActive(true);
                }
                break;  
        }
    }


}
