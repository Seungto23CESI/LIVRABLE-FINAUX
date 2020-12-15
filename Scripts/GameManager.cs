using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject client;

    public float spawnTime = 500f;

    public List<GameObject> chairs_and_tables;

    private void Awake()
    {
        chairs_and_tables = GetTables();
    
    }
    void Start()
    {
        InvokeRepeating("SpawnClient", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnClient()
    {
        var newClient = GameObject.Instantiate(client);
        client.transform.position = new Vector3((float)-1.76, (float)0, (float)-1.58);
    }

    List<GameObject> GetTables()
    {
        List<GameObject> tables = new List<GameObject>();

        GameObject inside_objects = GameObject.Find("inside_objects");

        Transform[] chairs = inside_objects.transform.Find("chairs_and_tables").gameObject.transform.GetComponentsInChildren<Transform>(true);

        Transform[] wall_tables  = inside_objects.transform.Find("walls").gameObject.transform.GetComponentsInChildren<Transform>(true);

        foreach (Transform t in chairs)
        {
            if (t.gameObject.name.StartsWith("Table "))
                tables.Add(t.gameObject);
        }

        foreach (Transform t in wall_tables)
        {
            if (t.gameObject.name.StartsWith("Table "))
                tables.Add(t.gameObject);
        }


        return tables;
    }
}
