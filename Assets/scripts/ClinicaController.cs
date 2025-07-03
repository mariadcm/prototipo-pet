using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ClinicaController : MonoBehaviour
{
    public Slider barraSaude;
    public Button botaoComida;
    public Button botaoAgua;
    public Button botaoRemedio;
    public Button botaoRemedioErrado;
    public Button botaoEscuro;
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
        botaoRemedioErrado.onClick.AddListener(() => Castigar(25f));
        botaoEscuro      .onClick.AddListener(() => CastigarEscuro(20f));


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
    void Castigar(float valor)
    {
        saude = Mathf.Max(saude - valor, 0f);
        barraSaude.value = saude;
        AtualizarEstadoMascote();
        Debug.Log($"Mascote perdeu {valor} de saúde (castigo). Saúde agora: {saude}");
    }

    void CastigarEscuro(float valor)
    {
        // Diminui a saúde
        saude = Mathf.Max(saude - valor, 0f);
        barraSaude.value = saude;
        AtualizarEstadoMascote();
        Debug.Log($"Mascote ficou no escuro e perdeu {valor} de saúde. Saúde agora: {saude}");

        // Efeito de escuro: pisca um painel ou altera a cor da cena
        StartCoroutine(FlashEscuro());
    }

    IEnumerator FlashEscuro()
    {
        // Crie um GameObject UI > Panel, renomeie para "PainelEscuro"
        // e deixe-o desativado no início (SetActive(false)).
        GameObject painel = GameObject.Find("PainelEscuro");
        if (painel != null)
        {
            painel.SetActive(true);
            yield return new WaitForSeconds(1f);  // escuro por 1 segundo
            painel.SetActive(false);
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

    




      
       
       