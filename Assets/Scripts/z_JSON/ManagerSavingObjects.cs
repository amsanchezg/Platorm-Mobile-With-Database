using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSavingObjects : MonoBehaviour {

    [SerializeField] private CharacterController curPlayer;
    

    private void Start() {
        Load();
    }

    public void Save() {
        JsonManager.SaveGame(curPlayer) ;
    }

    public void Load() {
        JsonManager.LoadGame(curPlayer);
    }

}
