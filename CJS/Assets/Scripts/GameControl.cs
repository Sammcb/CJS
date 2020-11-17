using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// From https://gamedevelopertips.com/how-to-handle-data-between-scenes-in-unity/
public class GameControl : MonoBehaviour
{
    //Static reference
    public static GameControl control;
 
    //Data to persist
    public float musicVol;
    public float sfxVol;
 
    void Awake()
    {
        //Let the gameobject persist over the scenes
        DontDestroyOnLoad(gameObject);
        //Check if the control instance is null
        if (control == null)
        {
            //This instance becomes the single instance available
            control = this;
        }
        //Otherwise check if the control instance is not this one
        else if (control != this)
        {
            //In case there is a different instance destroy this one.
            Destroy(gameObject);
        }
    }
}