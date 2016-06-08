using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pathfinding_shit : MonoBehaviour {


    private Transform transform;
    public List<Vector3> path;
    private Vector3 currentPosition;

    private int next;

    public float speed;

    private bool moving = true;

    void Awake()
    {
        transform = GetComponent<Transform>();
    }

	// Use this for initialization
	void Start () {

        speed = 100;
        next = 0;
        foreach (Transform child in transform)
        {
            path.Add(child.gameObject.transform.position);
            Destroy(child.gameObject);
        }
       

     
        
    }
	
	// Update is called once per frame
	void Update () {



        transform.rotation = Quaternion.Slerp(transform.rotation,
                        Quaternion.FromToRotation(Vector2.right, path[next] - transform.position  ),
                        3f * Time.deltaTime);

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, path[next], step);

        if (transform.position == path[next]) { 
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;

            next = ++next % path.Count;

        }

    }
}
