using System;
using UnityEngine;

public class YardimEt : MonoBehaviour
{
    public void TeleporturuCalistir()
    {
        FindObjectOfType<Teleporter>().TeleportStageTwo();
    }

    public void Makine2InteractiAc()
    {
        FindObjectOfType<ArcadeMachineBolum2>().InteractiAc();
    }
    public void BossActiveEt()
    {
        FindObjectOfType<Bossactivator>().BossActivator(true);
    }

    public void ShotGunActiveEt()
    {
        FindObjectOfType<PlayerGunActivater>().SetIsGunActive(true);
    }

    public void HealtActiveEt()
    {
        FindObjectOfType<HealtActivator>().HealtActivate(true);
    }

    public void AlarmlariKapat()
    {
        FindObjectOfType<AlarmActiavotr>().AlarmActivator(true);
    }

    public void CharacterCanMove(bool canMove)
    {
        FindObjectOfType<PlayerMovement3D>().CanMove(canMove);
    }

    public void CrossActiveEt()
    {
        FindObjectOfType<CrossActiavotr>().SetCrossActive();
    }
}
