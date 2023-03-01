using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EatBehavior : FilteredFlockBehavior
{
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        if (context.Count == 0)
            return Vector3.zero;

        Vector3 cohesionMove = Vector3.zero;
        
        cohesionMove -= (Vector3)agent.transform.position;
        return cohesionMove;
    }
}
