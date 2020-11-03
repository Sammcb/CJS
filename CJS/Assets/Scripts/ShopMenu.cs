using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{

    public BuildLevel buildLevel;
    private Player player;

    private void Awake() {
        buildLevel = GameObject.Find("World").GetComponent<BuildLevel>();
        player = buildLevel.player.GetComponent<Player>();

        // disable upgrades that player can't afford or are maxed out
        GameObject button1 = GameObject.Find("Upgrade1Button");
        GameObject button2 = GameObject.Find("Upgrade2Button");
        GameObject button3 = GameObject.Find("Upgrade3Button");
        GameObject cost1 = GameObject.Find("Upgrade1Cost");
        GameObject cost2 = GameObject.Find("Upgrade2Cost");
        GameObject cost3 = GameObject.Find("Upgrade3Cost");

        if(player.coins < 3) {
            button1.GetComponent<Image>().color = Color.gray;
            button1.GetComponent<Button>().interactable = false;

            button2.GetComponent<Image>().color = Color.gray;
            button2.GetComponent<Button>().interactable = false;

            button3.GetComponent<Image>().color = Color.gray;
            button3.GetComponent<Button>().interactable = false;
        }
        if(player.speed >= 8) {
            button1.GetComponent<Image>().color = Color.gray;
            cost1.GetComponent<TMPro.TextMeshProUGUI>().text = "NO FURTHER UPGRADES";
        }
        if(player.range >= 9) {
            button2.GetComponent<Image>().color = Color.gray;
            cost2.GetComponent<TMPro.TextMeshProUGUI>().text = "NO FURTHER UPGRADES";
        }
        if(player.lives >= 5) {
            button3.GetComponent<Image>().color = Color.gray;
            cost3.GetComponent<TMPro.TextMeshProUGUI>().text = "NO FURTHER UPGRADES";
        }

    }

    public void Done()
    {
        Debug.Log("Done with shop.");
        buildLevel.nextLevel.Invoke();
    }

    public void BuyUpgrade1()
    {
        if(player.coins >= 3 && player.speed < 8) {
           player.coins -= 3;
           player.speed++; 
           Debug.Log("Player coins: " + player.coins);
           Debug.Log("Player speed: " + player.speed);
        }
        else {
            Debug.Log("Not enough coins for upgrade 1.");
        }
        player.UpdateText();

    }

    public void BuyUpgrade2()
    {
        if(player.coins >= 3 && player.range < 9) {
            player.coins -= 3;
            player.range += 2;
            Debug.Log("Player coins: " + player.coins);
            Debug.Log("Player range: " + player.range);
        }
        else {
            Debug.Log("Not enough coins for upgrade 2.");
        }
        player.UpdateText();
    }

    public void BuyUpgrade3()
    {
        if(player.coins >= 3 && player.lives < 5) {
            player.coins -= 3;
            player.lives++;
            Debug.Log("Player coins: " + player.coins);
            Debug.Log("Player lives: " + player.lives);
        }
        else {
            Debug.Log("Not enough coins for upgrade 3.");
        }
        player.UpdateText();
    }

}
