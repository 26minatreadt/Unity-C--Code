using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    private Stack<string> actionStack = new Stack<string>();

    void Start()
    {
        PerformAction("Move Forward");
        PerformAction("Attack");
        PerformAction("Jump");

        UndoLastAction();

        PeekCurrentAction();
    }
    
    void PerformAction(string action)
    {
        actionStack.Push(action);
        Debug.Log("Performed Action: " + action);
    }

    void UndoLastAction()
    {
        if(actionStack.Count > 0)
        {
            string undoneAction = actionStack.Pop();
            Debug.Log("Undod action:" + undoneAction);
        }
        else
        {
            Debug.Log("No action to undo.");
        }
    }

    void PeekCurrentAction()
    {
        if(actionStack.Count > 0)
        {
            string currentAction = actionStack.Peek();
            Debug.Log("Current action is: " + currentAction);
        }
        else
        {
            Debug.Log("No actions to peek at");
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            PerformAction("New Action");
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            UndoLastAction();
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            PeekCurrentAction();
        }

    }
}
