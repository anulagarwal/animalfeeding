using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnimalManager : MonoBehaviour
{
    public static AnimalManager Instance = null;

    #region Attributes
    [Header("Attributes")]
    [SerializeField] public List<Animal> animals;
    [SerializeField] public List<Animal> lateAnimals;

    [SerializeField] float maxProgressValue;
    [SerializeField] float currentProgressValue;
    public bool isTrajectoryOn;


    [Header("Component References")]
    [SerializeField] Image progressBar;


    public int animalsFed;
    bool isLevelOn;
    #endregion


    #region Monobehaviour Functions
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        DisableAnimals();
        UpdateProgressBar(0);
        foreach(Animal a in animals)
        {
            maxProgressValue += a.maxFoodInput;
        }
      
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    #endregion

    #region Core Functions

 
    public void UpdateProgressBar(float value)
    {
        currentProgressValue += value;
        progressBar.fillAmount = currentProgressValue / maxProgressValue;
    }
    public void UpdateAnimalHunger()
    {
        if (animalsFed < lateAnimals.Count)
        {
            lateAnimals[animalsFed].WalkToField(lateAnimals[animalsFed].pos.position, lateAnimals[animalsFed].animalType);
        }
        animalsFed++;
        
        if(animalsFed == animals.Count)
        {
            GameManager.Instance.WinLevel();
        }
    }
    

    public void EnableAnimals()
    {
        foreach (Animal a in animals)
        {
            a.enabled = true;
            a.isHungry = true;
            a.isInField = true;
        }
        foreach(Animal a in lateAnimals)
        {
            a.isHungry = false;
            a.isInField = false;
        }
    }

    public void DisableAnimals()
    {
        foreach(Animal a in animals)
        {
            a.enabled = false;
        }
    }

    #endregion

}
