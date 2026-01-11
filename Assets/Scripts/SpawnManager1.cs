using UnityEngine;

public class SpawnManager1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject batteryPrefab;
    private Vector3 spawnPos = new Vector3(25, 1, 0);
    private float startDelay = 1f;
    private float repeatRate = 4f;
    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }


    // Update is called once per frame
    void SpawnObstacle()
    {
        if (!playerControllerScript.isGameOver) 
            Instantiate(batteryPrefab, spawnPos, batteryPrefab.transform.rotation);
    }

}
