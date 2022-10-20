using System.Collections.Generic;

public class Statable
{
    protected Dictionary<UnitState, IState> AwailableStates;
    private IState _currentState;

    public Statable(Dictionary<UnitState, IState> awailableStates, UnitState defaultState)
    {
        AwailableStates = awailableStates;
        SetState(defaultState);
    }

    public void SetState(UnitState state)
    {
        _currentState?.Exit();
        _currentState = FindState(state);
        _currentState.Enter();
    }

    public void Update()
    {
        _currentState.Update();
    }

    private IState FindState(UnitState state) => AwailableStates[state];
}

public enum UnitState
{
    Idle,
    Run,
    Death
}

public enum AnimationType
{
    Idle,
    Run,
    Death,
    Attack
}
