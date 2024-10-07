using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentsManager : MonoBehaviour
{
    public int branch;
    public Player player;
    public ContentsSystem contentsSystem;

    private void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position)<0.5f && Input.GetMouseButtonDown(0)) //버튼키로 바꾸면됨
        {
            contentsSystem.contentsBranch = branch;
            contentsSystem.gameObject.SetActive(true);
        }
    }
}