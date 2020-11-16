using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataController
{

    private static int punkte;
    private static string spielerName;
    private static float startZeit;
    private static float gesamtZeit;
    public static void SetPunkte(int neuePunktzahl)
    {
        punkte = neuePunktzahl;
    }
    public static int GetPunkte() {
        return punkte;
    }
    public static void SetSpielerName(string name)
    {
        spielerName = name;
    }
    public static string GetSpielerName()
    {
        return spielerName;
    }
    public static void SetStartZeit(float zeit)
    {
        startZeit = zeit;
    }
    public static float BerechneGesamtZeit()
    {
        gesamtZeit = Time.time - startZeit;
        return gesamtZeit;
    }
    public static float GetGesamtZeit()
    {
        return gesamtZeit;
    }
}
