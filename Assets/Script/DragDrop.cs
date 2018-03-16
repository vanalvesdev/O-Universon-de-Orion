using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour {

    // Use this for initialization
    private Vector3 screenSpace;
    private Vector3 offset;
    public bool canMove;
    void Start () {
        canMove = true;
	}
	
	void OnMouseDown()
    {
        if (canMove) { 
            //translate the cubes position from the world to Screen Point
            screenSpace = Camera.main.WorldToScreenPoint(transform.position);

            //calculate any difference between the cubes world position and the mouses Screen position converted to a world point  
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
        }
    }


    void OnMouseDrag()
    {
        if (canMove)
        {
            //keep track of the mouse position
            Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

            //convert the screen mouse position to world point and adjust with offset
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;

            //update the position of the object in the world
            transform.position = curPosition;
        }
    }
}
