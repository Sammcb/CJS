using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class StatsDisplay : MonoBehaviour
{
    public void UpdateText(int val) {
        // got this line from https://forum.unity.com/threads/changing-textmeshpro-text-from-ui-via-script.462250/
        GetComponent<TMPro.TextMeshProUGUI>().text = val.ToString();
    }

}
