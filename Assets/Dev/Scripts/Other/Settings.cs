using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Roll/Settings", order = 1)]
public class Settings : ScriptableObject
{
    [Header("Controller")]
    public float JoystickSensivity;

    [Header("Player")]
    public float PlayerSpeed;

    [Header("TinyGuns")]
    public float TinyGunsFireRange;
}