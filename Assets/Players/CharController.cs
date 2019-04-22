using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public GameObject bala;
    public GameObject _maoChar;

    public float vel = 5; //velocidade
    public float rotVel = 100; //velocidade da rotacao

    public float gravidade = 20; //gavidade

    public Vector3 movDir = Vector3.zero; //Movimentacao do char
    private CharacterController _control;

    private Animator _anim;

    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        _control = gameObject.GetComponent<CharacterController>();

        Cursor.visible = false;
    }

    void Update()
    {
        //Verificar se o char esta tocando no chao
        if(_control.isGrounded) {
            movDir = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")); //eixo Z é a vertical
            
            //transformDirection transforma a direcao XyZ do espaco local para espaco global
            movDir = transform.TransformDirection(movDir);
            //Adicionando a velocidade
            movDir *= vel;

            ///-----------------Camera------------------------
            float rotaMouse = Input.GetAxis("Mouse X") * (rotVel * 2);
            rotaMouse *= Time.deltaTime;

            transform.Rotate(0,rotaMouse,0);

            Andar();
            
            //----------------CLIQUE MOUSE ATIRAR--------------
            if(Input.GetKey(KeyCode.Mouse0) && Input.GetAxis("Vertical")==0) {
                Atirar();
            }

            if(Input.GetKey(KeyCode.Mouse0)) {
                Instantiate(bala, _maoChar.transform.position, transform.rotation);
                //GameObject _bala = Instantiate(bala);
                //_bala.transform.position = _maoChar.transform.position;
            }

        }

        //Aplicando gravidade caso o char esteja voando
        movDir.y -= gravidade * Time.deltaTime;

        //Movendo o controle em relação ao tempo
        _control.Move(movDir * Time.deltaTime);

        ///-----------------Rotação Apertando o A ou S ---------------------
        /*
        float rotacao = Input.GetAxis("Horizontal") * rotVel;
        rotacao *= Time.deltaTime;

        transform.Rotate(0,rotacao,0);
        */
    }

    private void Andar() {
        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");
        bool movimento = false;

        if(_vertical != 0 || _horizontal!=0) {
            movimento = true;
        } else {
            movimento = false;
        }

        _anim.SetBool("Run", movimento);
    }

    private void Atirar() {
        _anim.SetTrigger("Atirar");
    }

}
