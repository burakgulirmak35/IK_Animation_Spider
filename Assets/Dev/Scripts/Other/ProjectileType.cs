using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "Roll/ProjectileType", order = 0)]
public class ProjectileType : ScriptableObject
{
    public ProjectilePools ProjectilePool;
    public float ProjectileStartDelay;
    public float ProjectileFireTime;
    public float ProjectileActivateTime;
    public float ProjectileActivateHeight;
    public float ProjectileFlyTime;
}


public enum ProjectilePools
{
    BulletPool, FireballPool, GasMissilePool, MagicMissilePool, MysticMissilePool
}

