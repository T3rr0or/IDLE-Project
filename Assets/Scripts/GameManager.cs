using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text balanceText;
    public Text clickValueText;
    public double coins;
    public double coinsClickValue;

    public Text coinsPerSecText;
    public Text clickUpgrade1Text;
    public Text clickUpgrade2Text;
    public Text productionUpgrade1Text;
    public Text productionUpgrade2Text;

    public double coinsPerSecond;
    public double clickUpgrade1Cost;
    public int clickUpgrade1Level;

    public double productionUpgrade1Cost;
    public int productionUpgrade1Level;


    public double clickUpgrade2Cost;
    public int clickUpgrade2Level;

    public double productionUpgrade2Cost;
    public double productionUpgrade2Power;
    public int productionUpgrade2Level;

    public Text gemsText;
    public Text gemBoostText;
    public Text gemsToGetText;

    public double gems;
    public double gemBoost;
    public double gemsToGet;


    public void Start()
    {
        Load();
    }

    // LOAD & SAVE
    public void Load()
    {
        coins = double.Parse(PlayerPrefs.GetString("coins", "0"));
        coinsClickValue = double.Parse(PlayerPrefs.GetString("coinsClickValue", "1"));
        clickUpgrade1Cost = double.Parse(PlayerPrefs.GetString("clickUpgrade1Cost", "10"));
        clickUpgrade2Cost = double.Parse(PlayerPrefs.GetString("clickUpgrade2Cost", "100"));
        productionUpgrade1Cost = double.Parse(PlayerPrefs.GetString("productionUpgrade1Cost", "25"));
        productionUpgrade2Cost = double.Parse(PlayerPrefs.GetString("productionUpgrade2Cost", "250"));
        productionUpgrade2Power = double.Parse(PlayerPrefs.GetString("productionUpgrade2Power", "5"));

        gems = double.Parse(PlayerPrefs.GetString("gems", "0"));

        productionUpgrade1Level = PlayerPrefs.GetInt("productionUpgrade1Level", 0);
        productionUpgrade2Level = PlayerPrefs.GetInt("productionUpgrade2Level", 0);
        clickUpgrade1Level = PlayerPrefs.GetInt("clickUpgrade1Level", 0);
        clickUpgrade2Level = PlayerPrefs.GetInt("clickUpgrade2Level", 0);
    }

    public void Save()
    {
        PlayerPrefs.SetString("coins", coins.ToString());
        PlayerPrefs.SetString("coinsClickValue", coinsClickValue.ToString());
        PlayerPrefs.SetString("clickUpgrade1Cost", clickUpgrade1Cost.ToString());
        PlayerPrefs.SetString("clickUpgrade2Cost", clickUpgrade2Cost.ToString());
        PlayerPrefs.SetString("productionUpgrade1Cost", productionUpgrade1Cost.ToString());
        PlayerPrefs.SetString("productionUpgrade2Cost", productionUpgrade2Cost.ToString());
        PlayerPrefs.SetString("productionUpgrade2Power", productionUpgrade2Power.ToString());

        PlayerPrefs.SetString("gems", gems.ToString());

        PlayerPrefs.SetInt("productionUpgrade1Level", productionUpgrade1Level);
        PlayerPrefs.SetInt("productionUpgrade2Level", productionUpgrade2Level);
        PlayerPrefs.SetInt("clickUpgrade1Level", clickUpgrade1Level);
        PlayerPrefs.SetInt("clickUpgrade2Level", clickUpgrade2Level);

    }

    public void Update()
    {
        gemsToGet = (150 * System.Math.Sqrt(coins / 1e7));
        gemBoost = (gems * 0.05) + 1;


        gemsToGetText.text = "Prestige:\n+" + System.Math.Floor(gemsToGet).ToString("F0") + " Gems";
        gemsText.text = "Gems: " + System.Math.Floor(gems).ToString("F0");
        gemBoostText.text = gemBoost.ToString("F2") + "x boost";

        coinsPerSecond = (productionUpgrade1Level + (productionUpgrade2Power * productionUpgrade2Level)) * gemBoost;


        // Click Upgrade 1

        if (coinsClickValue > 1000000000)
        {
            clickValueText.text = "Click\n+" + (coinsClickValue / 1000000000).ToString("F2") + "B";
        }
        else if (coinsClickValue > 1000000)
        {
            clickValueText.text = "Click\n+" + (coinsClickValue / 1000000).ToString("F2") + "M";
        }
        else if (coinsClickValue > 1000)
        {
            clickValueText.text = "Click\n+" + (coinsClickValue / 1000).ToString("F2") + "K";
        }
        else
            clickValueText.text = "Click\n+" + coinsClickValue.ToString("F0") + " Bits";

        if (coins > 1000000000)
        {
            balanceText.text = "Wallet: " + (coins / 1000000000).ToString("F2") + "B";
        }
        else if (coins > 1000000)
        {
            balanceText.text = "Wallet: " + (coins / 1000000).ToString("F2") + "M";
        }
        else if (coins > 1000)
        {
            balanceText.text = "Wallet: " + (coins / 1000).ToString("F2") + "K";
        }
        else
            balanceText.text = "Wallet: " + coins.ToString("F0");

        string clickUpgrade1CostString;
        if (clickUpgrade1Cost > 1000000000)
        {
            clickUpgrade1CostString = (clickUpgrade1Cost / 1000000000).ToString("F2") + "B";
        }
        else if (clickUpgrade1Cost > 1000000)
        {
            clickUpgrade1CostString = (clickUpgrade1Cost / 1000000).ToString("F2") + "M";
        }
        else if (clickUpgrade1Cost > 1000)
        {
            clickUpgrade1CostString = (clickUpgrade1Cost / 1000).ToString("F2") + "K";
        }
        else
            clickUpgrade1CostString = clickUpgrade1Cost.ToString("F0");


        clickUpgrade1Text.text = "Click Upgrade 1\nCost: " + clickUpgrade1CostString + " Bits\nPower +1 Click\nLevel: " + clickUpgrade1Level;


        // Click Upgrade 2

        string clickUpgrade2CostString;
        if (clickUpgrade2Cost > 1000000000)
        {
            clickUpgrade2CostString = (clickUpgrade2Cost / 1000000000).ToString("F2") + "B";
        }
        else if (clickUpgrade2Cost > 1000000)
        {
            clickUpgrade2CostString = (clickUpgrade2Cost / 1000000).ToString("F2") + "M";
        }
        else if (clickUpgrade2Cost > 1000)
        {
            clickUpgrade2CostString = (clickUpgrade2Cost / 1000).ToString("F2") + "K";
        }
        else
            clickUpgrade2CostString = clickUpgrade2Cost.ToString("F0");

        clickUpgrade2Text.text = "Click Upgrade 2\nCost: " + clickUpgrade2CostString + " Bits\nPower +5 Click\nLevel: " + clickUpgrade2Level;


        // Mining Rig 1

        string productionUpgrade1CostString;
        if (productionUpgrade1Cost > 1000000000)
        {
            productionUpgrade1CostString = (productionUpgrade1Cost / 1000000000).ToString("F2") + "B";
        }
        else if (productionUpgrade1Cost > 1000000)
        {
            productionUpgrade1CostString = (productionUpgrade1Cost / 1000000).ToString("F2") + "M";
        }
        else if (productionUpgrade1Cost > 1000)
        {
            productionUpgrade1CostString = (productionUpgrade1Cost / 1000).ToString("F2") + "K";
        }
        else
            productionUpgrade1CostString = productionUpgrade1Cost.ToString("F0");

        productionUpgrade1Text.text = "Mining Rig 1\nCost: " + productionUpgrade1CostString + " Bits\nPower +" + gemBoost.ToString("F2") + " Bits/s\nLevel: " + productionUpgrade1Level;


        // Mining Rig 2

        string productionUpgrade2CostString;
        if (productionUpgrade2Cost > 1000000000)
        {
            productionUpgrade2CostString = (productionUpgrade2Cost / 1000000000).ToString("F2") + "B";
        }
        else if (productionUpgrade2Cost > 1000000)
        {
            productionUpgrade2CostString = (productionUpgrade2Cost / 1000000).ToString("F2") + "M";
        }
        else if (productionUpgrade2Cost > 1000)
        {
            productionUpgrade2CostString = (productionUpgrade2Cost / 1000).ToString("F2") + "K";
        }
        else
            productionUpgrade2CostString = productionUpgrade2Cost.ToString("F0");

        productionUpgrade2Text.text = "Mining Rig 2\nCost: " + productionUpgrade2CostString + " Bits\nPower +" + (productionUpgrade2Power * gemBoost).ToString("F2") + " Bits/s\nLevel: " + productionUpgrade2Level;


        // Coins Per Second

        string coinsPerSecondString;
        if (coinsPerSecond > 1000000000)
        {
            coinsPerSecondString = (coinsPerSecond / 1000000000).ToString("F2") + "B";
        }
        else if (coinsPerSecond > 1000000)
        {
            coinsPerSecondString = (coinsPerSecond / 1000000).ToString("F2") + "M";
        }
        else if (coinsPerSecond > 1000)
        {
            coinsPerSecondString = (coinsPerSecond / 1000).ToString("F2") + "K";
        }
        else
            coinsPerSecondString = coinsPerSecond.ToString("F0");

        coinsPerSecText.text = coinsPerSecondString + " Bits/s";
        coins += coinsPerSecond * Time.deltaTime;

        Save();
    }

    // Prestige

    public void Prestige()
    {
        if (coins > 1000)
        {
            coins = 0;
            coinsClickValue = 1;
            clickUpgrade1Cost = 1;
            clickUpgrade2Cost = 100;
            productionUpgrade1Cost = 25;
            productionUpgrade2Cost = 250;
            productionUpgrade2Power = 5;

            productionUpgrade1Level = 0;
            productionUpgrade2Level = 0;
            clickUpgrade1Level = 0;
            clickUpgrade2Level = 0;

            gems += gemsToGet;
        }
    }




    public void Click()
    {
        coins += coinsClickValue;
    }
    public void BuyClickUpgrade1()
    {
        if (coins >= clickUpgrade1Cost)
        {
            clickUpgrade1Level++;
            coins -= clickUpgrade1Cost;
            clickUpgrade1Cost *= 1.07;
            coinsClickValue++;
        }
    }
    public void BuyClickUpgrade2()
    {
        if (coins >= clickUpgrade2Cost)
        {
            clickUpgrade2Level++;
            coins -= clickUpgrade2Cost;
            clickUpgrade2Cost *= 1.09;
            coinsClickValue += 5;
        }
    }


    public void BuyProductionUpgrade1()
    {
        if (coins >= productionUpgrade1Cost)
        {
            productionUpgrade1Level++;
            coins -= productionUpgrade1Cost;
            productionUpgrade1Cost *= 1.07;
        }
    }

    public void BuyProductionUpgrade2()
    {
        if (coins >= productionUpgrade2Cost)
        {
            productionUpgrade2Level++;
            coins -= productionUpgrade2Cost;
            productionUpgrade2Cost *= 1.07;
        }
    }
}
