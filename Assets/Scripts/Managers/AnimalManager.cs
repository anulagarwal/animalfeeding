using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnimalManager : MonoBehaviour
{
    public static AnimalManager Instance = null;

    #region Attributes
    [Header("Attributes")]
    [SerializeField] List<Animal> animals;
    [SerializeField] float maxProgressValue;
    [SerializeField] float currentProgressValue;


    [Header("Component References")]
    [SerializeField] Image progressBar;
    [SerializeField] GameObject dot;


    int animalsFed;
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
        UpdateAnimalDots();
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
        animalsFed++;
        if(animalsFed == animals.Count)
        {
            GameManager.Instance.WinLevel();
        }
    }

    public void UpdateAnimalDots()
    {
        foreach(Animal a in animals)
        {

            maxProgressValue += a.maxFoodInput;
            for (int i = 0; i < a.maxFoodInput; i++)
            {
                GameObject g = Instantiate(dot, Vector3.zero, Quaternion.identity);
                g.transform.SetParent(a.GetComponentInChildren<Canvas>().GetComponentInChildren<HorizontalLayoutGroup>().transform);
                g.transform.localPosition = Vector3.zero;
            }
        }

    }

    public void EnableAnimals()
    {
        foreach (Animal a in animals)
        {
            a.enabled = true;
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
