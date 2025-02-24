using System;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class testingandlearning : MonoBehaviour
{
    public int objectHealth;
    public TextMesh healthText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //Start, starts when the script or objct is called. like if i wanted to show a message once the script is called
    //i would put it here
    void Start()
    {
        healthText = GetComponentInChildren<TextMesh>();
    }

    // Update is called once per frame. aka, is repeatly called every frame while the game is running. 
    void Update()
    {
        //health is reduced when the Spacebar is hit. 
       if (Input.GetKeyDown(KeyCode.Space))
       {
        TakeDamage(5); //object would suffer 5 damage when the Spacebar is hit.
       }
        //any game logic the game would have, would go here!    
    }

    public void TakeDamage(int damage)
    {
        objectHealth -= damage; // reduce the health of the object.
        if  (objectHealth <= 0)
        {
            Destroy(gameObject); //the object is destroyed when health hit 0
        }
        UpdateHealthDisplay();// updates the text which shows the object's health.
    }

    void UpdateHealthDisplay()
    {
        if (healthText != null) 
        {
            healthText.text = "HP: " + objectHealth; //updates the text above the object. aka updates the health bar that's hovering above the object.
        }
    }
//is called before void Start() and is only called once. mainly used for setting up variables,
//refrences or anything that needs to be ready before the game starts. 
//void Awake() is still called first even if you call it after void Start. 
/// </summary>
    void Awake()
    {
        objectHealth = 25; 
        UpdateHealthDisplay();
        //Example^
        //sets the object up so that it'll start with 25 health and will be destroyed once health reaches 0
    }

    void FixedUpdate() //Best used for physics. like having an object fall and bounce for a short while like an actual ball.
    //unlike using void Update(), it'll stay consistant when it comes to any physics simunations and wouldn't be slowed down by the client's Fps. 
    //overall: best used for things that shouldn't depend on frame rate. like physics.
    {
        
    }
}
