using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MonsterDetector : MonoBehaviour
{
    Player player;
    float elapsedTime = 0;
    float intervalTime = 0.05f;
    [SerializeField] float sensorRange;
    public bool isDetectedPlayer { get; private set; } = false;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= intervalTime)
        {
            DetectedPlayer();
            elapsedTime = 0;
        }
    }

    void DetectedPlayer()
    {
        float distance = Vector2.Distance(new Vector2(transform.position.x,transform.position.y),
                                            new Vector2(player.transform.position.x, player.transform.position.y));

        if (distance <= sensorRange )
        {
            isDetectedPlayer = true;
            Debug.Log("플레이어 탐지");
        }
        else
        {
            isDetectedPlayer = false;
        }
    }
}
