
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
public class NotInKeySystem_Collider : UdonSharpBehaviour
{
    [Header("ロック時に表示されるオブジェクト")]
    [SerializeField] private GameObject[] hideobject;

    [Header("アンロック時に表示するオブジェクト")]
    [SerializeField] private GameObject[] showobject;

    [UdonSynced]private int OPCstayplayer;

    void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if (!Networking.IsOwner(gameObject)) return;
        OPCstayplayer++;
        RequestSerialization();
    }

    void OnPlayerTriggerExit(VRCPlayerApi player)
    { 
        if (!Networking.IsOwner(gameObject)) return;
        OPCstayplayer--;
        RequestSerialization();
        if (OPCstayplayer > 0) return;
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "NIKCcheck");
    }
    
    public void NIKCcheck(){
        if (!Networking.IsOwner(gameObject)) return;
        SendCustomEventDelayedSeconds("NIKcheck2",35f);
    }

    public void NIKCcheck2(){
        if (OPCstayplayer > 0) return;
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "NIKCchange");
    }

    public void NIKCchange()
    {
        for (int i = 0;i < showobject.Length;i++)
        {
            if (showobject[i] != null)
            {
                showobject[i].SetActive(true);
            }
        }
        for (int i=0;i<hideobject.Length;i++)
        {
            if (hideobject[i] != null)
            {
                hideobject[i].SetActive(false);
            }
        }
    }
}