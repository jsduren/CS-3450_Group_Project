using UnityEngine;
using System.Collections;

public class PlayerAttributes : MonoBehaviour {
	public int maxHealth;
	private int currentHealth;
	public int maxGuns;
	private int currentGuns;
	public float maxEnergy;
	private float currentEnergy;
	public int maxCargoSpace;
	private int currentCargoSpace;
	public GameObject currentCargo;
	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		currentGuns = maxGuns;
		currentEnergy = maxEnergy;
		currentCargoSpace = maxCargoSpace;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeDamage(int amount){
	
	}

	public void UseGuns(int amount){
	
	}

	public void UseEnergy(int amount){
	
	}

	public void Cargo(GameObject cargo){
	
	}
}
