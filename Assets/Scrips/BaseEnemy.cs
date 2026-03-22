using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public float range = 5f;
    public float speed = 7f;
    private Transform ubicacion_player;
    public bool playerDetected;
    private float distancia;
    private GameObject Player;
    void Awake()
    {
        Player = GameObject.FindWithTag("Player");
        if (Player != null)
        {
            ubicacion_player = Player.transform;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<SphereCollider>().radius = range;
        
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector3.Distance(transform.position, ubicacion_player.position);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = true;
            print("Player encontrado");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = false;
            print("Player perdido");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
            if (distancia <= range)
            {
                Gizmos.DrawRay(transform.position, ubicacion_player.position - transform.position);
            }

        
    }
}
