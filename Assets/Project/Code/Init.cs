using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    private IAuthUseCase _anonimousUseCase;

    void Awake()
    {
        _anonimousUseCase = new AnonimousUseCase();
    }

    void Start()
    {
        _anonimousUseCase.Authenticate(new UserInfo());

        //pantalla de carga
    }
}
