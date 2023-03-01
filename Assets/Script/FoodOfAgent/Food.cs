using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public FoodAgent foodPrefeb;
    List<FoodAgent> agents = new List<FoodAgent>();
    

    [Range(500, 3000)]
    public int startingCount = 500;

    const float AgentDensity = 0.01f;

    void Start()
    {
        for (int i = 0; i < startingCount; i++)
        {
            FoodAgent newAgent = Instantiate(
            foodPrefeb,
                Random.insideUnitSphere * startingCount * AgentDensity,
                new Quaternion(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f),
                Random.Range(0f, 360f)),
                transform
            );
            newAgent.name = "Agent" + i;
            newAgent.Initialize(this, agents);
            agents.Add(newAgent);
        }


    }
}
