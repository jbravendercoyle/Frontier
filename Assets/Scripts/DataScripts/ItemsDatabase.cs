using UnityEngine;
using System.Collections.Generic;

public class ItemClass : MonoBehaviour {

	public string name;
	public string description;
	public int id;
	private GameObject ItemPrefab;

	public ItemClass(string name,string description,int id)
	{

		this.name = name;
		this.description = description;
		this.id = id;

	}
} 



//public class ItemsDatabase : MonoBehaviour {

//	public Dictionary <string, ItemClass> dictionary = new Dictionary<string, ItemClass>();

//	public ItemClass Sword = new ItemClass("Sword","A Basic Sword","0");

//	public void Start()
	//{
//		dictionary.Add(Sword.name, Sword);
//	}

//}