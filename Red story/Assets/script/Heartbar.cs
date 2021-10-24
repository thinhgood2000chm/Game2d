using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Heartbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
   [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image curentHealtBar;
    // Start is called before the first frame update
    void Start()
    {
        totalHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        curentHealtBar.fillAmount = playerHealth.currentHealth / 10;
    }
}
