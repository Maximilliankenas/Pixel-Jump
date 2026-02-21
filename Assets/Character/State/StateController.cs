using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [SerializeField] private BaseState initialState;
    [SerializeField] private List<BaseState> baseStateList;

    private Dictionary<string, BaseState> stateDictionary = new Dictionary<string, BaseState>();
    private BaseState currentState;

    private void Start()
    {
        // Map all state to dictionary
        foreach (BaseState state in baseStateList)
        {
            // If key is empty
            if(state.stateKey == "")
            {
                Debug.Log("State key empty");
                continue;
            }
            // If key has duplicate
            if(stateDictionary.ContainsKey(state.stateKey))
            {
                Debug.Log("Duplicate state key");
                continue;
            }
            // Add key to dictionary
            stateDictionary.Add(state.stateKey, state);
        }
        // Initialize state
        if (initialState)
        {
            initialState.EnterState();
            currentState = initialState;
        }
    }

    private void Update()
    {
        if(currentState) currentState.UpdateState();
    }

    private void FixedUpdate()
    {
        if(currentState) currentState.FixedUpdateState();
    }

    public void ChangeState(string newStateKey)
    {
        // Find state from state key
        BaseState newState = stateDictionary[newStateKey];
        if (!newState)
        {
            Debug.Log("State key not found");
            return;
        }
        // Change state
        if(currentState) currentState.ExitState();
        newState.EnterState();
        currentState = newState;
    }

    public string GetCurrentStateKey()
    {
        if(currentState) return currentState.stateKey;
        else return "";
    }
}
