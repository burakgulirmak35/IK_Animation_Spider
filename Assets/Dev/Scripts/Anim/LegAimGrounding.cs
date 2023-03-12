using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegAimGrounding : MonoBehaviour
{
    private int layerMask;
    private Collider[] hitColliders;
    private Vector3 cPos;
    private Vector3 Nearest;
    private GameObject raycastOrigin;
    private Transform root;

    void Start()
    {
        layerMask = LayerMask.GetMask("Ground");
        raycastOrigin = transform.parent.gameObject;
        root = transform.root;
        StartCoroutine(RayCastCoro());
    }

    private IEnumerator RayCastCoro()
    {
        while (true)
        {
            RaycastHit hit;
            if (Physics.Raycast(raycastOrigin.transform.position, -transform.up, out hit, Mathf.Infinity, layerMask))
            {
                transform.position = hit.point;
            }
            else
            {
                hitColliders = Physics.OverlapSphere(root.transform.position, 15, layerMask);
                if (hitColliders.Length > 0)
                {
                    transform.position = GetClosest();
                }
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

    private Vector3 GetClosest()
    {
        float minDist = Mathf.Infinity;
        foreach (Collider c in hitColliders)
        {
            cPos = c.ClosestPoint(raycastOrigin.transform.position);
            float dist = Vector3.Distance(cPos, raycastOrigin.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                Nearest = cPos;
            }
        }
        return Nearest;
    }

}
