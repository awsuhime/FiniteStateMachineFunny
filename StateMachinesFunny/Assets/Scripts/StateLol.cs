using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class StateLol : MonoBehaviour
{
    public enum State
    {
        Idle, Patrol, Pursue, Attack, Sleep
    }

    public enum Event
    {
        Enter, Update, Exit
    }

    public StateLol name;
    protected Event stage;
    protected GameObject npc;
    protected Animator anim;
    protected Transform player;
    public StateLol nextState;
    protected NavMeshAgent agent;

    float visDist = 10.0f;
    float visAngle = 30.0f;
    float shootDist = 7.0f;

    public StateLol(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
    {
        npc = _npc;
        agent = _agent;
        anim = _anim;
        stage = Event.Enter;
        player = _player;

    }

    public virtual void Enter() { stage = Event.Update; }
    public virtual void Update() { stage = Event.Update; }
    public virtual void Exit() { stage = Event.Exit; }

    public StateLol Process()
    {
        if (stage == Event.Enter) Enter();
        if (stage == Event.Update) Update();
        if (stage == Event.Exit)
        {
            Exit();
            return nextState;
        }
        return this;
    }

}
