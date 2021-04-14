using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition
{
    public State m_NextState { get; set; }
    public abstract bool Check();
}
