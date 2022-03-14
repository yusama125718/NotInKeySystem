
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class NotInKeySystem : UdonSharpBehaviour
{
    [Header("ロック時に表示されるオブジェクト")]
    [SerializeField] private GameObject[] lockobject;

    [Header("アンロック時に表示するオブジェクト")]
    [SerializeField] private GameObject[] unlockobject;  

    void Interact(VRCPlayerApi player)
    {
        if (!Networking.IsOwner(gameObject))
        {
            Networking.SetOwner(Networking.LocalPlayer, gameObject);
        }
        for (int i=0;i>unlockobject.Length;i++)
        {
            if (unlockobject[i] = null)
            {
                return;
            }
            if (unlockobject[i].activeSelf)
            {
                unlockobject[i].SetActive(false);
            }
            else
            {
                unlockobject[i].SetActive(true);
            }
        }
        for (int i=0;i>lockobject.Length;i++)
        {
            if (lockobject[i] = null)
            {
                return;
            }
            if (lockobject[i].activeSelf)
            {
                lockobject[i].SetActive(false);
            }
            else
            {
                lockobject[i].SetActive(true);
            }
        }
    }
}