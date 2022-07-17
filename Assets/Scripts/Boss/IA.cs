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
    public Poing_IA _Poing_IA;

    public float _WaitTimeSwapPhase = 2;

    public static float Temps;


    // Start is called before the first frame update
    void Start()
    {
        IA.Temps = 0;
        Timer = DurationPhase;
        StartCoroutine(Waiter());
        _SP.ChangeArme();
    }

    // Update is called once per frame
    void Update()
    {
        IA.Temps += Time.deltaTime;
        Timer -= Time.deltaTime;
        if(Timer <= 0)
        {
            StopPhase();

            StartCoroutine(Waiter());
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
                _Poing_IA.OnAttaqueMode = false;
                break;
            case 1 : 
                _PoingMur.OnAttaqueMode = true;
                _Laser_Attaque.OnAttaqueMode = false;
                _Poing_IA.OnAttaqueMode = false;
                break;
            case 2:
                _Poing_IA.OnAttaqueMode = true;
                _PoingMur.OnAttaqueMode = false;
                _Laser_Attaque.OnAttaqueMode = false;
                break;
        }
    }
    
    public void StopPhase()
    {
        _Laser_Attaque.OnAttaqueMode = false;
        _PoingMur.OnAttaqueMode = false;
        _Poing_IA.OnAttaqueMode = false;
    }

    IEnumerator Waiter()
    {
       
        yield return new WaitForSeconds(_WaitTimeSwapPhase);
        SwapPhase();
    }

}
