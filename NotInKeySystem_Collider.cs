
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class NotInKeySystem_Collider : UdonSharpBehaviour
{
    [Header("ロック時に表示されるオブジェクト")]
    [SerializeField] private GameObject[] hideobject;

    [Header("アンロック時に表示するオブジェクト")]
    [SerializeField] private GameObject[] showobject;

    int stayplayer;
    void OnPlayerTriggerJoin(VRCPlayerApi player)
    {
        stayplayer++;
    }

    public override void OnPlayerTriggerExit(VRCPlayerApi player)
    {
        stayplayer++;
        if (stayplayer >= 0)
        {   
            return;
        }
        if (!Networking.IsOwner(gameObject))
        {
            Networking.SetOwner(Networking.LocalPlayer, gameObject);
        }
        for (int i=0;i>hideobject.Length;i++)
        {
            if (hideobject[i] = null)
            {
                return;
            }
            hideobject[i].SetActive(false);
        }
        for (int i=0;i>showobject.Length;i++)
        {
            if (showobject[i] = null)
            {
                return;
            }
            showobject[i].SetActive(true);
        }
    }
}