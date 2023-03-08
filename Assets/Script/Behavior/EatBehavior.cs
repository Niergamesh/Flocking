using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Eat")]
public class EatBehavior : FilteredFlockBehavior
{
    private float min_Dist;
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        min_Dist = float.MaxValue;
        List<Transform> f = agent.food;
        Vector3 cohesionMove = Vector3.zero;

        foreach (Transform item in f)   // 检测最短的距离，拿到最短距离之后向最短距离前进
        {
            float dist = Vector3.Distance(agent.transform.position,item.transform.position);
            if (dist<min_Dist)
            {
                min_Dist = dist;
                cohesionMove = (Vector3)item.transform.position - agent.transform.position;
            }
        }
        
        return cohesionMove;
    }
}
