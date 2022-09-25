using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject createdObject;
    public GameObject text;
    public GameObject button;

    public GameObject prefabDice;
    public List<Material> dices = new List<Material>();
    public bool isMoving = true;



    void Start()
    {
        ChooseMaterial(prefabDice);
        InstantiateObject(prefabDice);

        button.SetActive(false);
        text.SetActive(false);
    }


    void Update()
    {
        if (!isMoving)
        {
            button.SetActive(true);
            text.SetActive(true);
        }
        else
        {
            button.SetActive(false);
            text.SetActive(false);
        }
    }

    private void ChooseMaterial(GameObject dice)
    {
        int random = Random.Range(0, dices.Count);
        dice.GetComponent<Renderer>().sharedMaterial = dices[random];
    }


    private void InstantiateObject(GameObject dice)
    {
        createdObject = Instantiate(dice);
    }


    public void playAgain()
    {
        if (createdObject)
        {
            text.GetComponent<TMPro.TextMeshProUGUI>().text = "";

            Dice dice = createdObject.GetComponent<Dice>();
            ChooseMaterial(createdObject);
            dice.Force(createdObject);
            dice.transform.position = dice.RandomPosition();
            dice.transform.rotation = dice.RandomRotation();
        }
    }
    
}
