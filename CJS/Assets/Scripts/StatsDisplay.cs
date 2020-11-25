using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StatsDisplay: MonoBehaviour {
	public void UpdateText(int val) {
		GetComponent<TMPro.TextMeshProUGUI>().text = val.ToString();
	}
}
