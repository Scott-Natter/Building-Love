using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeControl : MonoBehaviour
{
    public bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            MoveWithMouse();
            if (Input.GetKeyDown(KeyCode.R))
            {
                transform.Rotate(0f, 0.0f, 90.0f, 0f);
            }
        }

    }

    void MoveWithMouse()
    {

        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
        transform.position = new Vector3(pos_move.x, pos_move.y, pos_move.z);
    }

    void OnMouseDown()
    {
        isMoving = false;
        this.gameObject.tag = "Ground";
    }
}
