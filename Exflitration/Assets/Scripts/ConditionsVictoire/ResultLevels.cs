using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultLevels : MonoBehaviour
{
	CharacterControl[] Perso;
	int n;
	int length;
	int cursor;
	List<bool> isDie;
	bool IsWon;
	public TextMeshProUGUI scorenumberText;
	public TextMeshProUGUI scoreStressText;
	public TextMeshProUGUI scoreTotalText;

	void Start()
	{
		Perso = FindObjectsOfType<CharacterControl>();
		isDie = Dead();
	}

	public void actualized()
	{
		isDie = Dead();
	}

	public int lon(CharacterControl[] a)
	{
		int res = 1;
		int cursor = 0;
		while(a[cursor])
		{
			cursor++;
			res++;
		}
		return res;
	}

	public List<int> Dehors()
	{
		length = lon(Perso);
		cursor = 0;
		List<int> res = new List<int>();
		while(cursor < length)
		{
			if(Perso[cursor].GetComponent<CharacterControl>().Won == true)
			{
				res.Add(1);
			}
			else
			{
				res.Add(0);
			}
		}
		return res;
	}

	public List<bool> Dead()
	{
		List<bool> res = new List<bool>();
		length = lon(Perso);
		cursor = 0;
		while(cursor < length)
		{
			res[cursor] = Perso[cursor].IsDead;
			cursor++;
		}
		return res;
	}
//StressLevel => charactercontrol -> par perso
	public bool score()
	{
		n = perso();
		length = lon(Perso);
		float g = 100 - (StressPerso() * 100);
		scoreStressText.text = "" + (char)g +"%"; 
		scorenumberText.text = "" + (char)n;
		float pers = (float)n * 100 / length; 
		float total = (n + g) / 2;
		scoreTotalText.text = "" + (char)total + "%";
		if(n >= 1)
		{
			IsWon = true;
		}
		else
		{
			IsWon = false;
		}
		return IsWon;
	}

	public float StressPerso()
	{
		float res = 0f;
		length = lon(Perso);
		cursor = 0;
		while(cursor < length)
		{
			res += Perso[cursor].StressLevel;
			cursor++;
		}
		return res;
	}

	public int perso()
	{
		int res = 0;
		length = isDie.Count;
		cursor = 0;
		List<int> a = Dehors();
		while(cursor < length)
		{
			if(isDie[cursor] == false && a[cursor] == 1)
			{
				res++;
			}
			cursor++;
		}
		return res;
	}
}