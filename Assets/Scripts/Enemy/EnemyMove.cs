using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

    GameObject player;
    GameObject HUD;
    GestorHitos gestor;
    public GameObject enemy;
    Transform target;
    Transform enemyTransform;
    public float moveSpeed = 3f;
    public float rotationSpeed = 3f;
    float range;

    

    void Awake()
    {
        
    }

    void Start()
    {
        //obtain the game object Transform
        player = null;
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        HUD = GameObject.FindGameObjectsWithTag("HUD")[0];
        gestor = GameObject.FindGameObjectsWithTag("imagen")[0].GetComponent<GestorHitos>();
        if (gestor == null)
            Debug.Log("gestor no inicializado");
        target = player.transform;
    }

    void Update()
    {
        if (target != null)
        {
            target = player.transform;
            Vector2 dir = target.position - enemy.transform.position;
            // Only needed if objects don't share 'z' value.
           float distance = dir.sqrMagnitude;
            if (distance < 50000.04f)
            {

                if (dir != Vector2.zero)
                    enemy.transform.rotation = Quaternion.Slerp(transform.rotation,
                        Quaternion.FromToRotation(Vector2.right, dir),
                        rotationSpeed * Time.deltaTime);

                //Move Towards Target
                enemy.transform.position += (target.position - transform.position).normalized
                    * moveSpeed * Time.deltaTime;
                enemy.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }
        }
    }
}
