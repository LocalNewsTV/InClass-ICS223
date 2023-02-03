using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Laps;
    public void UpdateScore(int laps)
    {
        Laps.text = "Laps: " + laps + (laps >= 3 ? " Mr. Bones Wild Ride Never Ends..." : "");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
