﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace inicio
{
    class parte3 
    {
        
        public void imprimir(string [] operacion) 
        {
            /*Console.Clear();
            byte posx = 5;
            for (int i = 0; i <= 19; i++)
            {
                Console.SetCursorPosition(posx, 6); Console.WriteLine(operacion[i]);
                posx += 1;
            }*/

            Console.SetCursorPosition(18,6); Console.WriteLine("Resultado = " + operacion[1]);
            Console.ReadKey();
        }///fin  public void imprimir
      
    }

    class partedos 
    {
       

        public void buscaresp(byte pcdo, byte pdato, string[] operacion)///busca los espacion dentro del parentesis 
        {
            string cambio;
            pcdo -= 2;
            
            for (; pdato <= pcdo; pdato++) ////for 1-3
            {
                if (operacion[pdato] == " ")////if 1-3 
                {
                     pdato += 2;
                     cambio = operacion[pdato];
                     pdato -= 2;
                     operacion[pdato] = cambio;
                     pdato += 2;
                     operacion[pdato] = " ";
                     pdato -= 2;
                }///fin if 1-3
            }////fin for 1-3

            

            //Console.WriteLine(operacion[2]);
        
        }///fin buscaresp


        public void organiza(byte pcdo, byte pdato, string[] operacion)////organiza toda la expresion quitando los espacios en blanco 
        {
            byte ultimo = 0; string cambio; byte posb =0;
            pcdo = 19;
            while (pcdo >= 1)
            {
                ultimo = pcdo;
                while (ultimo >= 1)
                {
                    posb = Convert.ToByte(ultimo - 1);
                    if (posb != 255)
                    {
                        while ( ((posb != 255) &&(posb >= 0) ) && (operacion[posb] == " ") )
                        {
                            cambio = operacion[ultimo];
                            operacion[posb] = cambio;
                            operacion[ultimo] = " ";
                            posb--;
                        }///fin while que busca las posiciones vacias
                    }
                    ultimo--;

                }///fin while que busca desde el ultimo       

                pcdo--; 
            }///fin pcdo

           // Console.WriteLine(operacion[2]);
        }///fin opublic void organiza 

        
        public void parentesis (string [] operacion, byte pfin) 
        {
            byte abierto = 0, pcdo = 0, pdato = 0,a,b,k,contar;  ///k revisa la operacion antes del parentesis
            double x=0, y=0, resultado=0;
            partedos organizar = new partedos();
            partedos acomodar = new partedos();

            while(abierto==0)///while1---crear un siclo que busque los parentesis si no los hay coloca el abierto en 0
            {
                for (byte i = 0; i <=pfin ; i++)///for que recorre////cambiar por un while
                {
                    if ( (operacion[i] == "(") )//if-1 
                    {
                        pdato = i; pcdo = i; pcdo += 1;
                        while( (operacion[pcdo] !="(") && (operacion[pcdo]!=")"))//while que busca la termiancion del parentesis
                        {
                            pcdo += 1;
                        }///fin while que busca la termiancion del parentesis

                        if (operacion[pcdo] != "(") 
                        {
                            byte j=Convert.ToByte (pdato + 1);
                            for (; j <= pcdo;j++ )///for-2 como primero se realizan las * & / realizo este for
                            {
                                if (operacion[j] == "*")//if-2
                                {
                                    a = j; b = j;
                                    a -= 1; b += 1;
                                    x = Convert.ToDouble(operacion[a]); y = Convert.ToDouble(operacion[b]);
                                    resultado = x * y;

                                    //// ahora escribo el resultado en la posicion  anterior al asterisco
                                    //// & borro las otras dos posiciones                            /**/ 
                                    /**/ a = j; b = j;                                              /**/
                                    /**/ a -= 1; b += 1;                                           /**/
                                    /**/ operacion[a] = Convert.ToString(resultado);              /**/
                                    /**/ operacion[j] = " "; operacion[b] = " ";                 /**/
                                    ////////////////////////////////////////////////////////////////
                                    j = a;
                                    organizar.buscaresp(pcdo, pdato, operacion);
                                    acomodar.organiza(pcdo, pdato, operacion);
                                    pcdo -= 2;
                                }//fin if-2
                                else
                                {
                                    if (operacion[j] == "/")//if-3
                                    {
                                        a = j; b = j;
                                        a -= 1; b += 1;
                                        x = Convert.ToDouble(operacion[a]); y = Convert.ToDouble(operacion[b]);
                                        resultado = x / y;

                                        //// ahora escribo el resultado en la posicion  anterior al asterisco
                                        //// & borro las otras dos posiciones                            /**/ 
                                        /**/ a = j; b = j;                                              /**/
                                        /**/ a -= 1; b += 1;                                           /**/
                                        /**/ operacion[a] = Convert.ToString(resultado);              /**/
                                        /**/ operacion[j] = " "; operacion[b] = " ";                 /**/
                                        ////////////////////////////////////////////////////////////////
                                        j = a;
                                        organizar.buscaresp(pcdo, pdato, operacion);
                                        acomodar.organiza(pcdo, pdato, operacion);

                                        pcdo -= 2;
                                    }//fin if-3
                                    
                                }///fin else que  conduce a la divicion
                                
                            
                            }///fin for-2
                             ///



                            ////////////////operaciones secundarias
                            j = Convert.ToByte(pdato + 1);
                            for (; j <= pcdo; j++)///for-3 con este for realizo las operaciones secundarias
                            {
                                if (operacion[j] == "+")//if-4
                                {
                                    a = j; b = j;
                                    a -= 1; b += 1;
                                    x = Convert.ToDouble(operacion[a]); y = Convert.ToDouble(operacion[b]);
                                    resultado = x + y;

                                    //// ahora escribo el resultado en la posicion  anterior al asterisco
                                    //// & borro las otras dos posiciones                            /**/ 
                                    /**/ a = j; b = j;
                                    /**/ a -= 1; b += 1;                                           /**/
                                    /**/ operacion[a] = Convert.ToString(resultado);              /**/
                                    /**/ operacion[j] = " "; operacion[b] = " ";                 /**/
                                    ////////////////////////////////////////////////////////////////
                                    j = a;
                                    organizar.buscaresp(pcdo, pdato, operacion);
                                    acomodar.organiza(pcdo, pdato, operacion);
                                    pcdo -= 2;
                                }//fin if-4
                                else
                                {
                                    if (operacion[j] == "-")//if-5
                                    {
                                        a = j; b = j;
                                        a -= 1; b += 1;
                                        x = Convert.ToDouble(operacion[a]); y = Convert.ToDouble(operacion[b]);
                                        resultado = x - y;

                                        //// ahora escribo el resultado en la posicion  anterior al asterisco
                                        //// & borro las otras dos posiciones                            /**/ 
                                        /**/ a = j; b = j;                                              /**/
                                        /**/ a -= 1; b += 1;                                           /**/
                                        /**/ operacion[a] = Convert.ToString(resultado);              /**/
                                        /**/ operacion[j] = " "; operacion[b] = " ";                 /**/
                                        ////////////////////////////////////////////////////////////////
                                        j = a;
                                        organizar.buscaresp(pcdo, pdato, operacion);
                                        acomodar.organiza(pcdo, pdato, operacion);
                                        pcdo -= 2;
                                    }//fin if-5

                                }///fin else que  conduce a la divicion


                            }///fin for-2
                            ///


                            ///////////////fin for-3
                            if (pdato >= 1)
                            {
                                k = Convert.ToByte(pdato - 1);
                                if (operacion[k] == "+" || operacion[k] == "(" || operacion[k] == ")" || operacion[k] == "-" || operacion[k] == "*" || operacion[k] == "/")
                                {
                                    operacion[pdato] = " "; operacion[pcdo] = " ";
                                    acomodar.organiza(pcdo, pdato, operacion);

                                }
                                else
                                {
                                    operacion[pdato] = "*"; operacion[pcdo] = " ";
                                    acomodar.organiza(pcdo, pdato, operacion);
                                }
                            }///fin pto>=1
                               
                               //Console.SetCursorPosition(15, 12); Console.WriteLine(operacion[0]);
                            contar=0;
                            for (int z = 0; z <= 19; z++)///for que busca haber cuantos parentesis hay
                            {
                                if (operacion[z] == "(")
                                {
                                    contar++;
                                }
                            }///fin for que busca haber cuantos parentesis hay

                            if (contar == 1)  abierto = 1;

                        }///fin si del parentesis != abierto
                         ///


                        ///como termino las operaciones dentro de los parentesis los borro
                        
                    }///fin if-1
                }///fin for que recorre
            }///fin while1

        }///fin public void parentesis
    
    }///fin class partedos

    class parteuno
    {
        static void Main(string[] args)
        {
            Console.Title = ("calculadora por orden de simbolos, By Elvis Santizo");
            Console.WriteLine("ingresa operacion");
            Console.WriteLine("Puedes utilizar (), {},[]");
            string [] operacion = new string[23];
            byte pos = 1,pfin=0;
            string temp1,temp2=" ";
            partedos enviar = new partedos();
            parte3 final = new parte3();

            operacion[0] = "("; operacion[19] = ")";

            do
            {
                temp1 = Convert.ToString(Console.ReadKey().KeyChar);

                if (temp1 != "\r")
                {
                    if (temp2 == " ")
                    {

                        if (temp1 == "+" || temp1 == "(" || temp1 == ")" || temp1 == "-" || temp1 == "*" || temp1 == "/")
                        {
                            operacion[pos] = temp1;
                            pos++;

                        }
                        else
                        {
                            operacion[pos] = operacion[pos] + temp1;
                        }

                    }///fin temp2==" "
                    else
                    {
                        if (temp1 == "+" || temp1 == "(" || temp1 == ")" || temp1 == "-" || temp1 == "*" || temp1 == "/")
                        {
                            if (temp2 == "+" || temp2 == "(" || temp2 == ")" || temp2 == "-" || temp2 == "*" || temp2 == "/")
                            {
                                operacion[pos] = temp1;
                                pos++;
                            }
                            else
                            {
                                pos++; operacion[pos] = temp1; pos++;
                            }

                        }
                        else
                        {
                            operacion[pos] = operacion[pos] + temp1;
                        }
                    }//fin else de temp2==" "


                }///fin temp1 != /r
                else 
                {
                    pfin = pos;
                }

                temp2 = Convert.ToString(Console.ReadKey().KeyChar);
                if (temp2 != "\r")
                {
                    if (temp2 == "+" || temp2 == "(" || temp2 == ")" || temp2 == "-" || temp2 == "*" || temp2 == "/")
                    {
                        if (temp1 == "+" || temp1 == "(" || temp1 == ")" || temp1 == "-" || temp1 == "*" || temp1 == "/")
                        {
                            operacion[pos] = temp2;
                            pos++;
                        }
                        else
                        {
                            pos++; operacion[pos] = temp2; pos++;
                        }

                    }
                    else 
                    {
                        operacion[pos] = operacion[pos] + temp2;
                    }


                }///fin temp2 != /r
                else
                {
                    pfin = pos;
                }

            } while ((pos < 19) && (temp1 != "\r") && (temp2 != "\r"));

           /* Console.SetCursorPosition(2, 4);Console.WriteLine(" ------ ");
            for (int i = 0; i <= 9; i++)
            {
                
                Console.WriteLine(operacion[i]);

            }*/


            enviar.parentesis(operacion,pfin);
            final.imprimir(operacion);

            Console.Clear();
            byte posx = 5;
            for (int m = 0; m <= 19; m++)
            {
                Console.SetCursorPosition(posx, 6); Console.WriteLine(operacion[m]);
                posx += 1;
            }
            //Console.ReadKey();
        }///fin main
    }///fin class
}///fin namespace
