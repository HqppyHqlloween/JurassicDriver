using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    
using System.IO;

public class CoinSystem : MonoBehaviour
{
    [SerializeField] private GameObject Fruit;
    [SerializeField] private TMP_Text fruitText;
    string lastHit = "";
    public int FruitAmount;
    
     void Start()
    {
        string savingText = Application.persistentDataPath + "/coins.txt";
        if(File.Exists(savingText))
        {
        }
        else FruitAmount = 0;
        Fruit = GameObject.Find("Coins");
    }

    void Update()
    {
        fruitText.text = KevinGameManager.instance.coins.coinsValue.ToString();
    }


    void OnTriggerEnter(Collider collider)
    {
        if(lastHit == collider.name)
        {
            return;
        } lastHit = collider.name;

        if(collider.CompareTag("Coins"))
        {
            KevinGameManager.instance.coins.coinsValue += 100;
            Destroy(collider.transform.gameObject);

        }

    }
}
