using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutsideLOS : Transition
{
    private float m_Range;
    public override bool Check()
    {
        //If player is in range
        return false;
        //Else return true
    }
}
