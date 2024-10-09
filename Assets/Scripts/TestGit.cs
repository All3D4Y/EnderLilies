using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGit : MonoBehaviour
{
   
    public void Test()
    {
       Debug.Log(GameManager.instance.gameDB.GetSkillData("skill1").prefabPath);
    }
}
