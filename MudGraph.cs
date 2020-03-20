using UnityEngine;

public class MudGraph : Graph
{
    float mudWeight = 10f;
    public override void GetCost(Node[] nodes)
    {
        RaycastHit hit;
        foreach (Node fromNode in nodes)
        {
            foreach (Node toNode in fromNode.ConnectsTo)
            {
                float cost = (toNode.transform.position - fromNode.transform.position).magnitude;
                
                int layer_mask = LayerMask.GetMask("Mud");

                if (Physics.Raycast(toNode.transform.position, fromNode.transform.position - toNode.transform.position, out hit, 10f, layer_mask))
                {
                    //Debug.DrawRay(toNode.transform.position, fromNode.transform.position - toNode.transform.position, Color.white, 1f);
                    cost *= mudWeight;
                }

                Connection c = new Connection(cost, fromNode, toNode);
                //Debug.Log(c);
                mConnections.Add(c);
            }
        }
    }
}