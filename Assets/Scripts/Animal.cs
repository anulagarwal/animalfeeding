using System;
using System.Collections;
using System.Collections.Generic;
using D2D.Gameplay;
using D2D.Utilities;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;



public class Animal : MonoBehaviour
{
    #region Attributes
    [Header("Attributes")]
   
    [SerializeField] private EnumsManager.AnimalType animalType;
    [SerializeField] public List<EnumsManager.FoodType> preferredFood;
    [SerializeField] public int currentFoodInput;
    [SerializeField] public int maxFoodInput;
    public bool isHungry = true;   
    [SerializeField] private float scaleIncrease = 0.08f;

    [Header("Patience Bar Attributes")]
    [SerializeField] public float maxPatience;
    [SerializeField] public float currentPatience;
    [SerializeField] public float foodPatienceIncrease;
    [SerializeField] private float patienceReduceRate;

    [Header("Component Reference")]
    [SerializeField] Image patienceBar;
    [SerializeField] Animator animator;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Image tick;


    #endregion

    #region Core Functions
    // Start is called before the first frame update
    void Start()
    {
        currentPatience = maxPatience * GameplaySettings.Instance.patienceOnStart.RandomFloat();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHungry)
        {
            ReducePatience(patienceReduceRate);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Food")
        {

            bool isMatch = false;
            foreach(EnumsManager.FoodType t in preferredFood)
            {
                if (collision.gameObject.GetComponent<Food>().type == t)
                {
                    Eat();
                    UIManager.Instance.SpawnAwesomeText("Great!", collision.contacts[0].point);
                    isMatch = true;
                    Destroy(collision.gameObject);

                    break;
                }
                else
                {
                    isMatch = false;
                }
                
            }
            if (!isMatch)
            {
                Destroy(collision.gameObject, 1f);
            }
        }
    }

    private void OnDisable()
    {
        
    }
    #endregion


    #region Public Functions

    public void Eat()
    {
        AnimalManager.Instance.UpdateProgressBar(1);        
        currentFoodInput++;
        tick.gameObject.SetActive(true);
        tick.GetComponent<DOTweenAnimation>().DORestart();
        Invoke("DisableTick", 1f);
        if (currentFoodInput== maxFoodInput)
        {
            Walk(GameManager.Instance.escapePos.position, animalType);
            AnimalManager.Instance.UpdateAnimalHunger();
            GetComponentInChildren<Canvas>().gameObject.SetActive(false);
            isHungry = false;
           
        }

        IncreasePatience(foodPatienceIncrease);
        ScaleIncrease();
    }
    public void DisableTick()
    {
        tick.gameObject.SetActive(false);
    }

    public void Walk(Vector3 pos, EnumsManager.AnimalType type)
    {
        switch (type)
        {
            case EnumsManager.AnimalType.Cat:
                animator.SetBool("isWalking", true);
                break;
            case EnumsManager.AnimalType.Bear:
                animator.SetBool("isWalking", true);
                break;
        }
        agent.SetDestination(pos);
    }

    public void IncreasePatience(float val)
    {
        currentPatience += val;
        patienceBar.fillAmount = currentPatience / maxPatience;
    }
    public void ReducePatience(float val)
    {
        currentPatience -= val;
        patienceBar.fillAmount = currentPatience / maxPatience;
        currentPatience = Mathf.Max(0, currentPatience);
        currentPatience = Mathf.Min(maxPatience, currentPatience);

        if (currentPatience <= 0)
        {
            //Game Over
            GameManager.Instance.LoseLevel();

        }
        else if (currentPatience >= maxPatience)
        {
          
        }
        //If below certain level add more vfx to show hunger
    }

    public void ScaleIncrease()
    {
        transform.localScale = new Vector3(transform.localScale.x + scaleIncrease, transform.localScale.y + scaleIncrease, transform.localScale.z + scaleIncrease);
    }
    #endregion

}
