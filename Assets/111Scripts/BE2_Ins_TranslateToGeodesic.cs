using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class BE2_Ins_TranslateToGeodesic : BE2_InstructionBase, I_BE2_Instruction
{
    
    public static Action<BE2_Ins_TranslateToGeodesic> OnTranslateAction;
    
    private static TileHex selectedTile;
    
    //protected override void OnAwake()
    //{
    //
    //}

    //protected override void OnStart()
    //{
    //    
    //}

    //protected override void OnUpdate()
    //{
    //
    //}

    I_BE2_BlockSectionHeaderInput _input0;
    I_BE2_BlockSectionHeaderInput _input1;
    I_BE2_BlockSectionHeaderInput _input2;

    //protected override void OnPlay()
    //{
    //    
    //}
    
    // void OnMouseDown()
    // {
    //     //Demo function
    //     //pathfindingDrawDemo ();
    //     if(OnTranslateAction != null)
    //     {
    //         OnTranslateAction.Invoke(this);
    //     }
    // }
    


    public void Function()
    {
        _input0 = Section0Inputs[0];
        _input1 = Section0Inputs[1];
        _input2 = Section0Inputs[2];

        TargetObject.Transform.position = new Vector3(_input0.FloatValue, _input1.FloatValue, _input2.FloatValue);
        
        OnTranslateAction.Invoke(this);
        
        ExecuteNextInstruction();
    }
}