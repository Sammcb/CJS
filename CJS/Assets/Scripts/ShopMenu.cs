using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour {
	public World world;
	public GameObject button1;
	public GameObject button2;
	public GameObject button3;
	public GameObject buttoncost1;
	public GameObject buttoncost2;
	public GameObject buttoncost3;
	private Color grayedOut;
	private Color normalColor;
	private int cost1 = 3;
	private int cost2 = 3;
	private int cost3 = 3;

	private void Start() {
		UpdateShop();
	}

	public void UpdateShop() {
		if(world.coins < cost1) button1.GetComponent<Button>().interactable = false;
		if(world.coins < cost2) button2.GetComponent<Button>().interactable = false;
		if(world.coins < cost3) button3.GetComponent<Button>().interactable = false;
		if(world.speed >= 8) buttoncost1.GetComponent<TMPro.TextMeshProUGUI>().text = "MAX";
		if(world.range >= 9) buttoncost2.GetComponent<TMPro.TextMeshProUGUI>().text = "MAX";
		if(world.lives >= 5) buttoncost3.GetComponent<TMPro.TextMeshProUGUI>().text = "MAX";
	}

	public void Done() {
		button1.GetComponent<Button>().interactable = true;
		button2.GetComponent<Button>().interactable = true;
		button3.GetComponent<Button>().interactable = true;
		world.nextLevel.Invoke();
	}

	public void BuyUpgrade1() {
		if(world.coins >= cost1 && world.speed < 8) {
		   world.coins -= cost1;
		   world.speed++;
		   cost1++;
		   buttoncost1.GetComponent<TMPro.TextMeshProUGUI>().text = "x" + cost1.ToString();
		}
		world.UpdateStats();
		UpdateShop();
	}

	public void BuyUpgrade2() {
		if(world.coins >= cost2 && world.range < 9) {
			world.coins -= cost2;
			world.range += 2;
			cost2++;
			buttoncost2.GetComponent<TMPro.TextMeshProUGUI>().text = "x" + cost2.ToString();
		}
		world.UpdateStats();
		UpdateShop();
	}

	public void BuyUpgrade3() {
		if(world.coins >= cost3 && world.lives < 5) {
			world.coins -= cost3;
			world.lives++;
			cost3++;
			buttoncost3.GetComponent<TMPro.TextMeshProUGUI>().text = "x" + cost3.ToString();
		}
		world.UpdateStats();
		UpdateShop();
	}
}
