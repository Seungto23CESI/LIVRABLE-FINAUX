using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameManager gameManager;

    private void Awake()
    {
       gameManager = GetComponent<GameManager>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject AttributeTable()
    {
        List<GameObject> tables = gameManager.chairs_and_tables;
        GameObject table = null;
        int availables = 0;
        int index = 0;
        for(int i = 0; i < tables.Count; i++)
        {
            TableController tableController = tables[i].GetComponent<TableController>();
            if (!tableController.isBusy)
            {
                index = i;
                availables++;
                table = tables[i];
            }
        }

        tables[index].GetComponent<TableController>().isBusy = true;

        return table;
    }
}
