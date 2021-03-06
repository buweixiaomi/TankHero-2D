﻿using UnityEngine;
using System.Collections;

public class DrawText : MonoBehaviour {
    
    UnityEngine.UI.Text txtInfo;
    private GameObject tankHero;
    private CoinManager coinManagerScript;
    private Health healthScript;
    
    void Awake()
    {
        txtInfo = this.GetComponent<UnityEngine.UI.Text> ();
        UpdateTankHero();
    }

    void UpdateTankHero()
    {
        tankHero = GameObject.FindGameObjectWithTag(Tags.hero);
        if (tankHero == null) { return; }
        coinManagerScript = tankHero.GetComponent<CoinManager>();
        healthScript = tankHero.GetComponentInChildren<Health>();
    }
        
    // Use this for initialization
    void Start () {
        
    }
    
    
    // Update is called once per frame
    void Update () {
        var builder = new System.Text.StringBuilder();
        //DrawMouseInfo(builder);
        DrawScreenInfo(builder);
        DrawTankHeroInfo(builder);
        txtInfo.text = builder.ToString();
    }

    void DrawMouseInfo(System.Text.StringBuilder builder)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;     
        if(Physics.Raycast(ray, out hit))
        {
            builder.AppendLine(string.Format ("input: {0} mouse: {1} | {2}", 
                                          Input.mousePosition, hit.point, hit.transform.gameObject.name));
        }
        else
        {
            builder.AppendLine(string.Format ("input: {0} mouse: {1} | {2}", 
                                          Input.mousePosition, "null", "null"));
        }
    }

    void DrawScreenInfo(System.Text.StringBuilder builder)
    {
        var width = Screen.width;
        var height = Screen.height;
        builder.AppendLine(string.Format("screen:{0}, {1}", width, height));
    }

    void DrawTankHeroInfo(System.Text.StringBuilder builder)
    {
        if (tankHero == null) { UpdateTankHero(); }

        if (tankHero == null || coinManagerScript == null || healthScript == null) 
        {
            builder.AppendLine("tank heor not found!"); 
            return;
        }

        builder.AppendLine(string.Format("money: {0}", coinManagerScript.money));
        builder.AppendLine(string.Format("health: {0}/{1}", healthScript.health, healthScript.maxHealth));

    }
}
