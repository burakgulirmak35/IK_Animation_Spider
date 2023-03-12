using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("Scriptable")]
    [SerializeField] private Settings settings;

    [Header("Animators")]
    [SerializeField] private Animator GunsAnim;
    private Controller controller;

    [SerializeField] private GameObject RingOfFire;
    private List<Gun> LegGuns = new List<Gun>();
    private List<Gun> TinyGuns = new List<Gun>();
    [Header("Other")]

    [HideInInspector] public List<Transform> Enemies = new List<Transform>();
    private Transform Target;
    private float disGunTarget;
    private float dis;
    private bool GunsActive;

    private void Awake()
    {
        controller = GetComponent<Controller>();
        FindEnemies();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Gun"))
        {
            LegGuns.Add(go.GetComponent<Gun>());
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("TinyGun"))
        {
            TinyGuns.Add(go.GetComponent<Gun>());
        }
    }

    private void Start()
    {
        StartCoroutine(CheckRange());
    }

    private void FindEnemies()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Enemies.Add(enemy.transform);
        }
    }

    private IEnumerator CheckRange()
    {
        while (controller.playerState.Equals(PlayerState.Live))
        {
            Target = null;
            yield return new WaitForSeconds(1f);
            disGunTarget = settings.TinyGunsFireRange;
            foreach (Transform enemy in Enemies)
            {
                dis = Vector3.Distance(transform.position, enemy.position);
                if (dis < disGunTarget)
                {
                    disGunTarget = dis;
                    Target = enemy;
                    if (!GunsActive)
                    {
                        GunsActive = true;
                        LegGunStarter(true);
                        StartCoroutine(TinyGunController(true));
                    }
                }
            }
            if (!Target)
            {
                GunsActive = false;
                LegGunStarter(false);
                StartCoroutine(TinyGunController(false));
            }
        }
    }

    private IEnumerator TinyGunController(bool state)
    {
        if (state)
        {
            foreach (Gun gun in TinyGuns)
            {
                yield return new WaitForSeconds(0.25f);
                gun.Fire(Target);
            }
            RingOfFire.SetActive(true);
            GunsAnim.SetFloat("RotateSpeed", 0.5f);
        }
        else
        {
            foreach (Gun gun in TinyGuns)
            {
                gun.isFire = false;
            }
            RingOfFire.SetActive(false);
            GunsAnim.SetFloat("RotateSpeed", 1f);
        }
    }

    private void LegGunStarter(bool state)
    {
        if (state)
        {
            foreach (Gun gun in LegGuns)
            {
                gun.Fire(Target);
            }
        }
        else
        {
            foreach (Gun gun in LegGuns)
            {
                gun.isFire = false;
            }
        }
    }
}
