using UnityEngine;

[CreateAssetMenu(fileName = "Prefabs", menuName = "Roll/Prefabs", order = 1)]
public class Prefabs : ScriptableObject
{
    public GameObject BulletPrefab;
    public GameObject FireballPrefab;
    public GameObject GasMissilePrefab;
    public GameObject MagicMissilePrefab;
    public GameObject MysticMissilePrefab;
    public int BulletPoolSize;
}