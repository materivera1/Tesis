using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
   
    public bool IsRange(Transform target, float radius)
    {
        if (Vector3.Distance(target.transform.position, transform.position) > radius) return false;
        return true;
    }
    public bool IsView(Transform target, float radius, float angle)
    {
        if (Vector3.Distance(target.transform.position, transform.position) > radius) return false;
        if (Vector3.Angle(target.transform.forward,transform.position- target.transform.position) > angle/2) return false;
        return true;
    }
    public bool IsViewRay(Transform target, float radius, float angle)
    {
        if (Vector3.Distance(target.transform.position, transform.position) > radius) return false;
        if (Vector3.Angle(target.transform.forward, transform.position - target.transform.position) > angle/2) return false;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, (target.transform.position - transform.position).normalized, out hit, radius))
        {
            if (hit.collider.gameObject.Equals(target.gameObject))
            {
                return true;
            }
        }
        return false;
    }
}
