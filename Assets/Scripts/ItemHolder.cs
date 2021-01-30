using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    public string heldItem;
    void Start()
    {

    }

    void Update()
    {

    }

    public void ChangeHeldItem(string newHeldItem)
    {
        heldItem = newHeldItem;
    }
}
