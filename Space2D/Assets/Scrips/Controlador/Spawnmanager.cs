using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn Configuration")]
    [SerializeField] GameObject spawnObject; //prefab del objeto a instanciar
    public float spawnInitialDelay = 4f; //Tiempo de espera hasta la primera instancia de repetición
    public float spawnRate = 2f; //Lapso de tiempo entre instanciaciones

    [Header("Ramdomizer Configuration")]
    [SerializeField] bool isRandom;
    [SerializeField] float randomLimitX;


    void Start()
    {
        if (isRandom) InvokeRepeating(nameof(RandomSpawner), spawnInitialDelay, spawnRate); //Método de spawn random
        else InvokeRepeating(nameof(Spawner), spawnInitialDelay, spawnRate); //InvokeRepeating(Nombre de método + tiempo inicial + tiempo de repetición)

    }

    void Spawner()
    {
        //Instanciar una copia del objeto asignado en spawnObject
        //Instantiate (Prefab + position + rotation)
        Instantiate(spawnObject, transform.position, Quaternion.identity);
    }

    void RandomSpawner()
    {
        float randomPosX = Random.Range(-randomLimitX, randomLimitX);
        Vector3 randomizedPos = new Vector3(randomPosX, transform.position.y, 0);
        Instantiate(spawnObject, randomizedPos, Quaternion.identity);
    }
}