using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject inputUI;

    [Header("Player HP")]
    public GameObject HP1;
    public GameObject HP2;
    public GameObject HP3;

    public Sprite HPZero;
    public Sprite HPHalf;
    public Sprite HPFull;

    [Header("Enemy Hp")]
    public GameObject enemyHPCam;
    Slider enemyHPBarFill;

    playerController player;
    EnemyController enemy;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();
        enemyHPBarFill = enemyHPCam.transform.GetChild(0).gameObject.GetComponent<Slider>();
    }

    private void Update()
    {
        //플레이어 HP 관리
        switch (player.playerNowHp)
        {
            case 0:
                HPNow(HPZero, HPZero, HPZero);
                break;

            case 1:
                HPNow(HPHalf, HPZero, HPZero);
                break;

            case 2:
                HPNow(HPFull, HPZero, HPZero);
                break;

            case 3:
                HPNow(HPFull, HPHalf, HPZero);
                break;

            case 4:
                HPNow(HPFull, HPFull, HPZero);
                break;

            case 5:
                HPNow(HPFull, HPFull, HPHalf);
                break;

            case 6:
                HPNow(HPFull, HPFull, HPFull);
                break;
        }

        //적 HP 정면 보게 만들기
        enemyHPCam.transform.LookAt(Camera.main.transform);

        enemyHPBarFill.value = enemy.enemyNowHp;

        //적 HP가 0이 될 경우 Off
        if (enemy.enemyNowHp <= 0)
        {
            enemyHPCam.SetActive(false);
        }
    }

    private void HPNow(Sprite hp1Image, Sprite hp2Image, Sprite hp3Image)
    {
        HP1.GetComponent<Image>().sprite = hp1Image;
        HP2.GetComponent<Image>().sprite = hp2Image;
        HP3.GetComponent<Image>().sprite = hp3Image;
    }
}
