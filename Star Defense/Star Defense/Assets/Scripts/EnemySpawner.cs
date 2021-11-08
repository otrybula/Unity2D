using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyi = 0; enemyi < waveConfig.GetNumberOfEnemies(); enemyi++)
        {
        var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypointIndex()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }

    }

    private IEnumerator SpawnAllWaves()
    {
        for (int wavei = startingWave; wavei < waveConfigs.Count; wavei++)
        {
            var currentWave = waveConfigs[wavei];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }

    }
}
