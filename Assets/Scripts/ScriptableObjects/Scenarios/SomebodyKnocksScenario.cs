﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scenario/SomebodyKnocksScenario")]
public class SomebodyKnocksScenario : Scenario {

	public override IEnumerator ExecuteScenario()
	{
		GameManager.Instance.interfaceHandler.storyPanel.SetActive(true);
		GameManager.Instance.scenarioManager.scenarioTextTyper.Type(
			"Es klopft an die Tür."
		);
		GameManager.Instance.CountDownValue = 10;
		yield return new WaitForSeconds(10);
        
		GameManager.Instance.scenarioManager.scenarioTextTyper.Type(
			"Es ist ein Vater mit seiner Tochter. Sie fragen, ob sie reingelassen werden können."
		);
		GameManager.Instance.CountDownValue = 10;
		yield return new WaitForSeconds(10);
        
		GameManager.Instance.scenarioManager.scenarioTextTyper.Type(
			GameManager.Instance.characterHandler.activeCharacters[Random.Range(0,GameManager.Instance.characterHandler.activeCharacters.Count)].characterName + " ist dafür."
		);
		
		GameManager.Instance.CountDownValue = 10;
		yield return new WaitForSeconds(10);
		GameManager.Instance.interfaceHandler.storyPanel.SetActive(false);

		yield return GameManager.Instance.CoroutineCaller(GameManager.Instance.pollHandler.DoPoll(scenarioEvents[0]));
		yield return GameManager.Instance.CoroutineCaller(GameManager.Instance.AfterQuestion());
		
		GameManager.Instance.interfaceHandler.storyPanel.SetActive(true);
		GameManager.Instance.scenarioManager.scenarioTextTyper.Type(
			"Check."
		);
		GameManager.Instance.CountDownValue = 10;
		yield return new WaitForSeconds(10);
		GameManager.Instance.interfaceHandler.storyPanel.SetActive(false);
	}
}