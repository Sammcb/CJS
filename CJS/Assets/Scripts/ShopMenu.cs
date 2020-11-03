using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour
{

    public BuildLevel buildLevel;
    private Player player;

    private void Awake() {
        buildLevel = GameObject.Find("World").GetComponent<BuildLevel>();
        player = buildLevel.player.GetComponent<Player>();
    }

    public void Done()
    {
        buildLevel.nextLevel.Invoke();
    }

    public void BuyUpgrade1()
    {
        if(player.coins >= 3) {
           player.coins -= 3;
           player.speed++; 
           Debug.Log("Player coins: " + player.coins);
           Debug.Log("Player speed: " + player.speed);
        }
        else {
            Debug.Log("Not enough coins for upgrade 1.");
        }

    }

    public void BuyUpgrade2()
    {
        if(player.coins >= 3) {
            player.coins -= 3;
            player.range += 2;
            Debug.Log("Player coins: " + player.coins);
            Debug.Log("Player range: " + player.range);
        }
        else {
            Debug.Log("Not enough coins for upgrade 2.");
        }
    }

    public void BuyUpgrade3()
    {
        if(player.coins >= 3) {
            player.coins -= 3;
            player.lives++;
            Debug.Log("Player coins: " + player.coins);
            Debug.Log("Player lives: " + player.lives);
        }
        else {
            Debug.Log("Not enough coins for upgrade 3.");
        }
    }

}
