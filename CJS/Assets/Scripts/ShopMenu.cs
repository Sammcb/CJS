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
	private string[] scrolltext = {
		"You are small and you definitely can't fly, but you can do one thing to save your world. Click to throw snowballs and extinguish fires.", 
		"Putting out fires is hard work, and you're getting hungry. Collect fish if you can - you can spend fish at the shop to upgrade your abilities.", 
		"Your family is in danger, but you're out of breath. You don't have to put out ALL the fires to save them - you can simply exit the level before the igloos burn down. For each igloo that's left standing, the inhabitants will reward you with two fish.",
		"As you know, seals are the Arctic version of the family dog. If you can pick up a seal before the fires reach them, they will grant you an extra life!",
		"The fires rage as you traverse the Arctic. Better get those fish before they burn up - if you hear a sizzle, you're too late...",
		"Be careful brave one, fire can spread very quickly. Did you know you can click and hold to throw snowballs continuously?",
		"Everywhere you look, there's always someone to save. But you know in your heart that your true love is waiting for you. Hurry!", 
		"Quickly now, your fellow penguins are counting on you! But, is it better to zip through or make sure you've saved everyone? The choice is yours.", 
		"It doesn't look too bad up ahead, but looks can be decieving...", 
		"It's getting warm in here, and there's still so much to do, but the end is in sight. Make haste and don't give up!", 
		"Oh no, now it's REALLY everywhere. Fight your way through for the good of the Arctic!", 
		"Your true love is waiting at the end! Find her to save the day and take a well-deserved break.", 
		"You've done it!"
	};

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
		scrollText.text = scrolltext[world.levelNum];
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
