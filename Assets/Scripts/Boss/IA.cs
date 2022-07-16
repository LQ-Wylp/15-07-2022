using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{

    public SwapPlayer _SP;
    public float DurationPhase = 60;
    private float Timer;

    public int IndexPhase = -1; // Laser = 0 // Poing Mur = 1
    public int NbPhase = 2;

    public PoingMur _PoingMur;
    public Laser_Attaque _Laser_Attaque;


    // Start is called before the first frame update
    void Start()
    {
        Timer = DurationPhase;
        SwapPhase();
        _SP.ChangeArme();
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer <= 0)
        {
            SwapPhase();
            _SP.ChangeArme();
            Timer = DurationPhase;
        }
    }

    public void SwapPhase()
    {
        int LastIndex = IndexPhase;
        while(LastIndex == IndexPhase)
        {
            IndexPhase = Random.Range(0, NbPhase);
        }

        switch (IndexPhase)
        {
            case 0 : 
                _Laser_Attaque.OnAttaqueMode = true;
                _PoingMur.OnAttaqueMode = false;
                break;
            case 1 : 
                _PoingMur.OnAttaqueMode = true;
                _Laser_Attaque.OnAttaqueMode = false;
                break;
        }
    }
    



}
