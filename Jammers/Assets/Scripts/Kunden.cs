using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunden : MonoBehaviour {
    public string name = "robert";
    public int reputation = 50;

    [Range(7f,11f)] public float toleranz = Random.Range(7f,11f);

    public void KundeGenerieren()
    {
         string Setname = name;
         int Setreputation = reputation;
         float SetToleranz = toleranz;

    }
}
