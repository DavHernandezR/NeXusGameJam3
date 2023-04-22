using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control : MonoBehaviour
{

    [Header("GangParameters")]
    public float INITIAL_LIFE = 100f;
    public float INITIAL_MORALE = 100f;
    private float defense;
    private float attack;
    public string gang;

    [Header("Buffs")]
    public float activateLifeBuff;
    public float activateMoraleBuff;
    public float activateDefenseBuff;
    public float activateAttackBuff;
    private float LIFE_BUFF = 1f;
    private float MORALE_BUFF = 1f;
    private float DEFENSE_BUFF = 1f;
    private float ATTACK_BUFF = 1f;

    [Header("Nerfs")]
    public float activateLifeNerf;
    public float activateMoraleNerf;
    public float activateDefenseNerf;
    public float activateAttackNerf;
    private float LIFE_NERF = 1f;
    private float MORALE_NERF = 1f;
    private float DEFENSE_NERF = 1f;
    private float ATTACK_NERF = 1f;

    [Header("Anothers")]
    public string typeOfCard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectCard(string typeOfCard, string gang){
        Animation(gang);
    }

    void Animation(string gang){
        if(gang == "myGang"){

        }
        else{

        }
    }

    float Life(float life, bool activateLifeBuff = false, bool activateLifeNerf = false){
        if (activateLifeBuff)
        {
            life = ActivateBuff(INITIAL_LIFE, life, LIFE_BUFF);
        }
        if (activateLifeNerf)
        {
            life = ActivateNerf(life, LIFE_NERF);
        }
        return life;
    }

    float Morale(float morale, bool activateMoraleBuff = false, bool activateMoraleNerf = false){

        if (activateMoraleBuff)
        {
            morale = ActivateBuff(INITIAL_MORALE, morale, MORALE_BUFF);
        }
        if (activateMoraleNerf)
        {
            morale = ActivateNerf(morale, MORALE_NERF);
        }
        return morale;
    }

    float ActivateBuff(float initial_parameter, float parameter, float buff){

        if (parameter*(1+buff) < initial_parameter)
        {
            parameter = parameter*(1+buff);
        }
        else parameter = initial_parameter;
        return parameter;
    }

    float ActivateNerf(float parameter, float nerf){
        
        if (parameter*(1-nerf) < 0)
        {
            parameter = 0;
        }
        else parameter = parameter*(1-nerf);
        return parameter;
    }
}
