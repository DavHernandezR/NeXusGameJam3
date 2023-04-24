using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Control : MonoBehaviour
{

    [Header("GangParameters")]
    public float INITIAL_LIFE = 100f;
    public float INITIAL_MORALE = 100f;
    private float MORALE_DECREASE = 1f;
    private float KNIFE_ATTACK = 1f;
    private float GUN_ATTACK = 1f;
    public GameObject myGang;
    public GameObject enemyGang;
    public GameObject life;
    public GameObject morale;
    public GameObject enemyLife;
    public GameObject enemyMorale;
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
    public int typeOfCard;

    [Header("Buff/Nerf")]
    private float MORALE_BUFF = 1f;
    private float MORALE_NERF = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //generar las typeOfCard aleatoriamente
        /*ChooseTypeOfCard(card1);
        ChooseTypeOfCard(card2);
        ChooseTypeOfCard(card3);
        ChooseTypeOfCard(card4);
        ChooseTypeOfCard(EnemyCard1);
        ChooseTypeOfCard(EnemyCard2);
        ChooseTypeOfCard(EnemyCard3);
        ChooseTypeOfCard(EnemyCard4);*/

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChooseTypeOfCard(GameObject card){
        typeOfCard = UnityEngine.Random.Range(1,9);
    }

    public void SelectionCard(GameObject card){
        //int typeOfAction = card.GetComponent<Variables>().GetVariable(0).IntegerValue;


        StartCoroutine(GangMovement(true));
        switch (1)
        {
            case 1:{
                knifeAttack(enemyLife, enemyMorale);
                break;
            }
            case 2:{
                gunAttack(enemyLife, enemyMorale);
                break;
            }
            case 3:{
                computerAttack(new List<GameObject>() {EnemyCard1, EnemyCard2, EnemyCard3, EnemyCard4});
                break;
            }
            case 4:{
                bucksAttack(enemyLife, enemyMorale);
                break;
            }
            case 5:{
                drugsNerf(enemyMorale);
                break;
            }
            case 6:{
                stereoBuff(morale);
                break;
            }
            case 7:{
                carWithMachineGunAttack(enemyLife, enemyMorale);
                break;
            }
            case 8:{
                carWithGlassesWearing(myGang);
                break;
            }
            case 9:{
                musclesDefense(life);
                break;
            }
            default:
            break;
        }
        //ChooseTypeOfCard(card);
    }

    public void EnemySelectionCard(GameObject enemyCard, int typeOfAction){

        StartCoroutine(GangMovement(false));
        /*switch (typeOfAction)
        {
            case 1:{
                knifeAttack(life, morale);
                break;
            }
            case 2:{
                gunAttack(life, morale);
                break;
            }
            case 3:{
                computerAttack(new List<GameObject>() {card1, card2, card3, card4});
                break;
            }
            case 4:{
                bucksAttack(life, morale);
                break;
            }
            case 5:{
                drugsNerf(morale);
                break;
            }
            case 6:{
                stereoBuff(enemyMorale);
                break;
            }
            case 7:{
                carWithMachineGunAttack(life, morale);
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
            break;
        }*/
        //ChooseTypeOfCard(enemyCard);
    }

    void Animation(bool gang){

        if(gang){
            myGang.transform.position = new Vector3(45f,25f,0);
        }
        else{
            enemyGang.transform.position = new Vector3(55f,25f,0);
        }
    }

    void InitialAnimation(bool gang){

        if(gang){
            myGang.transform.position = new Vector3(24.7f,25f,0);
        }
        else{
            enemyGang.transform.position = new Vector3(75.3f,25f,0);
        }
    }

    IEnumerator GangMovement(bool gang){
        Animation(gang);
        yield return new WaitForSecondsRealtime(5);
        InitialAnimation(gang);
    }

    void knifeAttack(GameObject life, GameObject morale){
        float lifeValue = 0;
        float moraleValue = 0;
        lifeValue -= KNIFE_ATTACK*morale.GetComponent<Slider>().value;
        moraleValue -= MORALE_DECREASE;
        life.GetComponent<Slider>().value = lifeValue;
        morale.GetComponent<Slider>().value = moraleValue;
    }

    void gunAttack(GameObject life, GameObject morale){
        float lifeValue = 0;
        float moraleValue = 0;
        lifeValue -= GUN_ATTACK*morale.GetComponent<Slider>().value;
        moraleValue -= MORALE_DECREASE;
        life.GetComponent<Slider>().value = lifeValue;
        morale.GetComponent<Slider>().value = moraleValue;
    }
    
    void computerAttack(List<GameObject> cards){
        pickRandomCard(cards).SetActive(false);
    }

    private GameObject pickRandomCard(List<GameObject> cardList){
        int randIndex = UnityEngine.Random.Range(1,4);
        GameObject randomCard = cardList[randIndex];
        return randomCard;
    }

    void bucksAttack(GameObject life, GameObject morale){
        float lifeValue = 0;
        float moraleValue = 0;
        lifeValue -= GUN_ATTACK*morale.GetComponent<Slider>().value;
        moraleValue -= MORALE_DECREASE;
        life.GetComponent<Slider>().value = lifeValue;
        morale.GetComponent<Slider>().value = moraleValue;
    }

    void drugsNerf(GameObject morale){
        morale.GetComponent<Slider>().value -= MORALE_NERF;
    }

    void stereoBuff(GameObject morale){
        morale.GetComponent<Slider>().value += MORALE_BUFF;
    }

    void carWithMachineGunAttack(GameObject life, GameObject morale){
        float lifeValue = 0;
        float moraleValue = 0;
        float MACHINEGUN_MULTIPLICATOR = 3f;
        carAnimation();
        lifeValue -= MACHINEGUN_MULTIPLICATOR*GUN_ATTACK*morale.GetComponent<Slider>().value;
        moraleValue -= MORALE_DECREASE;
        life.GetComponent<Slider>().value = lifeValue;
        morale.GetComponent<Slider>().value = moraleValue;
    }

    void carWithGlassesWearing(GameObject gangBuffed){
        carAnimation();
        //gangBuffed.glasses = true;
    }

    void carAnimation(){

    }

    void musclesDefense(GameObject gangDefended){

    }
}
