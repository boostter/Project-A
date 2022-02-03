using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour {

    public bool isQuestionActive = false;
    public UnityEvent questionEvent;
    public UnityEvent ClearQuestionEvent;
    public UnityEvent QuizClear;
    public UnityEvent QuizTrue;
    public UnityEvent QuizFalse;
    PlayerMover playerMover;
    public GameObject QuestionNode;
    public GameObject ReactiveNode;
    


    public Node n;

    void Start()
    {
        n = GameObject.FindGameObjectWithTag("reactiveNode").GetComponent<Node>();
        
    }
    private void Update() {
        if (QuestionNode == null){

            QuestionNode = GameObject.FindGameObjectWithTag("question");
            Debug.Log("finding question complete");
        }
        if (ReactiveNode == null)
        {
            ReactiveNode = GameObject.FindGameObjectWithTag("reactiveNode");
            Debug.Log("finding reactiveNode complete");
        }

        
        

        if(isQuestionActive != true){
            IsPlayerInQuestionNode();
        }
        
        
    }

	public void AnswerTrue(){

        

        Destroy(GameObject.FindWithTag("obstacle"));
        Destroy(GameObject.FindWithTag("questionText"));

        n.LinkedNodes.Clear();
        n.m_isInitialized = false;
        n.InitNode();
        StartCoroutine(omeneto());
        
	}
    public void AnswerFalse()
    {

        StartCoroutine(waiwai());
        
    }

    IEnumerator waiwai(){
        QuizFalse.Invoke();
        yield return new WaitForSeconds(2);
        QuizClear.Invoke();
    }
    IEnumerator omeneto()
    {
        QuizTrue.Invoke();
        yield return new WaitForSeconds(2);
        ClearQuestionEvent.Invoke();
    }
    public void IsPlayerInQuestionNode()
    {

        if (AreNear(QuestionNode.transform.position, gameObject.transform.position, 0.1f))
        {
            Debug.Log("QuestionNode ACtive");
            isQuestionActive = true;
            questionEvent.Invoke();
        }
        else
        {
            
        }
    }

    //This method detects if the object are close depending on minDistance value
    bool AreNear(Vector3 obj1, Vector3 obj2, float minDistance = 0)
    {
        return ((obj1.x < obj2.x + minDistance && obj1.x > obj2.x - minDistance) &&
            (obj1.y < obj2.y + minDistance && obj1.y > obj2.y - minDistance) &&
           (obj1.z < obj2.z + minDistance && obj1.z > obj2.z - minDistance));
    }

}
