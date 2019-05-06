using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{

    public float spawnRate = 4f;
    public int columnPoolSize = 5;
    public float columnYMin = -2f;
    public float columnYMax = 2f;

    private float timeSinceLastSpawn;
    private float spawnXPosition = 1f;
    private int currentColumn = 0;

    public GameObject columnsPrefab;
    public GameObject columnsPrefab2;

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-15,-25f);

    // Use this for initialization
    void Start()
    {
        bool useFace = GameObject.FindGameObjectWithTag("options").GetComponent<options>().faceControl;
        if (!useFace)
        {
            columns = new GameObject[columnPoolSize];
            for (int i = 0; i < columnPoolSize; i++)
            {
                columns[i] = (GameObject)Instantiate(columnsPrefab, objectPoolPosition, Quaternion.identity);
            }
        }
        else
        {
            columns = new GameObject[columnPoolSize];
            for (int i = 0; i < columnPoolSize; i++)
            {
                columns[i] = (GameObject)Instantiate(columnsPrefab2, objectPoolPosition, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if(!GameController.Instance.isGameOver && timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0;
            float spawnYPosition = Random.Range(columnYMin, columnYMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);

            currentColumn++;

            if(currentColumn >= columnPoolSize) { currentColumn = 0; }
        }
    }
}
