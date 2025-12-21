using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using TMPro;
using UnityEngine.UI;

public class CambiarVariable : MonoBehaviour
{
    public GameObject objeto;
    public string nombreComponente;
    public string nombreVariable;
    public TMP_Text textoValor;


    private Component componente;
    private FieldInfo variable;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        BuscarComponentes();
        InicializarSlider();
    }

    
    void InicializarSlider()
    {
       float valorIncial = (float)variable.GetValue(componente);
        slider.value = valorIncial;
        textoValor.text = valorIncial.ToString("F2");
        slider.onValueChanged.AddListener(CambiarValor); //Cuando cambie el valor del slider se llama a la funciona CambiarValor dandole como entrada el valor del slider
    }

    void CambiarValor(float valor)
    {
        variable.SetValue(componente, valor);
        textoValor.text = valor.ToString("F2");
    }
    void BuscarComponentes()
    {
        slider = GetComponent<Slider>();

        componente = objeto.GetComponent(nombreComponente);

        if(componente == null )
        {
            Debug.LogWarning("Falta el componente " + nombreComponente);
        }

        variable = componente.GetType().GetField(nombreVariable);

        if (variable == null)
        {
            Debug.LogWarning("Falta la variable " + nombreVariable);
        }

    }
}
