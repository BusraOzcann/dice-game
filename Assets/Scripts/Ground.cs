using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    private string text;


    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        text = other.gameObject.tag;
    }

    void OnTriggerStay(Collider other)
    {
        if (!gameManager.isMoving)
        {
            gameManager.text.GetComponent<TMPro.TextMeshProUGUI>().text = text;
        }
    }
}
