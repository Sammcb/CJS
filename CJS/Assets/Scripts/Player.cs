using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {

    #region VARIABLES
    public float moveSpeed = 1.1f;
    private float range = 2;
    public int coins;
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
            Vector3 direction = Vector3.Normalize(mouse-transform.position) * range;
            Debug.DrawRay(transform.position, direction, Color.white, 5);
        }

    }

}
