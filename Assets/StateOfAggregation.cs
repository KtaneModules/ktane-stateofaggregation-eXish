using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class StateOfAggregation : MonoBehaviour {

	private void Start()
	{
		_moduleID = _moduleIdCounter++;
		Element.text = string.Empty;
		Group.text = string.Empty;
		Temp.text = string.Empty;
		KMBombModule module = Module;
		module.OnActivate = (KMBombModule.KMModuleActivateEvent)Delegate.Combine(module.OnActivate, new KMBombModule.KMModuleActivateEvent(Activate));
	}

	private void Awake()
	{
		KMSelectable kmselectable = submit;
		kmselectable.OnInteract = (KMSelectable.OnInteractHandler)Delegate.Combine(kmselectable.OnInteract, new KMSelectable.OnInteractHandler(delegate ()
		{
			AnswerCheck();
			return false;
		}));
		int i;
		for (i = 0; i < 4; i++)
		{
			KMSelectable kmselectable2 = btn[i];
			kmselectable2.OnInteract = (KMSelectable.OnInteractHandler)Delegate.Combine(kmselectable2.OnInteract, new KMSelectable.OnInteractHandler(delegate ()
			{
				HandlePress(i);
				return false;
			}));
		}
		for (int j = 0; j < 4; j++)
		{
			KMSelectable kmselectable3 = btn[j];
			kmselectable3.OnInteract = (KMSelectable.OnInteractHandler)Delegate.Combine(kmselectable3.OnInteract, HandlePress(j));
		}
	}

	private void Activate()
	{
		Init();
		_lightsOn = true;
	}

	private void LoadElements()
	{
		temps = new string[][]
		{
			//0
			new string[]
			{
				"-273",
				"-272.9",
				"-272.5",
				"-272.3"
			},
			//1
			new string[]
			{
				"-272.1",
				"-270",
				"-269.9",
				"-269"
			},
			//2
			new string[]
			{
				"-259.9",
				"-255",
				"-253.9",
				"-257.4"
			},
			//3
			new string[]
			{
				"-252.8",
				"-250",
				"-249.9",
				"-248.9"
			},
			//4
			new string[]
			{
				"-248.1",
				"-247.3",
				"-247.2",
				"-247.1"
			},
			//5
			new string[]
			{
				"-204.8",
				"-200",
				"-202.2",
				"-199.9"
			},
			//6
			new string[]
			{
				"-182.3",
				"-177.8",
				"-153",
				"-101"
			},
			//7
			new string[]
			{
				"-96",
				"-89.9",
				"-69",
				"-40"
			},
			//8
			new string[]
			{
				"4",
				"13",
				"30",
				"42"
			},
			//9
			new string[]
			{
				"53.6",
				"69",
				"96",
				"122.9"
			},
			//10
			new string[]
			{
				"187.1",
				"230",
				"419.9",
				"442.9"
			},
			//11
			new string[]
			{
				"503",
				"590.1",
				"613",
				"642"
			},
			//12
			new string[]
			{
				"706",
				"720.3",
				"966",
				"969"
			},
			//13
			new string[]
			{
				"1001",
				"1012.1",
				"1202.1",
				"1310"
			},
			//14
			new string[]
			{
				"1450",
				"1578.6",
				"1949.2",
				"1999.9"
			},
			//15
			new string[]
			{
				"2305.6",
				"2370",
				"2424.2",
				"2444.2"
			},
			//16
			new string[]
			{
				"2670",
				"3010.9",
				"3198.9",
				"3530"
			},
			//17
			new string[]
			{
				"3600",
				"3800.9",
				"3997.1",
				"4021.1"
			},
			//18
			new string[]
			{
				"4850",
				"4910.9",
				"5347.6",
				"5926.9"
			},
			//19
			new string[]
			{
				"5936.9",
				"5997.9",
				"6996.9",
				"7464"
			},
			//20
			new string[]
			{
				"-189.3",
				"-189",
				"-186.1",
				"-186"
			},
			//21
			new string[]
			{
				"-156.5",
				"-155.9",
				"-153",
				"-152.9"
			},
			//22
			new string[]
			{
				"114",
				"123.4",
				"151",
				"182"
			},
			//23
			new string[]
			{
				"-111.3",
				"-110.9",
				"-109",
				"-107.5"
			},
			//24
			new string[]
			{
				"1550",
				"1566.9",
				"1602.1",
				"1724"
			},
			new string[]
			{
				"-"
			}
		};
		elements = new string[][]
		{
			new string[]
			{
				"H",
				"7",
				"1",
				"2",
				"3"
			},
			new string[]
			{
				"He",
				"8",
				"0",
				"1",
				"2"
			},
			new string[]
			{
				"Li",
				"0",
				"9",
				"11",
				"14"
			},
			new string[]
			{
				"Be",
				"1",
				"12",
				"14",
				"17"
			},
			new string[]
			{
				"B",
				"6",
				"14",
				"15",
				"17"
			},
			new string[]
			{
				"C",
				"7",
				"16",
				"17",
				"18"
			},
			new string[]
			{
				"N",
				"7",
				"4",
				"5",
				"6"
			},
			new string[]
			{
				"O",
				"7",
				"4",
				"5",
				"6"
			},
			new string[]
			{
				"F",
				"7",
				"4",
				"5",
				"6"
			},
			new string[]
			{
				"Ne",
				"8",
				"3",
				"4",
				"5"
			},
			new string[]
			{
				"Na",
				"0",
				"8",
				"11",
				"13"
			},
			new string[]
			{
				"Mg",
				"1",
				"11",
				"12",
				"14"
			},
			new string[]
			{
				"Al",
				"5",
				"11",
				"12",
				"16"
			},
			new string[]
			{
				"Si",
				"6",
				"13",
				"14",
				"16"
			},
			new string[]
			{
				"P",
				"7",
				"8",
				"9",
				"11"
			},
			new string[]
			{
				"S",
				"7",
				"8",
				"10",
				"11"
			},
			new string[]
			{
				"Cl",
				"7",
				"6",
				"7",
				"8"
			},
			new string[]
			{
				"Ar",
				"8",
				"5",
				"20",
				"6"
			},
			new string[]
			{
				"K",
				"0",
				"8",
				"10",
				"13"
			},
			new string[]
			{
				"Ca",
				"1",
				"11",
				"13",
				"15"
			},
			new string[]
			{
				"Sc",
				"2",
				"13",
				"15",
				"17"
			},
			new string[]
			{
				"Ti",
				"2",
				"13",
				"15",
				"17"
			},
			new string[]
			{
				"V",
				"2",
				"13",
				"15",
				"17"
			},
			new string[]
			{
				"Cr",
				"2",
				"13",
				"15",
				"16"
			},
			new string[]
			{
				"Mn",
				"2",
				"12",
				"14",
				"15"
			},
			new string[]
			{
				"Fe",
				"2",
				"13",
				"14",
				"16"
			},
			new string[]
			{
				"Co",
				"2",
				"13",
				"14",
				"16"
			},
			new string[]
			{
				"Ni",
				"2",
				"13",
				"14",
				"16"
			},
			new string[]
			{
				"Cu",
				"2",
				"12",
				"15",
				"16"
			},
			new string[]
			{
				"Zn",
				"2",
				"10",
				"11",
				"13"
			},
			new string[]
			{
				"Ga",
				"5",
				"8",
				"13",
				"16"
			},
			new string[]
			{
				"Ge",
				"6",
				"11",
				"14",
				"17"
			},
			new string[]
			{
				"Se",
				"7",
				"9",
				"11",
				"12"
			},
			new string[]
			{
				"Br",
				"7",
				"7",
				"8",
				"9"
			},
			new string[]
			{
				"Kr",
				"8",
				"5",
				"21",
				"7"
			},
			new string[]
			{
				"Rb",
				"0",
				"7",
				"10",
				"12"
			},
			new string[]
			{
				"Sr",
				"1",
				"11",
				"13",
				"14"
			},
			new string[]
			{
				"Y",
				"2",
				"13",
				"15",
				"17"
			},
			new string[]
			{
				"Zr",
				"2",
				"13",
				"15",
				"18"
			},
			new string[]
			{
				"Nb",
				"2",
				"15",
				"17",
				"19"
			},
			new string[]
			{
				"Mo",
				"2",
				"15",
				"17",
				"19"
			},
			new string[]
			{
				"Tc",
				"2",
				"14",
				"16",
				"19"
			},
			new string[]
			{
				"Ru",
				"2",
				"14",
				"16",
				"18"
			},
			new string[]
			{
				"Rh",
				"2",
				"13",
				"15",
				"18"
			},
			new string[]
			{
				"Pd",
				"2",
				"13",
				"15",
				"17"
			},
			new string[]
			{
				"Ag",
				"2",
				"11",
				"13",
				"15"
			},
			new string[]
			{
				"Cd",
				"2",
				"9",
				"11",
				"13"
			},
			new string[]
			{
				"In",
				"5",
				"9",
				"13",
				"15"
			},
			new string[]
			{
				"Sn",
				"5",
				"9",
				"13",
				"15"
			},
			new string[]
			{
				"Sb",
				"5",
				"10",
				"13",
				"15"
			},
			new string[]
			{
				"Te",
				"6",
				"10",
				"11",
				"12"
			},
			new string[]
			{
				"I",
				"7",
				"8",
				"22",
				"10"
			},
			new string[]
			{
				"Xe",
				"8",
				"5",
				"23",
				"7"
			},
			new string[]
			{
				"Cs",
				"0",
				"7",
				"10",
				"12"
			},
			new string[]
			{
				"Ba",
				"1",
				"11",
				"13",
				"15"
			},
			new string[]
			{
				"La",
				"3",
				"11",
				"14",
				"17"
			},
			new string[]
			{
				"Ce",
				"3",
				"11",
				"14",
				"17"
			},
			new string[]
			{
				"Pr",
				"3",
				"11",
				"14",
				"17"
			},
			new string[]
			{
				"Nd",
				"3",
				"12",
				"14",
				"17"
			},
			new string[]
			{
				"Pm",
				"3",
				"12",
				"14",
				"17"
			},
			new string[]
			{
				"Sm",
				"3",
				"12",
				"14",
				"15"
			},
			new string[]
			{
				"Eu",
				"3",
				"11",
				"13",
				"15"
			},
			new string[]
			{
				"Gd",
				"3",
				"13",
				"14",
				"17"
			},
			new string[]
			{
				"Tb",
				"3",
				"13",
				"14",
				"17"
			},
			new string[]
			{
				"Dy",
				"3",
				"13",
				"14",
				"16"
			},
			new string[]
			{
				"Ho",
				"3",
				"13",
				"15",
				"17"
			},
			new string[]
			{
				"Er",
				"3",
				"13",
				"14",
				"16"
			},
			new string[]
			{
				"Tm",
				"3",
				"13",
				"24",
				"15"
			},
			new string[]
			{
				"Lu",
				"3",
				"13",
				"14",
				"17"
			},
			new string[]
			{
				"Hf",
				"2",
				"14",
				"16",
				"19"
			},
			new string[]
			{
				"Ta",
				"2",
				"15",
				"17",
				"19"
			},
			new string[]
			{
				"W",
				"2",
				"15",
				"17",
				"19"
			},
			new string[]
			{
				"Re",
				"2",
				"15",
				"17",
				"19"
			},
			new string[]
			{
				"Os",
				"2",
				"15",
				"17",
				"19"
			},
			new string[]
			{
				"Ir",
				"2",
				"14",
				"16",
				"18"
			},
			new string[]
			{
				"Pt",
				"2",
				"13",
				"15",
				"18"
			},
			new string[]
			{
				"Au",
				"2",
				"12",
				"14",
				"17"
			},
			new string[]
			{
				"Hg",
				"2",
				"7",
				"9",
				"11"
			},
			new string[]
			{
				"Ti",
				"5",
				"9",
				"12",
				"15"
			},
			new string[]
			{
				"Pb",
				"5",
				"9",
				"12",
				"15"
			},
			new string[]
			{
				"Bi",
				"5",
				"9",
				"12",
				"15"
			},
			new string[]
			{
				"Po",
				"6",
				"9",
				"11",
				"13"
			},
			new string[]
			{
				"Fr",
				"0",
				"7",
				"10",
				"13"
			},
			new string[]
			{
				"Ra",
				"1",
				"11",
				"12",
				"14"
			},
			new string[]
			{
				"Ac",
				"4",
				"12",
				"14",
				"17"
			},
			new string[]
			{
				"Th",
				"4",
				"13",
				"15",
				"18"
			},
			new string[]
			{
				"Pa",
				"4",
				"13",
				"14",
				"18"
			},
			new string[]
			{
				"U",
				"4",
				"12",
				"16",
				"18"
			},
			new string[]
			{
				"Np",
				"4",
				"10",
				"15",
				"18"
			},
			new string[]
			{
				"Pu",
				"4",
				"10",
				"15",
				"17"
			},
			new string[]
			{
				"Am",
				"4",
				"12",
				"13",
				"16"
			},
			new string[]
			{
				"Cm",
				"4",
				"13",
				"14",
				"17"
			}
		};
		Debug.LogFormat("[State of Aggregation #{0}] Loaded {1} amounts of possible displayed elements.", new object[]
		{
			_moduleID,
			elements.Length
		});
	}

	private void Init()
	{
		settings = LoadSettings();
		if (settings.lang == "ger")
		{
			groups = groupsGer;
		}
		Debug.LogFormat("[State of Aggregation #{0}] Selected language: {1}", new object[]
		{
			_moduleID,
			settings.lang
		});
		if (settings.convertTemp == null)
		{
			settings.convertTemp = new bool?(settings.EnableConversionTemp());
			try
			{
				File.WriteAllText(modSettings.SettingsPath, JsonConvert.SerializeObject(settings, Formatting.Indented));
			}
			catch
			{
			}
		}
		Debug.LogFormat("[State of Aggregation #{0}] Convert temperatures: {1}", new object[]
		{
			_moduleID,
			settings.EnableConversionTemp()
		});
		LoadElements();
		int num = UnityEngine.Random.Range(1, elements.Length);
		stageColor = UnityEngine.Random.Range(0, 3);
		groupCounter = UnityEngine.Random.Range(0, 10);
		stageElem = elements[num];
		Debug.LogFormat("[State of Aggregation #{0}] Selected element: {1}", new object[]
		{
			_moduleID,
			stageElem[0]
		});
		CreateStage();
	}

	private void CreateStage()
	{
		Element.text = stageElem[0];
		switch (stageColor)
		{
			case 0:
				Element.color = solid;
				Debug.LogFormat("[State of Aggregation #{0}] Selected element status: {1}", new object[]
				{
				_moduleID,
				"solid"
				});
				FillTemps(0);
				break;
			case 1:
				Element.color = liquid;
				Debug.LogFormat("[State of Aggregation #{0}] Selected element status: {1}", new object[]
				{
				_moduleID,
				"liquid"
				});
				FillTemps(1);
				break;
			case 2:
				Element.color = gas;
				Debug.LogFormat("[State of Aggregation #{0}] Selected element status: {1}", new object[]
				{
				_moduleID,
				"gas"
				});
				FillTemps(2);
				break;
			default:
				Element.color = error;
				Debug.LogFormat("[State of Aggregation #{0}] Something with the color went wrong ... Color: {1}", new object[]
				{
				_moduleID,
				stageColor
				});
				break;
		}
		if (groupCounter >= 0 && groupCounter <= 9)
		{
			Group.text = groups[groupCounter];
		}
		else
		{
			Debug.LogFormat("[State of Aggregation #{0}] Something with the groupCounter went wrong: {1}", new object[]
			{
				_moduleID,
				groupCounter
			});
		}
	}

	private void FillTemps(int status)
	{
		int num = UnityEngine.Random.Range(0, 4);
		int num2;
		if (!int.TryParse(stageElem[status + 2], out num2))
		{
			Debug.LogFormat("[State of Aggregation #{0}] Something with stageElementTemp went wrong while trying to parse it to an Int: {1}", new object[]
			{
				_moduleID,
				stageElem[status + 2]
			});
		}
		int num3;
		if (!int.TryParse(stageElem[2], out num3))
		{
			Debug.LogFormat("[State of Aggregation #{0}] Something with solidTempScale went wrong while trying to parse it to an Int: {1}", new object[]
			{
				_moduleID,
				stageElem[2]
			});
		}
		int num4;
		if (!int.TryParse(stageElem[3], out num4))
		{
			Debug.LogFormat("[State of Aggregation #{0}] Something with liquidTempScale went wrong while trying to parse it to an Int: {1}", new object[]
			{
				_moduleID,
				stageElem[3]
			});
		}
		int num5;
		if (!int.TryParse(stageElem[4], out num5))
		{
			Debug.LogFormat("[State of Aggregation #{0}] Something with gasTempScale went wrong while trying to parse it to an Int: {1}", new object[]
			{
				_moduleID,
				stageElem[4]
			});
		}
		if (int.TryParse(stageElem[1], out correctGroup))
		{
			Debug.LogFormat("[State of Aggregation #{0}] Correct group of the element is: {1}", new object[]
			{
				_moduleID,
				groups[correctGroup]
			});
		}
		else
		{
			Debug.LogFormat("[State of Aggregation #{0}] Something with correctGroup went wrong while trying to parse it to an Int: {1}", new object[]
			{
				_moduleID,
				stageElem[1]
			});
		}
		if (status != 0)
		{
			if (status != 1)
			{
				if (status == 2)
				{
					displayedTemps = TemperatureConverter(BuildTemp(temps[num2][num], temps[num3], temps[num4]));
					Temp.text = displayedTemps[0];
				}
			}
			else
			{
				displayedTemps = TemperatureConverter(BuildTemp(temps[num2][num], temps[num3], temps[num5]));
				Temp.text = displayedTemps[0];
			}
		}
		else
		{
			displayedTemps = TemperatureConverter(BuildTemp(temps[num2][num], temps[num4], temps[num5]));
			Temp.text = displayedTemps[0];
		}
	}

	private string[] BuildTemp(string correct, string[] other1, string[] other2)
	{
		Debug.LogFormat("[State of Aggregation #{0}] Correct element temperature is: {1}°C", new object[]
		{
			_moduleID,
			correct
		});
		string[] array = new string[other1.Length + other2.Length + 1];
		for (int i = 0; i < other1.Length + other2.Length + 1; i++)
		{
			if (i < other1.Length)
			{
				array[i] = other1[i];
			}
			else if (i - other1.Length < other2.Length)
			{
				array[i] = other2[i - other1.Length];
			}
			else
			{
				array[i] = correct;
			}
		}
		array.Shuffle<string[]>();
		correctTempIndex = Array.IndexOf<string>(array, correct);
		Debug.LogFormat("[State of Aggregation #{0}] Correct temp is at index: {1}", new object[]
		{
			_moduleID,
			correctTempIndex
		});
		return array;
	}

	private string[] TemperatureConverter(string[] value)
	{
		string[] array = new string[value.Length];
		bool announce = true;
		for (int i = 0; i < value.Length; i++)
		{
			if (value[i] == "-")
			{
				array[i] = value[i];
			}
			else
			{
				double num;
				if (double.TryParse(value[i], out num))
				{
				}
				int num2;
				if (settings.EnableConversionTemp())
				{
					if (announce)
                    {
						announce = false;
						Debug.LogFormat("[State of Aggregation #{0}] Converting temperatures to Fahrenheit and Kelvin because of the settings in the modSettings file.", new object[]
						{
							_moduleID
						});
					}
					num2 = UnityEngine.Random.Range(0, 3);
				}
				else
				{
					if (announce)
					{
						announce = false;
						Debug.LogFormat("[State of Aggregation #{0}] Skipping conversion of temperatures because of the settings in the modSettings file.", new object[]
						{
							_moduleID
						});
					}
					num2 = 0;
				}
				switch (num2)
				{
					case 0:
						array[i] = num + "°C";
						break;
					case 1:
						array[i] = (num + 273.0).ToString() + "K";
						break;
					case 2:
						array[i] = (num * 9.0 / 5.0 + 32.0).ToString("0.00") + "°F";
						break;
					default:
						Debug.LogFormat("[State of Aggregation #{0}] Something with the temperature convert failed while randomizing it: {1}", new object[]
						{
						_moduleID,
						value[i]
						});
						break;
				}
			}
		}
		correctTemp = array[correctTempIndex];
		return array;
	}

	private bool CheckCorrectValues()
	{
		Debug.LogFormat("[State of Aggregation #{0}] Checking correct answers.", new object[]
		{
			_moduleID
		});
		Debug.LogFormat("[State of Aggregation #{0}] Selected values: {1}, {2}", new object[]
		{
			_moduleID,
			Group.text,
			Temp.text
		});
		if (Temp.text == correctTemp && Group.text == groups[correctGroup])
		{
			Debug.LogFormat("[State of Aggregation #{0}] Values are correct, module solved.", new object[]
			{
				_moduleID,
			});
			return true;
		}
        else
        {
			string wrong;
			if (Group.text != groups[correctGroup] && Temp.text != correctTemp)
				wrong = "group and temperature";
			else if (Group.text != groups[correctGroup] && Temp.text == correctTemp)
				wrong = "group";
			else
				wrong = "temperature";
			Debug.LogFormat("[State of Aggregation #{0}] Value{2} {1} {3} incorrect.", new object[]
			{
				_moduleID,
				wrong,
				wrong.Contains("and") ? "s" : "",
				wrong.Contains("and") ? "are" : "is"
			});
		}
		return false;
	}

	private void AnswerCheck()
	{
		if (_isSolved)
		{
			return;
		}
		Audio.PlayGameSoundAtTransform(0, submit.transform);
		submit.AddInteractionPunch(1f);
		if (CheckCorrectValues())
		{
			_isSolved = true;
			Element.text = string.Empty;
			Group.text = string.Empty;
			Temp.text = string.Empty;
			Module.HandlePass();
		}
		else
		{
			Module.HandleStrike();
		}
	}

	private KMSelectable.OnInteractHandler HandlePress(int i)
	{
		return delegate ()
		{
			Audio.PlayGameSoundAtTransform(0, btn[i].transform);
			btn[i].AddInteractionPunch(1f);
			if (_isSolved || !_lightsOn)
			{
				return false;
			}
			switch (i)
			{
				case 0:
					Group.text = string.Empty;
					groupCounter--;
					if (groupCounter < 0)
					{
						groupCounter = groups.Length - 1;
					}
					Group.text = groups[groupCounter];
					return false;
				case 1:
					Group.text = string.Empty;
					groupCounter++;
					if (groupCounter == groups.Length)
					{
						groupCounter = 0;
					}
					Group.text = groups[groupCounter];
					return false;
				case 2:
					Temp.text = string.Empty;
					tempCounter++;
					if (tempCounter == displayedTemps.Length)
					{
						tempCounter = 0;
					}
					Temp.text = displayedTemps[tempCounter];
					return false;
				case 3:
					Temp.text = string.Empty;
					tempCounter--;
					if (tempCounter < 0)
					{
						tempCounter = displayedTemps.Length - 1;
					}
					Temp.text = displayedTemps[tempCounter];
					return false;
				default:
					Debug.LogFormat("[State of Aggregation #{0}] Something with the buttons went wrong ... Button: {1}", new object[]
					{
					_moduleID,
					i
					});
					return false;
			}
		};
	}

	private ModSettingsJSON LoadSettings()
	{
		return JsonConvert.DeserializeObject<ModSettingsJSON>(modSettings.Settings);
	}

	public KMAudio Audio;

	public KMBombModule Module;

	public KMBombInfo Info;

	public KMModSettings modSettings;

	public KMSelectable[] btn;

	public KMSelectable submit;

	public TextMesh Element;

	public TextMesh Group;

	public TextMesh Temp;

	public string[][] elements;

	private ModSettingsJSON settings;

	private static int _moduleIdCounter = 1;

	private int _moduleID;

	private string[] groups = new string[]
	{
		"Alkali Metal",
		"Alkaline Earth Metal",
		"Transition Metal",
		"Lanthanide",
		"Actinide",
		"Metal",
		"Semimetal",
		"Nonmetal",
		"Noble Gas",
		"Unknown"
	};

	private string[] groupsGer = new string[]
	{
		"Alkalimetall",
		"Erdalkalimetall",
		"Übergangsmetall",
		"Lanthanoid",
		"Actinoid",
		"Metall",
		"Halbmetall",
		"Nichtmetall",
		"Edelgas",
		"Unbekannt"
	};

	private string[][] temps;

	private string[] displayedTemps;

	private string[] stageElem;

	private string correctTemp;

	private int correctTempIndex;

	private int correctGroup;

	private int stageColor;

	private Color solid = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

	private Color liquid = new Color32(0, 150, byte.MaxValue, byte.MaxValue);

	private Color gas = new Color32(230, 0, 0, byte.MaxValue);

	private Color error = new Color32(byte.MaxValue, 0, byte.MaxValue, byte.MaxValue);

	private int groupCounter;

	private int tempCounter;

	private bool _isSolved;

	private bool _lightsOn;

	private class ModSettingsJSON
	{
		public bool EnableConversionTemp()
		{
			bool? flag = convertTemp;
			return flag == null || flag.Value;
		}

		public string lang;

		public bool? convertTemp;
	}
}