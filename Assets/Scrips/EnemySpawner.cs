using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float range = 10f;
    public float spawnInterval = 2f;
    public bool EnableSpawner;
    public float counter;
    public int MaxEnemy=5;
    public int EnemyActive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<SphereCollider>().radius = range;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnableSpawner)
        {
            counter += Time.deltaTime;
            if (counter > spawnInterval)
            {
                if (EnemyActive<MaxEnemy) 
                {
                    SpawnEnemy();
                }
                counter = 0f;
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnableSpawner = true;
            print("Player Entered");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnableSpawner = false;
            print("Player Exit");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.aliceBlue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    public void SpawnEnemy()
    {
        GameObject obj = Instantiate(EnemyPrefab, transform);


        Vector3 origin = transform.position;

        Vector3 dir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;

        Vector3 FinalPosition = origin + dir * Random.Range(0, range);

        obj.transform.position = FinalPosition;
        ++EnemyActive;
    }
}
