using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    private List<Transition> m_TransitionList;
    protected GameObject m_GameObject;
    public void SetParentGameObject(GameObject go)
    {
        m_GameObject = go;
    }

    public virtual void OnStart()
    { }

    public virtual Transition Update()
    {
        foreach (var transition in m_TransitionList)
        {
            if (transition.Check())
            {
                OnEnd();
                return transition;
            }
        }
        return null;
    }

    public virtual void OnEnd()
    { }

    public void AddTransition(IEnumerable<Transition> addTransitions)
    {
        m_TransitionList.AddRange(addTransitions);
    }

    public void AddTransition(Transition transition)
    {
        m_TransitionList.Add(transition);
    }
}
