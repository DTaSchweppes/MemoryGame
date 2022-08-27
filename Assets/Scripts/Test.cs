using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DTaSchweppes.Tools
{
 public class Test : MonoBehaviour
 {
	public GameObject transformObjectCube;

    public void Awake(){
        //StartCoroutine(Move());
    }
    /*public void Update(){
        transformObjectCube.transform.Translate(new Vector3(-4, 0, 0) * Time.deltaTime);
    }*/
    IEnumerator Move(){
        //print("STARTED COROUTINE");
        while(Vector3.Distance(new Vector3(-4, 0, 0),transformObjectCube.transform.position)> 0.1f){
        transformObjectCube.transform.Translate(new Vector3(-4, 0, 0) * Time.deltaTime);
        yield return null;//каждый кадр после выполнения действия
        }
    }
 }
}