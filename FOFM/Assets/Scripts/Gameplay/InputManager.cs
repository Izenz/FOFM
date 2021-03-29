using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private bool m_LockInput = false;
    private static InputManager g_InputManager;
    public static InputManager Instance
    {
        get
        {
            if (!g_InputManager)
            {
                g_InputManager = FindObjectOfType(typeof(InputManager)) as InputManager;

                if (!g_InputManager)
                {
                    Debug.LogError("There needs to be one active InputManager script on a GameObject in your scene.");
                }
            }
            return g_InputManager;
        }
    }

    public enum Buttons
    {
        Q,
        Space,
        Mouse0,
        Mouse1,
    }

    public bool GetButtonPress(Buttons pressedButton)
    {
        if (m_LockInput)
        {
            return false;
        }

        switch (pressedButton)
        {
            case Buttons.Q:
                return Input.GetKeyDown(KeyCode.Q);
            case Buttons.Space:
                return Input.GetButtonDown("Jump");
            case Buttons.Mouse0:
                return Input.GetMouseButtonDown(0);
            case Buttons.Mouse1:
                return Input.GetMouseButtonDown(1);
            default:
                return false;
        }

    }

    public void LockInput()
    {
        m_LockInput = true;
    }

    public void UnlockInput()
    {
        m_LockInput = false;
    }

    public bool IsInputLocked()
    {
        return m_LockInput;
    }
}
