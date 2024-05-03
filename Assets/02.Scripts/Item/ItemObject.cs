using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public TextMeshProUGUI GetItem_text;

    private void Awake()
    {
        Collider col = GetComponentInChildren<Collider>();
    }

    private void Start()
    {
        GetItem_text.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Player"))
        {
            GetItem_text.gameObject.SetActive(true);
            GetItem_text.text = "아이템 줍기: [E]";

            Debug.Log("아이템이 플레이어에게 닿았다.");


        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("아이템이 플레이어에게 닿아있다.");

    }

    private void OnTriggerExit(Collider other)
    {
        GetItem_text.gameObject.SetActive(false);
        Debug.Log("아이템이 플레이어에게서 떨어졌다.");

    }
}
