using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;
using TMPro;

public class Control : MonoBehaviour
{

    private int roundCounter;
    public TMP_Text rounds;
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
    public varCard1 varCard1;
    public varCard2 varCard2;
    public varCard3 varCard3;
    public varCard4 varCard4;
    [Header("EnemyCards")]
    public GameObject enemyCard1;
    public GameObject enemyCard2;
    public GameObject enemyCard3;
    public GameObject enemyCard4;
    public varEnemyCard1 varEnemyCard1;
    public varEnemyCard2 varEnemyCard2;
    public varEnemyCard3 varEnemyCard3;
    public varEnemyCard4 varEnemyCard4;

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

    void Start()
    {

        life.GetComponent<Slider>().value = INITIAL_LIFE;
        morale.GetComponent<Slider>().value = INITIAL_MORALE;
        enemyLife.GetComponent<Slider>().value = INITIAL_LIFE;
        enemyMorale.GetComponent<Slider>().value = INITIAL_MORALE;
        roundCounter = 1;
        BegginingMessage();
        
        /*ChooseTypeOfCard(card1);
        ChooseTypeOfCard(card2);
        ChooseTypeOfCard(card3);
        ChooseTypeOfCard(card4);
        ChooseTypeOfCard(enemyCard1);
        ChooseTypeOfCard(enemyCard2);
        ChooseTypeOfCard(enemyCard3);
        ChooseTypeOfCard(enemyCard4);*/
    }

    private void BegginingMessage()
    {
        List<string> begginingText = new List<string>() {"Gonna bangin!!!", "Lets go to gangbang!!!", "Gonna blow your head off!!!", "Let's blast 'em!!!", "Bust 'em up!!!", "What chu' doin' in ma' place?!?", "We're gonna bust y'all!!!", "Let's buck 'em down!!!"};
        int randText = UnityEngine.Random.Range(0,7);
        rounds.text = begginingText[randText];
    }

    private void ChooseTypeOfCard(GameObject card){

        typeOfCard = UnityEngine.Random.Range(1,9);

        if (card == card1)
        {
            varCard1 = FindObjectOfType<varCard1>();
            varCard1.typeOfAction = typeOfCard;
        }
        else if (card == card2)
        {
            varCard2 = FindObjectOfType<varCard2>();
            varCard2.typeOfAction = typeOfCard;
        }
        else if (card == card3)
        {
            varCard3 = FindObjectOfType<varCard3>();
            varCard3.typeOfAction = typeOfCard;
        }
        else if (card == card4)
        {
            varCard4 = FindObjectOfType<varCard4>();
            varCard4.typeOfAction = typeOfCard;
        }
        else if (card == enemyCard1)
        {
            varEnemyCard1 = FindObjectOfType<varEnemyCard1>();
            varEnemyCard1.typeOfAction = typeOfCard;
        }
        else if (card == enemyCard2)
        {
            varEnemyCard2 = FindObjectOfType<varEnemyCard2>();
            varEnemyCard2.typeOfAction = typeOfCard;
        }
        else if (card == enemyCard3)
        {
            varEnemyCard3 = FindObjectOfType<varEnemyCard3>();
            varEnemyCard3.typeOfAction = typeOfCard;
        }
        else if (card == enemyCard4)
        {
            varEnemyCard4 = FindObjectOfType<varEnemyCard4>();
            varEnemyCard4.typeOfAction = typeOfCard;
        }
    }

    private void ShowRound(int round){

        rounds.text = "Round "+round;
    }

    public void SelectionCard(GameObject card){

        ShowRound(roundCounter);
        roundCounter += 1;
        List<GameObject> enemyCards = new List<GameObject>() {enemyCard1, enemyCard2, enemyCard3, enemyCard4};
        int randNumber = UnityEngine.Random.Range(1,4);
        GameObject enemyCard = enemyCards[randNumber];

        if (card == card1)
        {
            varCard1 = FindObjectOfType<varCard1>();
            typeOfCard = varCard1.typeOfAction;
        }
        else if (card == card2)
        {
            varCard2 = FindObjectOfType<varCard2>();
            typeOfCard = varCard2.typeOfAction;
        }
        else if (card == card3)
        {
            varCard3 = FindObjectOfType<varCard3>();
            typeOfCard = varCard3.typeOfAction;
        }
        else if (card == card4)
        {
            varCard4 = FindObjectOfType<varCard4>();
            typeOfCard = varCard4.typeOfAction;
        }

        switch (typeOfCard)
        {
            case 1:{
                knifeAttack(true, enemyLife, enemyMorale, card);
                break;
            }
            case 2:{
                gunAttack(true, enemyLife, enemyMorale, card);
                break;
            }
            case 3:{
                computerAttack(true, enemyCards, card);
                break;
            }
            case 4:{
                bucksAttack(true, enemyLife, enemyMorale, card, roundCounter);
                break;
            }
            case 5:{
                drugsNerf(true, enemyMorale, card, roundCounter);
                break;
            }
            case 6:{
                stereoBuff(true, morale, card);
                break;
            }
            case 7:{
                carWithMachineGunAttack(enemyLife, enemyMorale, card);
                break;
            }
            case 8:{
                carWithGlassesWearing(myGang, card);
                break;
            }
            case 9:{
                musclesDefense(life, card);
                break;
            }
            default:
            break;
        }
        //ChooseTypeOfCard(card);
        EnemySelectionCard(enemyCard);
    }

    public void EnemySelectionCard(GameObject enemyCard){

        if (enemyCard == enemyCard1)
        {
            varEnemyCard1 = FindObjectOfType<varEnemyCard1>();
            typeOfCard = varEnemyCard1.typeOfAction;
        }
        else if (enemyCard == enemyCard2)
        {
            varEnemyCard2 = FindObjectOfType<varEnemyCard2>();
            typeOfCard = varEnemyCard2.typeOfAction;
        }
        else if (enemyCard == enemyCard3)
        {
            varEnemyCard3 = FindObjectOfType<varEnemyCard3>();
            typeOfCard = varEnemyCard3.typeOfAction;
        }
        else if (enemyCard == enemyCard4)
        {
            varEnemyCard4 = FindObjectOfType<varEnemyCard4>();
            typeOfCard = varEnemyCard4.typeOfAction;
        }

        switch (typeOfCard)
        {
            case 1:{
                knifeAttack(false, life, morale, enemyCard);
                break;
            }
            case 2:{
                gunAttack(false, life, morale, enemyCard);
                break;
            }
            case 3:{
                computerAttack(false, new List<GameObject>() {card1, card2, card3, card4}, enemyCard);
                break;
            }
            case 4:{
                bucksAttack(false, life, morale, enemyCard, roundCounter);
                break;
            }
            case 5:{
                drugsNerf(false, morale, enemyCard, roundCounter);
                break;
            }
            case 6:{
                stereoBuff(false, enemyMorale, enemyCard);
                break;
            }
            case 7:{
                carWithMachineGunAttack(life, morale, enemyCard);
                break;
            }
            case 8:{
                carWithGlassesWearing(enemyGang, enemyCard);
                break;
            }
            case 9:{
                musclesDefense(enemyGang, enemyCard);
                break;
            }
            default:
            break;
        }
        // ChooseTypeOfCard(enemyCard);
    }

    void Animation(bool gang, Transform attacker, Vector3 initialPosition){

        if(gang){
            attacker.position = new Vector2(55f, initialPosition.y);
        }
        else{
            attacker.position = new Vector2(45f, initialPosition.y);
        }
    }

    void InitialAnimation(Transform attacker, Vector3 initialPosition){
            attacker.position = initialPosition;
    }

    IEnumerator GangMovement(bool gang, Transform attacker){

        Vector3 initialPosition = attacker.position;

        Animation(gang, attacker, initialPosition);
        yield return new WaitForSecondsRealtime(3);
        InitialAnimation(attacker, initialPosition);
        yield return new WaitForSecondsRealtime(3);
    }

    IEnumerator GangMultiMovement(bool gang, Transform attacker, int actualCounter){
        yield return new WaitForSecondsRealtime(3);
        StartCoroutine(MultiMovement(gang, attacker, actualCounter));
    }

    IEnumerator MultiMovement(bool actualGang, Transform attacker, int actualCounter){
        Vector3 initialPosition = attacker.position;
        int roundDif = roundCounter-actualCounter;
        Debug.Log(roundDif);

        if(actualGang){
            switch (roundDif)
            {
                case 0:
                    attacker.position = new Vector2(60f, 10f);
                    break;
                case 1:
                    attacker.position = new Vector2(50f, 10f);
                    break;
                case 2:
                    attacker.position = new Vector2(40f, 10f);
                    break;
                case 3:
                    attacker.position = new Vector2(40f, 20f);
                    break;
                case 4:
                    attacker.position = new Vector2(initialPosition.x, initialPosition.y);
                    StopCoroutine(MultiMovement(actualGang, attacker, actualCounter));
                    yield return null;
                    break;
            }
        }
        else{
            switch (roundDif)
            {
                case 0:
                    attacker.position = new Vector2(40f, -10f);
                    break;
                case 1:
                    attacker.position = new Vector2(50f, -10f);
                    break;
                case 2:
                    attacker.position = new Vector2(60f, -10f);
                    break;
                case 3:
                    attacker.position = new Vector2(70f, 0f);
                    break;
                case 4:
                    attacker.position = new Vector2(initialPosition.x, initialPosition.y);
                    StopCoroutine(MultiMovement(actualGang, attacker, actualCounter));
                    yield return null;
                    break;
            }
        }
    }

    IEnumerator WaitForNextRound(){
        yield return new WaitForSecondsRealtime(3);
    }

    void knifeAttack(bool gang, GameObject life, GameObject morale, GameObject card){

        float lifeValue = life.GetComponent<Slider>().value;
        float moraleValue = morale.GetComponent<Slider>().value;
        Transform attacker = card.transform.parent.GetChild(7).GetChild(0);

        StartCoroutine(GangMovement(gang, attacker));
        lifeValue -= KNIFE_ATTACK*moraleValue*0.1f;
        moraleValue -= MORALE_DECREASE;
        life.GetComponent<Slider>().value = lifeValue;
        morale.GetComponent<Slider>().value = moraleValue;
        StopCoroutine(GangMovement(gang, attacker));
        StartCoroutine(WaitForNextRound());
        StopCoroutine(WaitForNextRound());
    }

    void gunAttack(bool gang, GameObject life, GameObject morale, GameObject card){

        float lifeValue = life.GetComponent<Slider>().value;
        float moraleValue = morale.GetComponent<Slider>().value;
        Transform attacker = card.transform.parent.GetChild(7).GetChild(1);

        StartCoroutine(GangMovement(gang, attacker));
        lifeValue -= GUN_ATTACK*moraleValue*0.1f;
        moraleValue -= MORALE_DECREASE;
        life.GetComponent<Slider>().value = lifeValue;
        morale.GetComponent<Slider>().value = moraleValue;
    }
    
    void computerAttack(bool gang, List<GameObject> cards, GameObject card){

        Transform attacker = card.transform.parent.GetChild(7).GetChild(2);

        StartCoroutine(GangMovement(gang, attacker));
        pickRandomCard(cards).SetActive(false);
    }

    private GameObject pickRandomCard(List<GameObject> cardList){

        int randIndex = UnityEngine.Random.Range(1,4);

        GameObject randomCard = cardList[randIndex];
        return randomCard;
    }

    void bucksAttack(bool gang, GameObject life, GameObject morale, GameObject card, int actualCounter){

        Transform attacker = card.transform.parent.GetChild(7).GetChild(3);
        float lifeValue = life.GetComponent<Slider>().value;
        float moraleValue = morale.GetComponent<Slider>().value;

        Vector3 initialPosition = attacker.position;
        Animation(gang, attacker, initialPosition);

        StartCoroutine(GangMultiMovement(gang, attacker, actualCounter));
        lifeValue -= GUN_ATTACK*moraleValue*0.1f;
        moraleValue -= MORALE_DECREASE;
        life.GetComponent<Slider>().value = lifeValue;
        morale.GetComponent<Slider>().value = moraleValue;
    }

    void drugsNerf(bool gang, GameObject morale, GameObject card, int actualCounter){

        Transform attacker = card.transform.parent.GetChild(7).GetChild(4);

        Vector3 initialPosition = attacker.position;
        Animation(gang, attacker, initialPosition);

        StartCoroutine(GangMultiMovement(gang, attacker, actualCounter));
        morale.GetComponent<Slider>().value -= MORALE_NERF;
    }

    void stereoBuff(bool gang, GameObject morale, GameObject card){

        Transform attacker = card.transform.parent.GetChild(7).GetChild(5);

        StartCoroutine(GangMovement(gang, attacker));
        morale.GetComponent<Slider>().value += MORALE_BUFF;
    }

    void carWithMachineGunAttack(GameObject life, GameObject morale, GameObject card){

        float lifeValue = life.GetComponent<Slider>().value;
        float moraleValue = morale.GetComponent<Slider>().value;
        float MACHINEGUN_MULTIPLICATOR = 3f;

        carAnimation();
        lifeValue -= MACHINEGUN_MULTIPLICATOR*GUN_ATTACK*moraleValue*0.1f;
        moraleValue -= MORALE_DECREASE;
        life.GetComponent<Slider>().value = lifeValue;
        morale.GetComponent<Slider>().value = moraleValue;
    }

    void carWithGlassesWearing(GameObject gangBuffed, GameObject card){
        carAnimation();
        //gangBuffed.glasses = true;
    }

    void carAnimation(){

    }

    void musclesDefense(GameObject gangDefended, GameObject card){

    }
}
