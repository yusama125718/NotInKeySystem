
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
public class NotInKeySystem : UdonSharpBehaviour
{
    [Header("ロック時に表示されるオブジェクト")]
    [SerializeField] private GameObject[] lockobject;

    [Header("アンロック時に表示するオブジェクト")]
    [SerializeField] private GameObject[] unlockobject;  

    [UdonSynced]private bool active;

    void start(){
        active = false;
    }

    void OnPlayerJoin(VRCPlayerApi player){
        RequestSerialization();
        NISchange();
    }

    void Interact(){
        if (!Networking.IsOwner(gameObject)) return;
        active = !active;
        RequestSerialization();
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "NISchange");
    }

    public void NISchange(){
        for (int i = 0;i < lockobject.Length;i++){
            if (lockobject[i] != null) lockobject[i].SetActive(active);
        }

        for (int i = 0;i < unlockobject.Length;i++){
            if (unlockobject[i] != null) unlockobject[i].SetActive(!active);
        }
    }
}