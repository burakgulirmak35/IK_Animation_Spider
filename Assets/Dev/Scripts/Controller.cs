using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum PlayerState
{
    Live, Dead
}

public enum GameState
{
    Live, Freeze
}

public class Controller : MonoBehaviour
{
    [Header("Scriptable")]
    [SerializeField] private Settings settings;

    [Header("State")]
    [SerializeField] public PlayerState playerState;
    [SerializeField] public GameState gameState;

    [Header("Joystick")]
    public FloatingJoystick Joystick;
    private float JoystickHorizontal;
    private float JoystickVertical;
    private float DeltaTime;
    Vector3 addedPos;
    Vector3 lookPos;

    [Header("PlayerBody")]
    [SerializeField] private Transform Body;
    private NavMeshAgent Agent;

    private void Awake()
    {
        DeltaTime = Time.deltaTime;
        Agent = GetComponent<NavMeshAgent>();
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, settings.TinyGunsFireRange);
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            JoystickHovement();
        }
    }
    public void JoystickHovement()
    {

        JoystickHorizontal = Joystick.Horizontal;
        JoystickVertical = Joystick.Vertical;
        addedPos = new Vector3(JoystickHorizontal * settings.PlayerSpeed, 0, JoystickVertical * settings.PlayerSpeed);
        //lookPos = addedPos.normalized + Body.position;
        //Body.LookAt(lookPos);
        Agent.Move(addedPos);
    }
}

