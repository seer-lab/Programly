using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 0.25f;
    private bool isFaceRight = true;
    private bool isFaceUp = false;

    public Tilemap objects;
    private Vector3 currentPosition;

    // Update is called once per frame
    /*void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }*/

    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

       /*currentPosition = transform.position + new Vector3(horizontal, vertical, 0);
        Vector3Int objectCheck = objects.WorldToCell(currentPosition);

        if(objects.GetTile(objectCheck) == null)
        {
            transform.Translate(horizontal * speed, vertical * speed, 0f);
        }*/
        transform.Translate(horizontal * speed, vertical * speed, 0f);
    }
}
