using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataController
{

    private static int punkte;
    public static void SetPunkte(int neuePunktzahl)
    {
        punkte = neuePunktzahl;
    }
    public static int GetPunkte() {
        return punkte;
    }
}
