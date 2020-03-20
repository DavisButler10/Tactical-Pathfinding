using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Node[] ConnectsTo;

    private void OnDrawGizmos()
    {
        foreach (Node n in ConnectsTo)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, (n.transform.position - transform.position).normalized * 2);  
        }
    }

    private void Update()
    {
        foreach (Node n in ConnectsTo)
        {
            RaycastHit hit;
            int layer_mask = LayerMask.GetMask("Mud");

            if (!Physics.Raycast(transform.position, n.transform.position - transform.position, out hit, 10f, layer_mask))
            {
                Debug.DrawRay(transform.position, n.transform.position - transform.position, Color.white, 1f);
            }
            //Debug.DrawRay(transform.position, n.transform.position - transform.position, Color.white, 1f);
        }
    }
}