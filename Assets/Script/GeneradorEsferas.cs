using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEsferas : MonoBehaviour
{
    int numeroFilas; //Declaramos una variable de tipo entero que nos manejará el número random de filas que se crearan.
    int numeroColumnas; //Declaramos una variable de tipo entero que nos manejará el número random de columnas que se crearán.
    int colorRandom; //Declaramos una variable de tipo entero que nos manejará un rango de números random que, depende del número, se asignará un color u otro.
    int i = 1; //Declaramos una variable de tipo entero que será el contador de filas del ciclo que crea las esferas.
    int j = 0; //Declaramos una variable de tipo entero que será el contador de columnas del ciclo que crea las esferas.
    int k = 1; //Declaramos una variable de tipo entero que será utilizada para manejar un poco el orden en los nombres de todas las esferas que se creen.

    public bool activador = false; //Declaramos una variable de tipo booleana pública que será el checkbox con el que activaremos la creación de las esferas. 
    bool activadorDos = true; //Declaramos una variable de tipo booleana que nos controlará la variable anterior, para que no entre en un bucle infinito que dañe el ejercicio.

    GameObject esferaAnterior; //Declaramos una variable de tipo GameObject en donde se almacenará la esfera anterior con respecto a la que se acaba de crear.

    private void Start() //Utilizamos la función "Start" para que en el momento en que se ejecute Unity haga lo siguiente:
    {
        numeroFilas = Random.Range(3, 12); //Inicializamos la variable anteriormente creada "numeroFilas" con un número aleatorio entre 3 y 12, pero sin incluir el 12, es decir que "numeroFilas" puede valer cualquier número desde 3 hasta 11, y esta variable es la que definira el número de filas más adelante.
        numeroColumnas = Random.Range(3, 12); //Inicializamos la variable anteriormente creada "numeroColumnas" con un número aleatorio entre 3 y 12, pero sin incluir el 12, es decir que "numeroColumnas" puede valer cualquier número desde 3 hasta 11, y esta variable es la que definira el número de columnas más adelante.
        esferaAnterior = null; //Inicializamos la variable anteriormente creada "esferaAnterior" como nula, ya que esta variable no contendrá ningun objeto en la primera repetición del bucle que crea las esferas. 
    }

    private void Update() //Utilizamos la funcion "Update" para que verifique el checkbox asi:
    {
        if (activadorDos == true) //La variable "activadorDos" anteriormente fue declarada como TRUE, es decir "verdadera", y en este condicional "if" estamos preguntando que si esta variable es verdadera, lo cual es cierto, por lo tanto, al cumplirse la condición pasará al bloque de código que hay dentro de este "if", es decir, a la siguiente linea que estará comentada.
        {
            if (activador == true) //Despues de verificarse que la condición anterior es verdadera pasamos a una nueva. La variable "activador" anteriormente fue declarada como FALSE, es decir "falso", y en este condicional estamos preguntando si esta variable es verdadera, por lo tanto en un principio esto no se cumplirá, así que no pasará al siguiente bloque de código, para que este sea verdadero solo hay que activarlo desde el Inspector de Unity, en el momento en el que esto suceda pasará a la siguiente linea que estará comentada. 
            {
                activadorDos = false; //Cuando todo lo anterior se cumpla llegará a esta parte en donde, a la variable "activadorDos" pasará a ser falso al igual que la siguiente línea de código.
                activador = false; //Al llegar aquí la variable "activador" también pasará a ser falsa, todo esto para que no entre en un bucle infinito y se bloquee Unity.
                StartCoroutine("Spheres"); //Después de que el checkbox pase a ser verdadero quiere decir que se dió el permiso para crear las esferas, por lo tanto en esta linea llamamos la corrutina "Spheres" que es la corrutina que almacena todo el código que instanciará las esferas.
            }
        }
    }

    IEnumerator Spheres() //Esta es la corrutina que se encarga de crear las esferas y que fue llamada anteriormente.
    {
        while (i < numeroFilas) //Dentro de la corrutina creamos un bucle que se repetirá las veces que se cumpla la condición que esta entre paréntesis, que es la siguiente: Mientras que "i" (variable creada anteriormente que tiene como valor 1) sea menor a la variable "numeroFilas" (variable creada anteriormente que tendrá como valor un numero aleatorio desde 3 hasta 11), si esto se cumple pasará al código que sigue.
        {
            GameObject esfera = GameObject.CreatePrimitive(PrimitiveType.Sphere); //Después de verificar que lo anterior sea verdadero, pasará a esta linea que lo que hace es, crear un GameObject, en este caso un objeto de tipo "Sphere", es decir, esfera.
            esfera.transform.position = new Vector3(i, j, 0); //Despues de instanciar la esfera, esta línea lo que hace es ubicarme dicha esfera dentro de la escena de Unity por medio de coordenadas, en donde X valdrá "i" es decir 1 en este primer caso, Y valdrá "j" (anteriormente creada) es decir 0 en este primer caso y Z siempre valdrá 0 ya que no trabajaremos con profundidad.
            colorRandom = Random.Range(1, 6); //Inicializamos la variable anteriormente creada "colorRandom" con un número aleatorio entre 1 y 6, pero sin incluir 6, es decir que "colorRandom" puede valer cualquier número desde 1 hasta 5, y esta variable es la que nos dará un número que, dependiendo de este, se asignara un color u otro a la esfera creada (la asignación de color se realizará después de la siguiente línea).
            esfera.name = "esfera " + k; //En esta linea lo que se hace es simplemente darle un nombre a esa esfera que se creó, es decir, por defecto la esfera que se crea pasa a ser llamada "Sphere", así que esta línea es solo por organizar los nombres para que todas no se llamen igual.

            switch (colorRandom) //Después de que se ejecute todo lo anteior pasará a esta línea, que también recibe un argumento, y depende del argumento, se realizará una y otra de las siguientes líneas, es decir, al principio de la línea dice "switch" que significa "según", por lo tanto estamos preguntando que según lo que haya dentro del parentesis, en este caso es la variable colorRandom, es decir, un número aleatorio asignado un par de lineas atras, se ejecute algún caso que hay dentro de este "switch".
            {
                case 1: //Esta es la forma de decir que, en caso que sea el número 1 aquel que fue dado como argumento, es decir, que en caso que la variable "colorRandom" haya valido 1, se realice el paso siguiente.
                    esfera.gameObject.GetComponent<Renderer>().material.color = Color.yellow; //Así es como se le puede asignar un color a la esfera que se acaba de crear, es decir, la esfera sera de color "yellow" en caso de que "colorRandom" valga 1.
                    break; //Break se utiliza para, como su traducción lo dice, romper o quebrar el bloque de código que sigue, en este caso, en el "switch", es decir, el resto de casos ya no se leerán ya que será pérdida de tiempo porque ya se sabe que el número dado como argumento fue el "1".
                case 2: 
                    esfera.gameObject.GetComponent<Renderer>().material.color = Color.blue;
                    break;
                case 3:
                    esfera.gameObject.GetComponent<Renderer>().material.color = Color.red;      
                    break;                                                                      //Todo lo explicado en el caso 1, se cumple igual para los demás casos, es decir, si el número en la variable "colorRandom" llega a ser otro que no sea 1, pasará al caso que tenga dicho número, lo único que cambia es el color que será asignado, que puede ser azul, rojo, etc.
                case 4:
                    esfera.gameObject.GetComponent<Renderer>().material.color = Color.green;
                    break;
                case 5:
                    esfera.gameObject.GetComponent<Renderer>().material.color = Color.magenta;
                    break;
            }

            i++; //Después de que se cumpla uno de los casos anteriores pasará a esta línea que lo único que hace es sumarle 1 al número que tenga la variable "i", por lo tanto, en este caso la variable vale 1, y al llegar a esta línea, "i++" le sumará 1 a "i", es decir que la variable quedará valiendo ahora mismo 2.
            k++; //Esta línea hace lo mismo que la anterior, solo que se le aplicará a la variable "k".

            yield return new WaitForSeconds(0.5f);

            AnalizadorColores ac = new AnalizadorColores(); //Aquí estamos haciendo una instancia de una clase que esta en otro script la cual tiene otro código, y esa instancia la guardamos en la variable "ac".
            ac.CambioColor(esferaAnterior, esfera); //La clase instanciada tiene una función, por lo tanto para llamar esa función al igual que lo hicimos con la función que está en este script para que se ejecute lo que hay dentro se hace así: se copia la variable de la clase, en este caso "ac", punto, y luego el nombre de la función, en este caso "CambiarColor". Y en este momento se ejecutará el código de la otra clase ya que fue llamada, y cuando termine ese código, continuará con la siguiente línea de este script.
            esferaAnterior = esfera; //Después de que se ejecute el otro código, pasará a esta línea, en donde utilizamos la variable "esferaAnterior" creada al principio y a esta variable se le asignará la variable "esfera" que contiene la esfera que se acaba de crear, básicamente en "esferaAnterior" queda almacenada la esfera que se creó.

            if (i == numeroFilas) //Luego llegamos a este condicional, en donde verificamos si "i" llegó a ser igual a "numeroFilas", en caso que sea verdadero pasará a lo siguiente.
            {
                i = 1; //"i" pasa a ser 1 de nuevo para que las esferas pasen a ser instanciadas de nuevo en la posición 1 en la coordenada de X.
                j++; //Y "j" que valía 0, pasa a ser 1 con "j++", es decir, X vuelve a empezar pero Y pasa a ser una unidad mayor, por lo tanto, ya todo este proceso se repetirá una y otra vez hasta que la condición que hay en el ciclo "while" sea falso, se creará otra fila de esferas encima de la anterior.
            }

            if (j == numeroColumnas) //Este es el último paso en donde verificamos que cuando "j" sea igual al número random de "numeroColumnas" quiere decir que ya se crearon todas las filas y columnas asignadas por las variables Random, por lo tanto, utilicamos "break" para que detenga el ciclo.
            {
                break; //Y se detiene todo con el objetivo de que no sea infinito.
            }
        }
    }
}