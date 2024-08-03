using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    private float[] arrPosY = {-7.5f};

    [SerializeField]
    private float spawnInterval = 1.5f;  //장애물 스폰되는 간격 (1.5초)

    // Start is called before the first frame update
    void Start()
    {
        StartEnermyRoutine();
    }

    void StartEnermyRoutine() {
        StartCoroutine("EnermyRoutine");
    }

    IEnumerator EnermyRoutine(){   //장애물 반복호출
        yield return new WaitForSeconds(3f); // 장애물이 나오기까지 기다리는 시간 (3초)

        while(true) {
            foreach(float posY in arrPosY){ //arrPosY 배열에 들어있는 값을 하나씩 꺼내 posY에 넣어서 배열을 한바퀴 다 돌때동안 반복작동
                int index = Random.Range(0, enemies.Length); //랜덤으로 자동차 뽑기
                SpawnEnermy(posY, index);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Update is called once per frame
    void SpawnEnermy(float posY, int index){  // 장애물이 소환되고 움직이는 속도, 위치
        Vector3 spawnPos = new Vector3(transform.position.x, posY , transform.position.z);
        Instantiate(enemies[index], spawnPos, Quaternion.identity);
    }
}
