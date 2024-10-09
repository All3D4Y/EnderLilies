using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillInventory : MonoBehaviour
{
    public GameObject slotPrefab;
    private void Awake()
    {
        for (int i = 0; i < 18; i++)
        {
            Instantiate(slotPrefab, transform);
        }
    }
}
