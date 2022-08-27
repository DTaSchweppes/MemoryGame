using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DTaSchweppes.Tools
{
 public class CardsCollect : MonoBehaviour
 {
    [SerializeField] private CardsSpawner _cardsSpawner = null; 
    public Card _openCard = null;
	public void OpenCard(Card openCard)
    {
        if (_openCard == null)
            _openCard = openCard;

        if (_openCard.cardIndex == 2)
        {
            _cardsSpawner._countFrontTrue--;
            CheckCountCardsOnScene();
            StartCoroutine(DestroyCards());
        }
    }
    
    private void CheckCountCardsOnScene()
    {
        if (_cardsSpawner._countFrontTrue==0){
            _cardsSpawner.DestroyCardsStart();
            StartCoroutine(SpawnNewGrid());
        }
    }

    IEnumerator SpawnNewGrid(){
        yield return new WaitForSeconds(2f);
        _cardsSpawner._levelDifficult++; 
        _cardsSpawner.startXPos = -4f;
        _cardsSpawner.startYPos = 0f;
        _cardsSpawner.Spawn();
    }
    IEnumerator DestroyCards(){
        yield return new WaitForSeconds(0.1f);
        _openCard.CardDestroy();
    }
 }
 ///_openCard.transform.Translate(new Vector3(-4, 0, 0) * Time.deltaTime);
}