using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleManager : MonoBehaviour
{
    private static ParticleManager _instance;

    [SerializeField] private ParticleInstaller _particleInstaller;

    public ParticleManager Instance=> _instance;

    public static ParticleInstaller ParticleInstaller => _instance._particleInstaller;

    private void Awake()
    {
        _instance = this;
    }

}
