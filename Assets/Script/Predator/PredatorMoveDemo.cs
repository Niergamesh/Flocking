using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorMoveDemo : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float Dtime;
    [SerializeField] private float speed;
    
    private float timer = 0;
    private Vector3 cohisionMove = Vector3.zero;
    public float neighborRadius = 1.5f;
    SphereCollider agentCollider;


    void Start()
    {
        agentCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>Dtime)
        {
            timer = 0;
            PredatorMove(GetNearbyObjects());
            cohisionMove.Normalize();
            GetComponent<Rigidbody>().AddForce(cohisionMove*force);
        }
        transform.forward = Vector3.Lerp(transform.forward, cohisionMove, speed*Time.deltaTime);
    }

    public Vector3 PredatorMove(List<Transform> context)
    {
        if (context.Count == 0)
            return Vector3.zero;
        foreach(Transform item in context)
        {
            cohisionMove += (Vector3)item.position;
        }
        cohisionMove /= context.Count;
        cohisionMove -= gameObject.transform.position;
        return cohisionMove;

    }
    List<Transform> GetNearbyObjects()
    {
        List<Transform> context = new List<Transform>();
        Collider[] contextColliders = Physics.OverlapSphere(gameObject.transform.position, neighborRadius);
        foreach (Collider c in contextColliders)
        {
            if (c != agentCollider && !c.CompareTag("Food"))
            {
                context.Add(c.transform);
            }
        }
        return context;
    }
}
