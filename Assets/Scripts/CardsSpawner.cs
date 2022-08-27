using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DTaSchweppes.Tools
{
 public class CardsSpawner : MonoBehaviour
 {
     public int _levelDifficult = 3;
     [SerializeField] private Card _card;
     public int _countFrontTrue = 0;
     private int _generatedIndex = 0;
     public float startXPos = -4f;
     public float startYPos = 0f;
     public void Spawn(){
        if (_levelDifficult == 5){
                 _levelDifficult = 4;
             }
             if (_levelDifficult == 4){
                 startXPos = -4f;
                 startYPos = -5.5f;
             }
             _countFrontTrue = 0;
             for (int i=0;i<_levelDifficult;i++)
             {
                 for (int j=0;j<_levelDifficult;j++){
                 var card = Instantiate(_card, new Vector3(startXPos+=2f, startYPos, 0),Quaternion.identity);//1) -1.8,3.5 0,3.5 1.8 1.8 по иксу это ширина карточки 2)
                _generatedIndex = Random.Range(1,3);
                 if (_generatedIndex == 2 && _countFrontTrue<_levelDifficult)//проверка максимум 3 штуки
                 {
                     _countFrontTrue++;
                 } else
                 {
                     _generatedIndex=1;
                 }
                 if (i==_levelDifficult-1 && j==_levelDifficult-2){
                     if (_countFrontTrue < _levelDifficult){
                         _generatedIndex = 2;
                         _countFrontTrue++;
                     }
                 }
                 _card.SettingsOfCard(_generatedIndex);
                 }
                 startXPos = -4f;
                 startYPos+=3.5f;
             }
     }
     public void DestroyCardsStart(){
         StartCoroutine(MoveAllCardsLeft());
     }

     IEnumerator MoveAllCardsLeft(){
         Card[] cards = FindObjectsOfType<Card>();
         foreach (Card card in cards){//при создании помещать в список. При создании добавляем
            Card objectForMoving = card; 
            objectForMoving.StartCoroutineMoveOut();
        }
        yield return null;
     }
	
 }
}