using System;
using System.Collections;
using System.Collections.Generic;
using Hexlibrium;
using HEXLIBRIUM;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.LookDev;

public class TimeController : MonoBehaviour
{
    [SerializeField] private float timeMultiplier = 1;
    [SerializeField] private float StartHour;
    [SerializeField] private GameObject sky;
    [SerializeField] private Material skybox;
    [SerializeField] private Light[] _lights;
    private float timeCounter;
    private static bool lerpBool;
    public float time;
    //public GameObject cronosButton;

    public float timePulse;
    public float timePulseUpdate;

    private int colorS = 100;

    public static TimeController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        sky = gameObject;
        skybox = sky.GetComponent<MeshRenderer>().materials[0];
        
        

//        cronosButton.GetComponent<CronosButton>();

    }

    private void Update()
    {
        
        if (lerpBool)
        {
            var ColorCurrent = skybox.GetColor("_Color");
            //StartCoroutine(ChangeSkybox(skybox, ColorCurrent));
            ChangeSkybox(skybox, ColorCurrent);
        }
        UpdateTimeOfDay();
        
        //if(StateMachineManager.instance.OnStateEnteredHandler(H02))
        
        timePulse = (64 - (Time.frameCount / 50)) + timePulseUpdate;

       
        
        if (timePulse < 0)
        {
            timePulseUpdate = 4096;
            StateMachineManager.instance.ChangeState("H02");
        }
      
        UIManager.instance.timeText.text = timePulse.ToString();
        
    }

    //public GameObject H02 { get; set; }

    public void ActivateTimeChange()
    {
        timeCounter = 0;
        lerpBool = true;
    }

    // Update is called once per frame
    void UpdateTimeOfDay()
    {
       time += Time.deltaTime * timeMultiplier;
       //cronosButton.GetComponentInChildren()
       

    }

    // public IEnumerator ChangeSkybox(Material skybox, Color ColorCurrent)
    public void ChangeSkybox(Material skybox, Color ColorCurrent)
    {
        timeCounter += Time.deltaTime * timeMultiplier;
        foreach (var light in _lights)
        {
            light.intensity = Mathf.Lerp(0, 1, timePulse);
        }
        skybox.color = Color.Lerp(Color.black, Color.cyan, timePulse);
        
        if (timeCounter >= 1)
        {
            lerpBool = false;
        }

        //yield return null;
    }

    public void StopTheGrayWorld()
    {
        Debug.Log("a");
    }

    void MoveSunAndMoon()
    {
        
    }
}
