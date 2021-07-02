using r = System.Random;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public List<int> plateformes = new List<int>();
    public List<int> états = new List<int>();
    public Compteur c;

    public GameObject[] sols = new GameObject[3];
    
    private int compteur_medium;
    private int compteur_dur;


    private int AjustDifficulty(int i)
    {
        if (Compteur.level > 10) return i;
        
        if (Compteur.level > 7)
        {
            if (compteur_dur > 100 && i == 2) return 0;
            return i;
        }
        
        if (Compteur.level > 5)
        {
            if (compteur_dur > 50 && i == 2) return 0;
            if (compteur_medium > 100 && i == 1) return 0;
            return i;
        }
        
        if (Compteur.level > 3)
        {
            if (compteur_dur > 20 && i == 2) return 0;
            if (compteur_medium > 50 && i == 1) return 0;
            return i;
        }
        
        else
        {
            if (i == 2) return 0;
            if (compteur_medium > 20 && i == 1) return 0;
            return i;
        }
    }

    private int n(int i)
    {
        if (i == 1) compteur_medium++;
        if (i == 2) compteur_dur++;
        return i;
    }
    
    private void Awake()
    {
        r r = new r();
        for (int i = 0; i < 50; i++)
        {
            plateformes.Add(0);
            états.Add(0);
        }
        for (int i = 50; i < 700; i++)
        {
            int p = n(AjustDifficulty(r.Next(3))); plateformes.Add(p);
            int e = r.Next(p + 1); états.Add(e);
        }

        float[] z = {0, -0.34f, 0.34f};

        for (int i = 0; i < 700; i++)
        {
            GameObject temp = Instantiate(sols[plateformes[i]]);
            c.Translations.Add(temp.GetComponent<Translation>());
            temp.transform.position = new Vector3(25 - i, 0, z[états[i]]);
        }
    }
}
