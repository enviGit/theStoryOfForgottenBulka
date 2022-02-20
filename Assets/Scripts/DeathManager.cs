using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathManager : MonoBehaviour
{
    public static int deaths = 0;
    [SerializeField] private Text deathText;
    
    private void Start()
    {
        deathText.text = "ŚMIERCI: " + deaths;
    }
    public void IncreaseDeaths()
    {
        deaths++;
        deathText.text = "ŚMIERCI: " + deaths;
    }
}
