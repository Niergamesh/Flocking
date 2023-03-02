using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Eat")]
public class EatBehavior : FilteredFlockBehavior
{
    public float neighborRadius = 2f;
    private float min_Dist = 0;
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        if (context.Count == 0)
            return Vector3.zero;
        List<Transform> f = agent.food;
        Vector3 cohesionMove = Vector3.zero;

        foreach (Transform item in f)
        {
            float dist = Vector3.Distance(agent.transform.position,item.transform.position);
            if (dist < neighborRadius&&min_Dist == 0)
            {
                min_Dist = dist;
                cohesionMove -= (Vector3)item.transform.position;
            }
            else if (dist<min_Dist)
            {
                min_Dist = dist;
                cohesionMove -= (Vector3)item.transform.position;
            }
            
        }
        return cohesionMove;
    }
}
