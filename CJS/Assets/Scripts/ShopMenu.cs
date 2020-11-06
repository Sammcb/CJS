using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{

    public BuildLevel buildLevel;
    public Player player;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject cost1;
    public GameObject cost2;
    public GameObject cost3;
    private Color grayedOut;
    private Color normalColor;

    private void Start() {
        buildLevel = GameObject.Find("World").GetComponent<BuildLevel>();
        player = buildLevel.player.GetComponent<Player>();
        UpdateShop();
    }

    public void UpdateShop() {
        if (!player) {
            player = buildLevel.player.GetComponent<Player>();
        }

        if(player.coins < 3) {
            button1.GetComponent<Button>().interactable = false;
            button2.GetComponent<Button>().interactable = false;
            button3.GetComponent<Button>().interactable = false;
        }
        if(player.speed >= 8) {
            cost1.GetComponent<TMPro.TextMeshProUGUI>().text = "MAXED";
        }
        if(player.range >= 9) {
            cost2.GetComponent<TMPro.TextMeshProUGUI>().text = "MAXED";
        }
        if(player.lives >= 5) {
            cost3.GetComponent<TMPro.TextMeshProUGUI>().text = "MAXED";
        }
    }

    public void Done()
    {
        button1.GetComponent<Button>().interactable = true;
        button2.GetComponent<Button>().interactable = true;
        button3.GetComponent<Button>().interactable = true;

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
        UpdateShop();

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
        UpdateShop();

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
        UpdateShop();

    }

}
