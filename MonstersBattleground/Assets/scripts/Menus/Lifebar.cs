using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lifebar : MonoBehaviour
{
    public Image Healthbar;
    [SerializeField] private ScriptableInt _maxLife;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int _ZombieDamage) 
    {
        _maxLife.Value -= _ZombieDamage;
        Healthbar.fillAmount = _maxLife.Value / 100f;
    }

}
