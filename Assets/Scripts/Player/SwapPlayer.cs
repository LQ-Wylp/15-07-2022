using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPlayer : MonoBehaviour
{
    public List<GameObject> Armes; // 0 = Arc // 1 = Epee 

    public List<Collider2D> MesColliders; // 0 = EpeePetit // 1 = EpeeMoyen // 2 = EpeeGrand / 3 = Arc

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
        }

        if (index == 1) // Epee
        {
            Armes[index].SetActive(true);
            int NbEpee = Random.Range(0, 3); // 0 = EpeePetit // 1 = EpeeMoyen // 2 = EpeeGrand
            ActivateCollider(NbEpee);
            Armes[index].GetComponent<Sword>().RandomiseSword(NbEpee);


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
}
