using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DTaSchweppes.Tools
{
[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))] //Компоненты будут появляться на объекте на сцене сразу после добавления на него скрипта
 public class Card : MonoBehaviour
 {
    private Animation _animation;
    public int cardIndex;
    private CardsCollect _cardsCollect = null;
    [SerializeField]private Sprite[] _backSprites;
    [SerializeField]private Sprite _backSprite;
    [SerializeField]private Sprite _frontSprite;
    private BoxCollider2D _boxCollider2D;
    private bool _isBackSide = false; //состояние какой стороной повернута карточка
    private SpriteRenderer _spriteRenderer; //тут будет храниться компонент, для смены спрайтов

    private void Awake(){
        _animation = GetComponent<Animation>();//для взаимодействия с компонентом анимации на объекте на сцене
        _boxCollider2D = GetComponent<BoxCollider2D>();//взаим. с ним будет например чтоб отключить нажатие по карточке при анимации поворота
        _spriteRenderer = GetComponent<SpriteRenderer>();//смена спрайтов
        _cardsCollect = GameObject.Find("GameEngine").GetComponent<CardsCollect>();
        if (cardIndex == 2){
            SideAnimation();
            StartCoroutine(StartSlideTine());
        }
    }
    private void OnMouseDown(){
        _cardsCollect.OpenCard(this);
        _boxCollider2D.enabled = false; //отключаем чтоб во время поворота карточки не включали анимацию снова (не прерывали)
        SideAnimation();
    }

    public void EnableBoxCollider2d(){
        _boxCollider2D.enabled = true; // метод будет использоваться в событии анимации, когда уже перевернется карточка - включаем колайдер
    }
    public void DisableBoxCollider2d(){
        _boxCollider2D.enabled = false;
    }
    public void SideAnimation(){
        _animation.Play(_isBackSide == true ? "ToFront" : "ToBack");
    }

    public void ChangeCardSprite(){
        _spriteRenderer.sprite = _isBackSide == true ? _frontSprite : _backSprite;
        _isBackSide = _isBackSide == true ? false : true;
    }

    public void SettingsOfCard(int index){//т.к. мы будем не каждую карточку на сцене отдельно настраивать, а генерить скриптом, нам поэтому нужен метод настроек
        //index - это для логики сравнения карточек
        cardIndex = index;
        if (cardIndex==2)
        {
            _backSprite = _backSprites[0];
        } else
        {
            _backSprite = _backSprites[1];
        }
    }

    private IEnumerator StartSlideTine()//WAIT AND RUN ANIM arg float seconds 
    {
        yield return new WaitForSeconds(1.5f);
        SideAnimation();
    }

    public void StartCoroutineMoveOut(){
        StartCoroutine(CardMoveOutOfSceneTine());
    }

    private IEnumerator CardMoveOutOfSceneTine()
    {
        //dotween plugin
        while(Vector3.Distance(new Vector3(-7, gameObject.transform.position.y, gameObject.transform.position.z),gameObject.transform.position)> 0.1f){
                gameObject.transform.Translate(new Vector3(-7, 0, 0) * Time.deltaTime *2f);
                yield return null;//каждый кадр после выполнения действия
            }
        yield return new WaitForSeconds(1f);
        CardDestroy();
    }
    
    public void CardDestroy(){
        Destroy(gameObject);
    }

 }
}