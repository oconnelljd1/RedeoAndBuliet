using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {

	private Dictionary <string, UnityEvent> eventDictionary;
	private static EventManager eventManager;
	public static EventManager instance{
		get{ 
			if(!eventManager){
				eventManager = FindObjectOfType (typeof(EventManager)) as EventManager;
				if (!eventManager) {
					Debug.LogError ("You forgot the EventManager Dummy");
				} else {
					eventManager.InitializeManager ();
				}
			}
			return eventManager;
		}
	}

	void InitializeManager(){
		if(eventDictionary == null){
			eventDictionary = new Dictionary<string, UnityEvent>();
		}
	}

	// Use this for initialization
	void Start () {
	}
	
	public static void StartListening(string _eventName, UnityAction _listener){
		UnityEvent thisEvent = null;
		if(instance.eventDictionary.TryGetValue(_eventName, out thisEvent)){
			thisEvent.AddListener (_listener);
		}else{
			thisEvent = new UnityEvent ();
			thisEvent.AddListener (_listener);
			instance.eventDictionary.Add (_eventName, thisEvent);
		}
	}

	public static void StopListening(string _eventName, UnityAction _listener){
		if (eventManager == null) {
			return;
		}else{
			UnityEvent thisEvent = null;
			if(instance.eventDictionary.TryGetValue(_eventName, out thisEvent)){
				thisEvent.RemoveListener (_listener);
			}
		}
	}

	public static void TriggerEvent(string _eventName){
		UnityEvent thisEvent = null;
		if(instance.eventDictionary.TryGetValue(_eventName, out thisEvent)){
			thisEvent.Invoke ();
		}
	}

}
