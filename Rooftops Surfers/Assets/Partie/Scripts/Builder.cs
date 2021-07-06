using r = System.Random;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    private r r = new r();
    public List<int> plateformes = new List<int>();
    public List<int> états = new List<int>();
    public Compteur c;

    public GameObject[] sols = new GameObject[3];
    
    private int compteur_medium;
    private int compteur_dur;

    public GameObject[] obstacles;
    public List<List<float>> Z = new List<List<float>>();
    public List<List<float>> Y = new List<List<float>>();

    private void PrepareEtats()
    {
        //Immeuble
        Z.Add(new List<float>{-1.24f, 1.24f});
        Y.Add(new List<float>{-2.426f});
        
        //Pigeon
        Z.Add(new List<float>{-0.233f, 0.233f});
        Y.Add(new List<float>{0.316f, 0.578f, 0.916f});
    }
    
    private int AjustDifficulty(int i)
    {
        if (Compteur.level > 3) return i;
        
        if (Compteur.level > 2)
        {
            if (compteur_dur > 100 && i == 2) return 0;
            return i;
        }
        
        if (Compteur.level > 1)
        {
            if (compteur_dur > 50 && i == 2) return 0;
            if (compteur_medium > 100 && i == 1) return 0;
            return i;
        }
        
        if (Compteur.level > 0)
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

    private void Start()
    {
        Input();
    }

    private void PlateformeGeneration()
    {
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
            temp.transform.position = new Vector3(25 - i, 0, z[états[i]]);
        }
    }
    
    private void Awake()
    {
        PrepareEtats();
        PlateformeGeneration();
    }

    public void Input()
    {
        if (Compteur.level > 7 && c.score % 10 == 0 ||
            Compteur.level > 5 && Compteur.level <= 7 && c.score % 15 == 0 ||
            Compteur.level > 3 && Compteur.level <= 5 && c.score % 20 == 0 ||
            Compteur.level > 1 && Compteur.level <= 3 && c.score % 40 == 0 ||
            Compteur.level <= 1 && c.score % 60 == 0
        )
        {
            int i = r.Next(obstacles.Length);
            Instantiate(obstacles[i]).transform.position = 
                new Vector3(-50, Y[i][r.Next(Y[i].Count)], Z[i][r.Next(Z[i].Count)]);
        }

        Pigeons();
    }

    public int pourcentdepigeon;
    private void Pigeons()
    {//0.1 à 1.05 en Y et 1.28 à 2.7 en Z
        if (r.Next(100) >= pourcentdepigeon) return;

        float y = 1.04f * (float) r.NextDouble() + 0.1f;
        float z = 1.42f * (float) r.NextDouble() + 1.28f;
        int sign = r.Next(2);

        Instantiate(obstacles[1]).transform.position = sign == 0 ? 
            new Vector3(-50, y, z) : 
            new Vector3(-50, y, -z);
    }
}
