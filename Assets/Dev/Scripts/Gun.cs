using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Gun : MonoBehaviour
{
    [Header("Scriptable")]
    [SerializeField] private Settings settings;
    [SerializeField] private ProjectileType projectileType;
    [Space]
    [SerializeField] private GameObject myModel;
    [Space]
    private Pool pool;
    [Space]
    private Material myMaterial;
    private Transform target;
    [HideInInspector] public bool isFire;


    private void Awake()
    {
        pool = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Pool>();
        myMaterial = myModel.GetComponent<Renderer>().material;
        myMaterial.SetColor("_EmissionColor", Color.green * 15);
    }

    public void Fire(Transform _target)
    {
        target = _target;
        if (!isFire)
        {
            isFire = true;
            StartCoroutine(FireCoro());
        }
    }

    private IEnumerator FireCoro()
    {
        yield return new WaitForSeconds(projectileType.ProjectileStartDelay);
        while (isFire)
        {
            StartCoroutine(BulletCoro());
            myMaterial.SetColor("_EmissionColor", Color.red * 15);
            yield return new WaitForSeconds((projectileType.ProjectileFireTime));
        }
        myMaterial.SetColor("_EmissionColor", Color.green * 15);
    }

    private IEnumerator BulletCoro()
    {
        GameObject projectile = pool.GetProjectile(projectileType.ProjectilePool);
        projectile.transform.position = transform.position;
        projectile.SetActive(true);
        if (projectileType.ProjectileFlyTime > 0)
        {
            projectile.transform.DOMoveY(transform.position.y + projectileType.ProjectileActivateHeight, projectileType.ProjectileActivateTime);
            yield return new WaitForSeconds(projectileType.ProjectileActivateTime);
        }
        if (target != null)
        {
            projectile.transform.DOMove(target.position, projectileType.ProjectileFlyTime);
        }
        yield return new WaitForSeconds(projectileType.ProjectileFlyTime);
        projectile.SetActive(false);
        yield return new WaitForEndOfFrame();
    }

}
