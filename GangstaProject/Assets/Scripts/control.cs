using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control : MonoBehaviour
{

    [Header("GangParameters")]
    public float INITIAL_LIFE = 100f;
    public float INITIAL_MORALE = 100f;
    private float MORALE_DECREASE = 1f;
    private float KNIFE_ATTACK = 1f;
    private float GUN_ATTACK = 1f;
    public GameObject myGang;
    public GameObject enemyGang;
    [Header("Cards")]
    public GameObject card1;
    public GameObject card2;
    public GameObject card3;
    public GameObject card4;
    [Header("EnemyCards")]
    public GameObject EnemyCard1;
    public GameObject EnemyCard2;
    public GameObject EnemyCard3;
    public GameObject EnemyCard4;

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

    [Header("ActionCards")]
    private int knife = 1;
    private int gun = 2;
    private int computer = 3;
    private int bucks = 4;
    private int drugs = 5;
    private int stereo = 6;
    private int carWithMachineGun = 7;
    private int carWithGlasses = 8;
    private int muscles = 9;

    // Start is called before the first frame update
    void Start()
    {
        //generar las typeOfCard aleatoriamente
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectionCard(int numberOfCard){
        Animation(true);
        switch (typeOfAction)
        {
            case 1:{
                knifeAttack(enemyGang);
                break;
            }
            case 2:{
                gunAttack(enemyGang);
                break;
            }
            case 3:{
                computerAttack(enemyGang, new List<GameObject>() {enemyCard1, enemyCard2, enemyCard3, enemyCard4});
                break;
            }
            case 4:{
                bucksAttack(enemyGang);
                break;
            }
            case 5:{
                drugsNerf(enemyGang);
                break;
            }
            case 6:{
                stereoBuff(myGang);
                break;
            }
            case 7:{
                carWithMachineGunAttack(enemyGang);
                break;
            }
            case 8:{
                carWithGlassesWearing(myGang);
                break;
            }
            case 9:{
                musclesDefense(myGang);
                break;
            }
            default:
        }
        //generar un nuevo y aleatorio typeOfCard para numberOfCard
    }

    public void EnemySelectionCard(int numberOfCard){
        Animation(false);
        switch (typeOfAction)
        {
            case 1:{
                knifeAttack(myGang);
                break;
            }
            case 2:{
                gunAttack(myGang);
                break;
            }
            case 3:{
                computerAttack(myGang, new List<GameObject>() {card1, card2, card3, card4});
                break;
            }
            case 4:{
                bucksAttack(myGang);
                break;
            }
            case 5:{
                drugsNerf(myGang);
                break;
            }
            case 6:{
                stereoBuff(enemyGang);
                break;
            }
            case 7:{
                carWithMachineGunAttack(myGang);
                break;
            }
            case 8:{
                carWithGlassesWearing(enemyGang);
                break;
            }
            case 9:{
                musclesDefense(enemyGang);
                break;
            }
            default:
        }
    }

    void Animation(bool gang){

        if(gang){
            myGang.position = new Vector3(0,1.77f,0);
        }
        else{
            enemyGang.position = new Vector3(0,-1.77,0);
        }
    }

    void knifeAttack(GameObject gangAttacked){
        gangAttacked.life -= KNIFE_ATTACK*gangAttacked.morale;
        gangAttacked.morale -= MORALE_DECREASE;
    }

    void gunAttack(GameObject gangAttacked){
        gangAttacked.life -= GUN_ATTACK*gangAttacked.morale;
        gangAttacked.morale -= MORALE_DECREASE;
    }
    
    void computerAttack(GameObject gangAttacked, List<GameObject> cards){
        pickRandomCard(cards).SetActive(false);
    }
/// QUEDÉ ACÁ DEFINIENDO ATAQUES///
    private GameObject pickRandomCard(List<GameObject> cardList){
        Random rnd = new Random();
        int randIndex = rnd.Next(cards.Count);
        GameObject randomCard = cards[randIndex];
        return randomCard;
    }

    float LifeAlterations(float life, bool activateLifeBuff = false, bool activateLifeNerf = false){
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

    float MoraleAlterations(float morale, bool activateMoraleBuff = false, bool activateMoraleNerf = false){

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
