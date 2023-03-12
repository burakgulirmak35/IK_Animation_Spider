using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private Prefabs prefabs;

    private GameObject go;
    private Queue<GameObject> BulletPool = new Queue<GameObject>();
    private Queue<GameObject> FireballPool = new Queue<GameObject>();
    private Queue<GameObject> GasMissilePool = new Queue<GameObject>();
    private Queue<GameObject> MagicMissilePool = new Queue<GameObject>();
    private Queue<GameObject> MysticMissilePool = new Queue<GameObject>();

    private void Awake()
    {
        CreateBulletPool();
    }

    private void CreateBulletPool()
    {
        for (int i = 0; i < prefabs.BulletPoolSize; i++)
        {
            go = GameObject.Instantiate(prefabs.BulletPrefab, transform);
            go.SetActive(false);
            BulletPool.Enqueue(go);

            go = GameObject.Instantiate(prefabs.FireballPrefab, transform);
            go.SetActive(false);
            FireballPool.Enqueue(go);

            go = GameObject.Instantiate(prefabs.GasMissilePrefab, transform);
            go.SetActive(false);
            GasMissilePool.Enqueue(go);

            go = GameObject.Instantiate(prefabs.MagicMissilePrefab, transform);
            go.SetActive(false);
            MagicMissilePool.Enqueue(go);

            go = GameObject.Instantiate(prefabs.MysticMissilePrefab, transform);
            go.SetActive(false);
            MysticMissilePool.Enqueue(go);
        }
    }

    public GameObject GetProjectile(ProjectilePools ProjectilePool)
    {
        switch (ProjectilePool)
        {
            case ProjectilePools.BulletPool:
                go = BulletPool.Dequeue();
                BulletPool.Enqueue(go);
                return go;
            case ProjectilePools.FireballPool:
                go = FireballPool.Dequeue();
                FireballPool.Enqueue(go);
                return go;
            case ProjectilePools.GasMissilePool:
                go = GasMissilePool.Dequeue();
                GasMissilePool.Enqueue(go);
                return go;
            case ProjectilePools.MagicMissilePool:
                go = MagicMissilePool.Dequeue();
                MagicMissilePool.Enqueue(go);
                return go;
            case ProjectilePools.MysticMissilePool:
                go = MysticMissilePool.Dequeue();
                MysticMissilePool.Enqueue(go);
                return go;
            default:
                go = BulletPool.Dequeue();
                BulletPool.Enqueue(go);
                return go;
        }
    }
}
