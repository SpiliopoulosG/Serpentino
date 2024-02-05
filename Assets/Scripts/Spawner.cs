using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject food;
    public float wrapBoundaryX = 29.5f;
    public float wrapBoundaryY = 19.5f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnFood();
    }

    public void SpawnFood()
    {
        // Generate random x and y coordinates within the specified range
        float randomX = Random.Range(-wrapBoundaryX, wrapBoundaryX);
        float randomY = Random.Range(-wrapBoundaryY, wrapBoundaryY);

        Instantiate(food, new Vector3(randomX, randomY, transform.position.z), Quaternion.identity);
    }
}
