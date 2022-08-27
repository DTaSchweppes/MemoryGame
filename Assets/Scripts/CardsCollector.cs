using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DTaSchweppes.Tools
{
    /*
 public class CardsCollector : MonoBehaviour
 {
	public Card _firstCard = null;
    public Card _secondCard = null;

    public void SetCards(Card openCard)
    {
        if (_firstCard == null)
        {
            _firstCard = openCard;
        } else if (_secondCard == null)
        {
            _secondCard = openCard;
        }
    }
    IEnumerator Fade() {
                yield return new WaitForSeconds(1.5f);
                _secondCard.SideAnimation();
                _firstCard.SideAnimation();
                _firstCard.EnableBoxCollider2d();
                _secondCard.EnableBoxCollider2d();
                print("Очистили карточки");
                _firstCard = null;
                _secondCard = null;
        }
    IEnumerator DestroyCards(){
        yield return new WaitForSeconds(1f);
        _firstCard.CardDestroy();
        _secondCard.CardDestroy();
        _firstCard = null;
        _secondCard = null;
    }

    public void CardsComparison()
    /*{
        if (_secondCard!= null){
            if (_firstCard.cardIndex == _secondCard.cardIndex)
            {
            print("Индексы ");// написать в событиии счет очков и удаление одинаковых карточек
            print(_firstCard.cardIndex);
            print(_secondCard.cardIndex);
            StartCoroutine(DestroyCards());
            print("Одинаковые карточки нашлись!!!");
        }
        else
        {
            _firstCard.DisableBoxCollider2d();
            _secondCard.DisableBoxCollider2d();
            StartCoroutine(Fade());
        }
        }
    }
    {
        if 
    }
 }*/
}