using UnityEngine;

public class TestManager : MonoBehaviour
{
    public WaveManager waveManager, waveManager2;
    int currentWave;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waveManager.StartWaves();
    }

    // Update is called once per frame
    void Update()
    {
        if(!waveManager.IsActive())
        {
            waveManager2.StartWaves();
        }
    }
}
