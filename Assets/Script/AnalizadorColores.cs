using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalizadorColores
{
    public void CambioColor(GameObject esferaAnt, GameObject esferaAct) //Esta es la función que llamamos desde el otro script, y el objetivo de esta función es la de ir comparando si una esfera tiene el mismo color que la anterior, y en caso de que si, el color de estas dos cambie a ser negro, por lo tanto vemos que recibe dos argumentos de tipo GameObject, uno que será la esfera anterior, y otro que será la esfera actual.
    {
        if (esferaAnt != null) //En el script anterior, en el momento en que llamamos la función vemos que entre paréntesis hay copiadas dos variables separadas por coma, la primera que en un principio es nula y la segunda que contiene dentro la esfera recien creada, esas son las dos que recibirá esta función, y con la condicional de esta línea estamos verificando si la variable "esferaAnt" (declarada en los paréntesis de la función) NO es nula, si no es nula, se ejecutará el código que sigue, si es nula se hará caso omiso y seguirá con el código del otro script. 
        {
            Color anterior = esferaAnt.GetComponent<Renderer>().material.color; //Declaramos una variable de tipo Color, en donde si la condicional anterior se cumple es porque llegaron dos esferas, "esferaAnt" y "esferaAct", así que en esta variable "anterior" se guardará el color de "esferaAnt".
            Color actual = esferaAct.GetComponent<Renderer>().material.color; //Declaramos una variable de tipo Color, en donde se guarda el color de "esferaAct".

            if (anterior == actual) //Y por último comparamos los colores anteriormente declarados, y en caso de que sea igual, que es lo que la condición pide, se haga lo siguiente:
            {
                esferaAnt.GetComponent<Renderer>().material.color = Color.black; //"esferaAnt" tomará color negro.
                esferaAct.GetComponent<Renderer>().material.color = Color.black; //"esferaAct" tomará color negro.
            }
        }
    }
}
