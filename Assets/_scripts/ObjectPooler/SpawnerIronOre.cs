using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerIronOre : MonoBehaviour
{
    [SerializeField] private MaterialPooler materialPooler;
    [SerializeField] private int spawnLimit = 20;
    private int currentSpawn;
    public string materialName = "IronOre";
    private float randomX, randomY, randomZ;


    void Start()
    {
        materialPooler = MaterialPooler.Instance;
        StartCoroutine(SpawnTimer());
        
    }

    IEnumerator SpawnTimer()
    {
        float spawnTime = Random.Range(3f, 5f);

        yield return new WaitForSeconds(spawnTime);
        currentSpawn += 1;
        if (currentSpawn <= spawnLimit)
        {
            SpawnObject();
        }
        else
        {
            StartCoroutine(SpawnTimer());
        }
        
    }

    private void SpawnObject()
    {
        randomX = transform.position.x + Random.Range((transform.localScale.x / 2) * -1, (transform.localScale.x / 2));
        randomZ = transform.position.z + Random.Range((transform.localScale.z / 2) * -1, (transform.localScale.y / 2));
        randomY = transform.position.y;

        Vector3 randomVector = new Vector3(randomX, transform.position.y, randomZ);
        Vector3 spawnVector;

        Ray ray = new Ray(randomVector, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            randomY = transform.position.y - hit.distance;

            spawnVector = new Vector3(randomX, randomY, randomZ);
            MaterialPooler.Instance.SpawnFromPool("IronOre", spawnVector, Quaternion.identity, this.transform);
            StartCoroutine(SpawnTimer());

            //Debug.Log("Iron Ore SPAWNED");
        }
    }
}
