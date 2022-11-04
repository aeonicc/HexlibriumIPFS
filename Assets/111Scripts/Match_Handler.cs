using System;
using System.Collections;
using System.Collections.Generic;
using Hexlibrium;
using HEXLIBRIUM;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using MouseButton = UnityEngine.UIElements.MouseButton;
using Random = UnityEngine.Random;

using System.Numerics;
using Cysharp.Threading.Tasks;
using Hexlibrium;
using MoralisUnity;
using Nethereum.Hex.HexTypes;
using Pixelplacement;
using TMPro;
using UnityEngine;

public enum Math_Results
{
    Loss,
    Win,
    Got_Stunned,
    Stunned,
    Draw
}

public class Match_Handler : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI feedbackText;
    [SerializeField] private BallsHandler _ballsHandler;
    public MouseHoverTiles mouseHoverTiles;
    public int NPC_Choice;
    public int Player_Choice;
    private bool canClick = true;
    private int _matchResultCounter;
    private int TurnCounter;
    private static readonly int Stunned = Animator.StringToHash("Stunned");
    private static readonly int SwitchToHoverFatherReverse = Animator.StringToHash("SwitchToHoverFatherReverse");
    private static readonly int SwitchToHoverFather = Animator.StringToHash("SwitchToHoverFather");
    private static readonly int StopStunned = Animator.StringToHash("StopStunned");

    public Canvas canvas;

    public GameObject fiveButtons;
    
    public GetRandomNumber _getRandomNumber;

    public bool zero = false;

    public int _useRandomNumber;
    public int _Player_Choice;

    public int variable;
    private void Awake()
    {
        _getRandomNumber = GetComponentInParent<GetRandomNumber>();
        
        Debug.Log(this.gameObject);
    }
    private void Update()
    {
    //     //get mouse click
    //     if (Input.GetMouseButtonDown(0) && canClick)
    //     {
    //         RaycastHit hit;
    //         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //         if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag.Contains("Tile"))
    //         {
    //             canClick = false;
    //             var TileID = hit.transform.gameObject.GetComponent<MouseHoverTiles>();
    //             //Debug.Log(TileID.tag);
    //             Player_Choice = int.Parse(TileID.tag.ToString().Remove(0, 5));
    //             //Debug.Log(Player_Choice);
    //             StartCoroutine(Play_Match());
    //         }
    //     }
    //get mouse click

    //var cvs = GetComponent<Canvas>();

    // Player_Choice = int.Parse(); //Parse(TileID.tag.ToString().Remove(0, 5));
    
            //Debug.Log(Player_Choice);
            // StartCoroutine(Play_Match());
            
            // _Player_Choice = Player_Choice;
            //
            // _useRandomNumber = _getRandomNumber.randomNumberResult;
            //
            // if (_useRandomNumber > 0 && _Player_Choice > 0)
            // {
            //     zero = true;
            //     
            // };

    }

    // public static int ActionVariable()
    // {
    //     get
    //     {
    //         return variable;
    //     }
    //     set
    //     {
    //         variable = _useRandomNumber;
    //         CallActionVariable();
    //     }
    // }

    public void ActionButton(int buttonNumber)
    {
        Debug.Log("Button " + buttonNumber + " pressed");
        Player_Choice = buttonNumber;
        
        
        StateMachineManager.instance.theFiveButtons.gameObject.SetActive(false);
        
        StateMachineManager.instance.GetRandomNumber(); 
        StartCoroutine(Play_Match());

        //CallToAction();

    }

    // public async void CallToAction()
    // {
    //     fiveButtons.gameObject.SetActive(false);
    //     
    //     bool result = await AwaitAction();
    //
    //     if (result == true)
    //     {
    //         StartCoroutine(Play_Match());
    //     }
    //     
    // }
    //
    // public async UniTask<bool> AwaitAction()
    // {
    //     
    //     
    //     StateMachineManager.instance.GetRandomNumber();
    //
    //     bool grn = zero; //_useRandomNumber;
    //     
    //     StartCoroutine(Play_Match());
    //
    //     return grn;
    //
    // }

    // public IEnumerator RandomNum(int _useRandomNumber)
    // {
    //     return _useRandomNumber;
    // }

  

    public void Make_Round()
    {
        for (int i = 0; i < 7; i++)
        {
            Play_Match();
        }
    }

    public IEnumerator Play_Match()
    {
        
        
        
        MouseHoverTiles.LockAll();
        
        var Tile = null as MouseHoverTiles;
        yield return new WaitForSeconds(10.0f);
        var whileVar = true;
        /*
        while (whileVar)
        {
            
            Tile = GameObject.FindGameObjectWithTag("Tile " + NPC_Choice).GetComponent<MouseHoverTiles>();
           if (Tile.locked == false)
            {
                whileVar = false;
            }
            
        }
        */
        //var Tile = GameObject.FindGameObjectWithTag("Tile " + NPC_Choice).GetComponent<MouseHoverTiles>();
        //Tile.SwitchToHoverAnimUninterrupted();
        
        NPC_Choice = Random.Range(5, 10) + 1; // 6 a 10
        
        //NPC_Choice = _useRandomNumber + 5;
        
        StartCoroutine(GetMatchResult());
        //Debug.Log.Log(NPC_Choice);
        
    }

    private IEnumerator PlayAnims(int a, int b)
    {
        var player = GameObject.FindGameObjectWithTag("Tile " + a).transform.GetChild(0);
        var npc  = GameObject.FindGameObjectWithTag("Tile " + b).transform.GetChild(0);
        var stringPlayer = "";
        var stringNPC = "";
        switch (a)
        {
            case 1:
                stringPlayer = "Red";
                break;
            case 2:
                stringPlayer = "Blue";
                break;
            case 3:
                stringPlayer = "Black";
                break;
            case 4:
                stringPlayer = "Green";
                break;
            case 5:
                stringPlayer = "Brown";
                break;
        }
        switch (b)
        {
            case 6:
                stringNPC = "Red";
                break;
            case 7:
                stringNPC = "Blue";
                break;
            case 8:
                stringNPC = "Black";
                break;
            case 9:
                stringNPC = "Green";
                break;
            case 10:
                stringNPC = "Brown";
                break;
        }
        player.GetComponent<Animator>().SetTrigger(stringPlayer);
        npc.GetComponent<Animator>().SetTrigger(stringNPC);
        yield return new WaitForSeconds(2.0f);
        player.GetComponent<Animator>().SetTrigger("release");
        npc.GetComponent<Animator>().SetTrigger("release");
    }

    private IEnumerator GetMatchResult()
    {
        StartCoroutine(PlayAnims(Player_Choice, NPC_Choice));
        TurnCounter++;
        var was_Stunned = false;
        var stunned = false;
        yield return new WaitForSeconds(2.0f);
        switch (Compare_Values())
        {
            case Math_Results.Loss:
                Debug.Log("You lost");
                StartCoroutine(ShowFeedback("You lost","Destruction"));
                _matchResultCounter--;
                _ballsHandler.PlayUIBallAnimation(false);
                _ballsHandler.PlayBallAnimation(false);
                break;
            case Math_Results.Win:
                Debug.Log("You won");
                StartCoroutine(ShowFeedback("You won","Destruction"));
                _ballsHandler.PlayUIBallAnimation(true);
                _matchResultCounter++;
                _ballsHandler.PlayBallAnimation(false);
                break;
            case Math_Results.Got_Stunned:
                _matchResultCounter--;
                Debug.Log("You got stunned");
                StartCoroutine(ShowFeedback("You got stunned","Creation"));
                _ballsHandler.PlayUIBallAnimation(false);
                was_Stunned = true;
                _ballsHandler.PlayBallAnimation(true);
                break;
            case Math_Results.Stunned:
                Debug.Log("You stunned");
                StartCoroutine(ShowFeedback("You stunned","Creation"));
                _ballsHandler.PlayUIBallAnimation(true);
                stunned = true;
                _matchResultCounter++;
                _ballsHandler.PlayBallAnimation(true);
                break;
            case Math_Results.Draw:
                StartCoroutine(ShowFeedback("Draw",""));
                Debug.Log("Draw");
                break;

        }

        yield return new WaitForSeconds(2.0f);
        
        ReleaseStuns();
        if (was_Stunned)
        {
            //GameObject.FindGameObjectWithTag("Tile " + Player_Choice).transform.parent.GetComponent<Animator>().SetTrigger(Stunned);
        }
        else if (stunned)
        {
            //GameObject.FindGameObjectWithTag("Tile " + NPC_Choice).transform.parent.GetComponent<Animator>().SetTrigger(Stunned);
        }
        canClick = true;
        fiveButtons.gameObject.SetActive(true);
        MouseHoverTiles.LockAll();

        /*
        #region Reset Triggers and Lock
        
        GameObject.FindGameObjectWithTag("Tile " + NPC_Choice).GetComponent<MouseHoverTiles>().locked = false;
        GameObject.FindGameObjectWithTag("Tile " + NPC_Choice).transform.parent.GetComponent<Animator>()
            .ResetTrigger(SwitchToHoverFatherReverse);
        GameObject.FindGameObjectWithTag("Tile " + NPC_Choice).transform.parent.GetComponent<Animator>()
            .ResetTrigger(SwitchToHoverFather);
        GameObject.FindGameObjectWithTag("Tile " + Player_Choice).transform.parent.GetComponent<Animator>()
            .ResetTrigger(SwitchToHoverFather);
        GameObject.FindGameObjectWithTag("Tile " + Player_Choice).transform.parent.GetComponent<Animator>()
            .ResetTrigger(SwitchToHoverFatherReverse);
        #endregion
        */
        
        SwitchToNormalAnim();
        if (TurnCounter-1 < 6 )
        {
            canClick = true;
            StateMachineManager.instance.Hh64();
            StateMachineManager.instance.theFiveButtons.gameObject.SetActive(true);
            
        }
        else
        {
            //end game pode colocar aqui a função de chamar o nft
            StateMachineManager.instance.ChangeState("H05");
        }
        /*
        else if (TurnCounter-1 == 6 && (_matchResultCounter == 0))
        {
            StartCoroutine(ShowFeedback("TIE", "tiebreaker\nround"));
            canClick = true;
        }
        else if ((TurnCounter-1 == 6 && _matchResultCounter != 0) || (TurnCounter-1 == 7))
        {
            if(_matchResultCounter > 0)
            {
                StartCoroutine(ShowFeedback("You won the battle", ""));
            }
            else
            {
                StartCoroutine(ShowFeedback("You lost the battle", ""));
            }
        }
        */
        canClick = true;
    }

    private IEnumerator ReleaseStuns2()
    {
        /*
        yield return new WaitForSeconds(0.5f);
        for (int i = 1; i < 11; i++)
        {
            GameObject.FindGameObjectWithTag("Tile " + i).transform.parent.GetComponent<Animator>()
                .ResetTrigger(StopStunned);
        }
        */
        yield return null;
    }

    private void ReleaseStuns()
    {
        /*
        for (int i = 1; i < 11; i++)
        {
            GameObject.FindGameObjectWithTag("Tile " + i).transform.parent.GetComponent<Animator>()
                .SetTrigger(StopStunned);
        }
    */
        StartCoroutine(ReleaseStuns2());
    }

    private void SwitchToNormalAnim()
    {
        /*
        GameObject.FindGameObjectWithTag("Tile " + NPC_Choice).transform.parent.GetComponent<Animator>()
            .SetTrigger(SwitchToHoverFatherReverse);
        GameObject.FindGameObjectWithTag("Tile " + Player_Choice).transform.parent.GetComponent<Animator>()
            .SetTrigger(SwitchToHoverFatherReverse);
        */
    }

    /*
    Math_Results.Loss;
    Math_Results.Win;
    Math_Results.Got_Stunned;
    Math_Results.Stunned;
    Math_Results.Draw;
    1 & 6 - fire
    2 & 7 - water
    3 & 8 - metal
    4 & 9 - wood
    5 & 10 - earth
    */

    private Math_Results Compare_Values()
    {
        switch (Player_Choice, NPC_Choice)
        {
            case (1, 6):
                return Math_Results.Draw;
                break;
            case (1, 7):
                return Math_Results.Loss;
                break;
            case (1, 8):
                return Math_Results.Win;
                break;
            case (1, 9):
                return Math_Results.Got_Stunned;
                break;
            case (1, 10):
                return Math_Results.Stunned;
                break;
            case (2, 6):
                return Math_Results.Win;
                break;
            case (2, 7):
                return Math_Results.Draw;
                break;
            case (2, 8):
                return Math_Results.Got_Stunned;
                break;
            case (2, 9):
                return Math_Results.Stunned;
                break;
            case (2, 10):
                return Math_Results.Loss;
                break;
            case (3, 6):
                return Math_Results.Loss;
                break;
            case (3, 7):
                return Math_Results.Stunned;
                break;
            case (3, 8):
                return Math_Results.Draw;
                break;
            case (3, 9):
                return Math_Results.Win;
                break;
            case (3, 10):
                return Math_Results.Got_Stunned;
                break;
            case (4, 6):
                return Math_Results.Stunned;
                break;
            case (4, 7):
                return Math_Results.Got_Stunned;
                break;
            case (4, 8):
                return Math_Results.Loss;
                break;
            case (4, 9):
                return Math_Results.Draw;
                break;
            case (4, 10):
                return Math_Results.Win;
                break;
            case (5, 6):
                return Math_Results.Got_Stunned;
                break;
            case (5, 7):
                return Math_Results.Win;
                break;
            case (5, 8):
                return Math_Results.Stunned;
                break;
            case (5, 9):
                return Math_Results.Loss;
                break;
            case (5, 10):
                return Math_Results.Draw;
                break;
            default:
                return Math_Results.Draw;
                break;
        }
    }

    private IEnumerator ShowFeedback(string feedback, string type)
    {
        feedbackText.text = feedback;
        yield return new WaitForSeconds(2.0f);
        feedbackText.text = "";
        if (type != "")
        {
            StartCoroutine(ShowFeedback(type, ""));
        }
    }

}
