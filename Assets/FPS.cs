using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPS : MonoBehaviour
{
    private TextMeshProUGUI Stats;
    public float UpdateFreq = 0.3f;
    private float UpdateTimer;
    // Start is called before the first frame update
    void Start()
    {
        Stats = GetComponent<TextMeshProUGUI>();
        UpdateTimer = UpdateFreq;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer -= Time.deltaTime;
        if (UpdateTimer <= 0)
        {
            float fps = (1f / Time.deltaTime);
            float memory = UnityEngine.Profiling.Profiler.GetTotalAllocatedMemoryLong()/(1048f*1048f);
            string StatsString = "FPS: " + Mathf.Round(fps) + "\nMemory Usage: " + Mathf.Round(memory) + " MB";
            Stats.text = StatsString;
            UpdateTimer = UpdateFreq;
        }
    }
}
