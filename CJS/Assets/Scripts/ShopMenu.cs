using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour {
	public World world;
	public Button button1;
	public Button button2;
	public Button button3;
	public TMPro.TextMeshProUGUI buttoncost1;
	public TMPro.TextMeshProUGUI buttoncost2;
	public TMPro.TextMeshProUGUI buttoncost3;
	public TMPro.TextMeshProUGUI scrollText;
	private Color grayedOut;
	private Color normalColor;
	private int cost1 = 3;
	private int cost2 = 3;
	private int cost3 = 3;

	private void Start() {
		UpdateShop();
	}

	public void UpdateShop() {
		button1.interactable = true;
		button2.interactable = true;
		button3.interactable = true;
		if(world.coins < cost1 || world.speed >= 8) button1.interactable = false;
		if(world.coins < cost2 || world.range >= 9) button2.interactable = false;
		if(world.coins < cost3 || world.lives >= 5) button3.interactable = false;
		if(world.speed >= 8) buttoncost1.text = "MAX";
		if(world.range >= 9) buttoncost2.text = "MAX";
		if(world.lives >= 5) buttoncost3.text = "MAX";

		scrollText.text = "hello";

	}

	public void Done() {
		button1.interactable = true;
		button2.interactable = true;
		button3.interactable = true;
		world.nextLevel.Invoke();
	}

	public void BuyUpgrade1() {
		if(world.coins >= cost1 && world.speed < 8) {
		   world.coins -= cost1;
		   world.speed++;
		   cost1++;
		   buttoncost1.text = "x" + cost1.ToString();
		}
		world.UpdateStats();
		UpdateShop();
	}

	public void BuyUpgrade2() {
		if(world.coins >= cost2 && world.range < 9) {
			world.coins -= cost2;
			world.range += 2;
			cost2++;
			buttoncost2.text = "x" + cost2.ToString();
		}
		world.UpdateStats();
		UpdateShop();
	}

	public void BuyUpgrade3() {
		if(world.coins >= cost3 && world.lives < 5) {
			world.coins -= cost3;
			world.lives++;
			cost3++;
			buttoncost3.text = "x" + cost3.ToString();
		}
		world.UpdateStats();
		UpdateShop();
	}
}
