using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewContentsSystemDB", menuName = "Database/ContentsSystemDB")]
public class ContentsSystemDB : ScriptableObject
{
    public List<ContentsSystem> contentsSystems;
}
