using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    // A stack to store the player's actions in a LIFO (Last In, First Out) order
    private Stack<string> actionStack = new Stack<string>();

    // Start is called before the first frame update
    void Start()
    {
        // Perform three actions and add them to the stack
        PerformAction("Move Forward");
        PerformAction("Attack");
        PerformAction("Jump");

        // Undo the last performed action
        UndoLastAction();

        // Peek at the current action without removing it
        PeekCurrentAction();
    }
    
    // Method to perform an action and add it to the action stack
    void PerformAction(string action)
    {
        actionStack.Push(action); // Push the action onto the stack
        Debug.Log("Performed Action: " + action); // Log the performed action
    }

    // Method to undo the last action by popping it off the stack
    void UndoLastAction()
    {
        if(actionStack.Count > 0) // Check if there are any actions to undo
        {
            string undoneAction = actionStack.Pop(); // Pop the last action from the stack
            Debug.Log("Undod action:" + undoneAction); // Log the undone action
        }
        else
        {
            Debug.Log("No action to undo."); // Log that there are no actions to undo
        }
    }

    // Method to peek at the current action without removing it from the stack
    void PeekCurrentAction()
    {
        if(actionStack.Count > 0) // Check if there are any actions to peek at
        {
            string currentAction = actionStack.Peek(); // Peek at the top action in the stack
            Debug.Log("Current action is: " + currentAction); // Log the current action
        }
        else
        {
            Debug.Log("No actions to peek at"); // Log that there are no actions to peek at
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the 'P' key is pressed, perform a new action
        if(Input.GetKeyDown(KeyCode.P))
        {
            PerformAction("New Action");
        }
        // Check if the 'Z' key is pressed, undo the last action
        if(Input.GetKeyDown(KeyCode.Z))
        {
            UndoLastAction();
        }
        // Check if the 'K' key is pressed, peek at the current action
        if(Input.GetKeyDown(KeyCode.K))
        {
            PeekCurrentAction();
        }
    }
}
