using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ClientState
{
    QUEUE,
    RANK_CHIEF,
    TABLE,
    COMMAND
}

public class character_movement : MonoBehaviour
{
    public float walk_Speed = 1f;
    public float z_Speed = 1.5f;

    private CharacterAnimation character_animation;
    
    Vector3 targetPosition = new Vector3((float)6.9, 0, (float)-1.6);
    
    public ClientState clientState;

    public GameManager gameManager;

    public RankController rankController;
    // Start is called before the first frame update
    void Awake()
    {
        character_animation = GetComponentInChildren<CharacterAnimation>();
        gameManager = GetComponent<GameManager>();
        rankController = GetComponent<RankController>();
        clientState = ClientState.QUEUE;
    }

    // Update is called once per frame
    void Update()
    {
        if(clientState == ClientState.QUEUE)
        {
            MoveTo(targetPosition);
        }else if(clientState == ClientState.RANK_CHIEF)
        {
            GoToTable();
        }
    }

    void FixedUpdate()
    {
        //DetectMovement();
    }


    void MoveTo(Vector3 targetPosition)
    {

        Vector3 relativePosition = targetPosition - transform.position;

        Vector3 movement = relativePosition.normalized * walk_Speed * Time.deltaTime;


        if (Math.Floor(transform.position.sqrMagnitude) < Math.Floor(targetPosition.sqrMagnitude))
        {
            GetComponent<CharacterController>().Move(movement);
            AnimateWalk(true);
        }
        else
        {
            GetComponent<CharacterController>().Move(relativePosition);
            AnimateWalk(false);
            clientState = ClientState.RANK_CHIEF;
        }
    }

    void GoToTable()
    {
        GameObject table = rankController.AttributeTable();

        print(table);
        MoveTo(table.transform.position);

        clientState = ClientState.TABLE;
    }

    void AnimateWalk(bool trigger)
    {
        character_animation.Walk(trigger);
    }

}
