using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodAgent : MonoBehaviour
{
    Food agentFood;
    List<FoodAgent> agent1;
    public Food AgentFood { get { return agentFood; } }

    SphereCollider agentCollider;

    public SphereCollider AgentCollider { get { return agentCollider; } }
    void Start()
    {
        agentCollider = GetComponent<SphereCollider>();
    }

    public void Initialize(Food food, List<FoodAgent> b)
    {
        agentFood = food;
        agent1 = b;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fagent"))
        {
            Destroy(gameObject);

            agent1.Remove(this);
        }
    }

}
