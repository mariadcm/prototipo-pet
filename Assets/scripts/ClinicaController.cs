using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ClinicaController : MonoBehaviour
{
    public Slider barraSaude;
    public Button botaoComida;
    public Button botaoAgua;
    public Button botaoRemedio;
    public TextMeshProUGUI textoCertificado;
    public SpriteRenderer mascoteImagem;
    public Sprite mascoteTriste;
    public Sprite mascoteFeliz;


    private float saude = 0f;
    private float saudeMax = 100f;


    void Start()
    {
        //mascoteImagem= GetComponent<SpriteRenderer>();
        
        barraSaude.maxValue = saudeMax;
        barraSaude.value = saude;
        textoCertificado.gameObject.SetActive(false);


        botaoComida.onClick.AddListener(() => Cuidar(10f));
        botaoAgua.onClick.AddListener(() => Cuidar(5f));
        botaoRemedio.onClick.AddListener(() => Cuidar(15f));
    }

    void Update()
    {
        
        if (saude >= (saudeMax / 2))
        {
            mascoteImagem.sprite = mascoteFeliz;
           
        }
        else
            mascoteImagem.sprite = mascoteTriste;
    
    }


    void Cuidar(float valor)
    {
        saude += valor;
        if (saude > saudeMax) saude = saudeMax;


        barraSaude.value = saude;


        AtualizarEstadoMascote();


        if (saude >= saudeMax)
        {
            MostrarCertificado();
        }
    }


    void AtualizarEstadoMascote()
    {
        Debug.Log("atualizando o estado do mascote de triste para feliz ");
        if (saude >= saudeMax / 2)
            mascoteImagem.sprite = mascoteFeliz;
        else
            mascoteImagem.sprite = mascoteTriste;
    }


    void MostrarCertificado()
    {
        textoCertificado.text = "Parabéns! Você cuidou muito bem do seu amiguinho!";
        textoCertificado.gameObject.SetActive(true);
    }
}



      
       
       