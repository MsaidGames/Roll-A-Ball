using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject pickupPrefab;
    public int pickupCount = 5;
    public float range = 6f;

    public bool is_generate = false;

    void Update()
    {
        if (is_generate)
        {
            is_generate = false;
            SpawnPickups();
        }
        
    }

    void SpawnPickups()
    {
        for (int i = 0; i < pickupCount; i++)
        {
            Vector3 randomPos = new Vector3(
                Random.Range(-range, range),
                0.5f, // keep Y slightly above ground
                Random.Range(-range, range)
            );

            Instantiate(pickupPrefab, randomPos, Quaternion.identity);
        }
    }
}
