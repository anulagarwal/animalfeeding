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
   
    [SerializeField] public EnumsManager.AnimalType animalType;
    [SerializeField] public List<EnumsManager.FoodType> preferredFood;
    [SerializeField] public int currentFoodInput;
    [SerializeField] public int maxFoodInput;
    public bool isHungry = true;   
    [SerializeField] private float scaleIncrease = 0.08f;
    public bool isInField;

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
    [SerializeField] public Transform pos;



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

        if (collision.gameObject.tag == "Position")
        {
            isHungry = true;
            isInField = true;
            this.enabled = true;
            animator.SetBool("isWalking", false);
            currentPatience = maxPatience;
            Destroy(collision.gameObject);
            agent.isStopped = true;
        }
    }

   

    private void OnDisable()
    {
       // GetComponentInChildren<Canvas>().gameObject.SetActive(false);
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
            isInField = false;  
        }

        IncreasePatience(foodPatienceIncrease);
        ScaleIncrease();
    }
    public void DisableTick()
    {
        tick.gameObject.SetActive(false);
    }
    public void WalkToField(Vector3 pos, EnumsManager.AnimalType type)
    {
        Walk(pos, type);
        isInField = true;
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
            case EnumsManager.AnimalType.Giraffe:
                animator.SetBool("isWalking", true);
                break;
            case EnumsManager.AnimalType.Dog:
                animator.SetBool("isWalking", true);
                break;
            case EnumsManager.AnimalType.Gorilla:
                animator.SetBool("isWalking", true);
                break;
        }
        agent.isStopped = false;
        agent.SetDestination(pos);
    }

    public void IncreasePatience(float val)
    {
        currentPatience += val;
        UpdateHungerBar();
    }

    private void UpdateHungerBar()
    {
        var f = currentPatience / maxPatience;
        patienceBar.fillAmount = f;

        var s = GameplaySettings.Instance;
        if (f > .66f)
        {
            patienceBar.color = s.green;
        }
        else if (f > .33f)
        {
            patienceBar.color = s.yellow;
        }
        else
        {
            patienceBar.color = s.red;
        }
    }
    
    public void ReducePatience(float val)
    {
        currentPatience -= val;
        UpdateHungerBar();
        
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
