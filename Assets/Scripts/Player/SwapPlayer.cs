using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapPlayer : MonoBehaviour
{
    public List<GameObject> Armes; // 0 = Arc // 1 = Epee 

    public List<Collider2D> MesColliders; // 0 = EpeePetit // 1 = EpeeMoyen // 2 = EpeeGrand / 3 = Arc

    public List<float> MesScoresArmes;

    public static float Difficulte;

    void Start()
    {
        SwapPlayer.Difficulte = 0;
    }

    public void ChangeArme()
    {
        for (int i = 0; i < Armes.Count; i++)
        {
            Armes[i].SetActive(false);
        }

        int index = Random.Range(0,Armes.Count);
        if(index == 0) // Arc
        {
            Armes[index].SetActive(true);
            Armes[index].GetComponent<Arc>().RandomiseArc();
            ActivateCollider(3);

            MesScoresArmes.Add(20);
        }

        if (index == 1) // Epee
        {
            Armes[index].SetActive(true);
            int NbEpee = Random.Range(0, 3); // 0 = EpeePetit // 1 = EpeeMoyen // 2 = EpeeGrand
            ActivateCollider(NbEpee);
            Armes[index].GetComponent<Sword>().RandomiseSword(NbEpee);


            if(NbEpee == 0)
            {
                MesScoresArmes.Add(60);
            }
            if (NbEpee == 1)
            {
                MesScoresArmes.Add(80);
            }
            if (NbEpee == 2)
            {
                MesScoresArmes.Add(100);
            }

        }


    }

    void ActivateCollider(int index)
    {
        for(int i = 0; i < MesColliders.Count; i++)
        {
            MesColliders[i].enabled = false;
        }
        MesColliders[index].enabled = true;
    }

    public void CalculeScoreArme()
    {
        SwapPlayer.Difficulte = 0;

        for (int i = 0; i < MesScoresArmes.Count; i++)
        {
            SwapPlayer.Difficulte += MesScoresArmes[i];
        }

        SwapPlayer.Difficulte = SwapPlayer.Difficulte / MesScoresArmes.Count;

        SceneManager.LoadScene("GameOver");
    }
}
