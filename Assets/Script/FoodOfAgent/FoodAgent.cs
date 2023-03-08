using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodAgent : MonoBehaviour
{
    Food agentFood;
    List<FoodAgent> agent2;
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
        agent2 = b;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fagent"))
        {
            Debug.Log("Food Destroyed: " + gameObject.name);
            Destroy(gameObject);

            agent2.Remove(this);
        }
    }

}
