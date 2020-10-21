using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {

    #region VARIABLES
    private float moveSpeed = 3;
    #endregion

    public void Start() {

    }

    public void Update() {
        // Movement
        Vector3 movement = (Vector3.up * Input.GetAxis("Vertical")) + (Vector3.right * Input.GetAxis("Horizontal"));
        transform.Translate(Vector3.Normalize(movement) * Time.deltaTime * moveSpeed);

        // Fire hose
        if(Input.GetMouseButtonDown(0)) {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.z = 0;
            Debug.DrawRay(transform.position, mouse-transform.position, Color.white, 5);
        }

    }

}
