using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public FoodAgent foodPrefeb;
    List<FoodAgent> agents = new List<FoodAgent>();
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;

    [Range(50, 3000)]
    public int startingCount = 50;

    public float AgentDensity = 0.001f;

    void Start()
    {
        for (int i = 0; i < startingCount; i++)
        {
            FoodAgent newAgent = Instantiate(
            foodPrefeb,
                Random.insideUnitSphere * startingCount * AgentDensity + new Vector3(xOffset, yOffset, 0),
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
