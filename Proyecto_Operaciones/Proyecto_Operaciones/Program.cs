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
            

            Console.SetCursorPosition(18,6); Console.WriteLine("Resultado = " + operacion[1]);
            Console.ReadKey();
        }
      
    }

    class partedos 
    {
       

        public void buscaresp(byte espacio, byte pdato, string[] operacion)
        {
            string cambio;
            espacio -= 2;
            
            for (; pdato <= espacio; pdato++) 
            {
                if (operacion[pdato] == " ")
                {
                     pdato += 2;
                     cambio = operacion[pdato];
                     pdato -= 2;
                     operacion[pdato] = cambio;
                     pdato += 2;
                     operacion[pdato] = " ";
                     pdato -= 2;
                }
            }

            

        
        }


        public void organiza(byte espacio, byte pdato, string[] operacion)
        {
            byte ultimo = 0; string cambio; byte posb =0;
            espacio = 20;
            while (espacio >= 1)
            {
                ultimo = espacio;
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
                        }
                    }
                    ultimo--;

                }    

                espacio--; 
            }

           
        }

        
        public void parentesis (string [] operacion, byte pfin) 
        {
            byte abierto = 0, espacio = 0, pdato = 0,a,b,k,contar;  
            double x=0, y=0, resultado=0;
            partedos organizar = new partedos();
            partedos acomodar = new partedos();

            while(abierto==0)
            {
                for (byte i = 0; i <=pfin ; i++)
                {
                    if ( (operacion[i] == "(") )
                    {
                        pdato = i; espacio = i; espacio += 1;
                        while( (operacion[espacio] !="(") && (operacion[espacio]!=")"))
                        {
                            espacio += 1;
                        }

                        if (operacion[espacio] != "(") 
                        {
                            byte j=Convert.ToByte (pdato + 1);
                            for (; j <= espacio;j++ )
                            {
                                if (operacion[j] == "*")
                                {
                                    a = j; b = j;
                                    a -= 1; b += 1;
                                    x = Convert.ToDouble(operacion[a]); y = Convert.ToDouble(operacion[b]);
                                    resultado = x * y;

                                    /**/ a = j; b = j;                                              /**/
                                    /**/ a -= 1; b += 1;                                           /**/
                                    /**/ operacion[a] = Convert.ToString(resultado);              /**/
                                    /**/ operacion[j] = " "; operacion[b] = " ";                 /**/
                                    
                                    j = a;
                                    organizar.buscaresp(espacio, pdato, operacion);
                                    acomodar.organiza(espacio, pdato, operacion);
                                    espacio -= 2;
                                }
                                else
                                {
                                    if (operacion[j] == "/")
                                    {
                                        a = j; b = j;
                                        a -= 1; b += 1;
                                        x = Convert.ToDouble(operacion[a]); y = Convert.ToDouble(operacion[b]);
                                        resultado = x / y;

                                       
                                        /**/ a = j; b = j;                                              /**/
                                        /**/ a -= 1; b += 1;                                           /**/
                                        /**/ operacion[a] = Convert.ToString(resultado);              /**/
                                        /**/ operacion[j] = " "; operacion[b] = " ";                 /**/
                                      
                                        j = a;
                                        organizar.buscaresp(espacio, pdato, operacion);
                                        acomodar.organiza(espacio, pdato, operacion);

                                        espacio -= 2;
                                    }
                                    
                                }
                                
                            
                            }
                             
                         
                            j = Convert.ToByte(pdato + 1);
                            for (; j <= espacio; j++)
                            {
                                if (operacion[j] == "+")
                                {
                                    a = j; b = j;
                                    a -= 1; b += 1;
                                    x = Convert.ToDouble(operacion[a]); y = Convert.ToDouble(operacion[b]);
                                    resultado = x + y;

                                 
                                    /**/ a = j; b = j;
                                    /**/ a -= 1; b += 1;                                           /**/
                                    /**/ operacion[a] = Convert.ToString(resultado);              /**/
                                    /**/ operacion[j] = " "; operacion[b] = " ";                 /**/
                                   
                                    j = a;
                                    organizar.buscaresp(espacio, pdato, operacion);
                                    acomodar.organiza(espacio, pdato, operacion);
                                    espacio -= 2;
                                }
                                else
                                {
                                    if (operacion[j] == "-")
                                    {
                                        a = j; b = j;
                                        a -= 1; b += 1;
                                        x = Convert.ToDouble(operacion[a]); y = Convert.ToDouble(operacion[b]);
                                        resultado = x - y;
 
                                        /**/ a = j; b = j;                                              /**/
                                        /**/ a -= 1; b += 1;                                           /**/
                                        /**/ operacion[a] = Convert.ToString(resultado);              /**/
                                        /**/ operacion[j] = " "; operacion[b] = " ";                 /**/
                                      
                                        j = a;
                                        organizar.buscaresp(espacio, pdato, operacion);
                                        acomodar.organiza(espacio, pdato, operacion);
                                        espacio -= 2;
                                    }

                                }


                            }
                                                       
                            if (pdato >= 1)
                            {
                                k = Convert.ToByte(pdato - 1);
                                if (operacion[k] == "+" || operacion[k] == "(" || operacion[k] == ")" || operacion[k] == "-" || operacion[k] == "*" || operacion[k] == "/")
                                {
                                    operacion[pdato] = " "; operacion[espacio] = " ";
                                    acomodar.organiza(espacio, pdato, operacion);

                                }
                                else
                                {
                                    operacion[pdato] = "*"; operacion[espacio] = " ";
                                    acomodar.organiza(espacio, pdato, operacion);
                                }
                            }
                              
                          
                            contar=0;
                            for (int z = 0; z <= 19; z++)
                            {
                                if (operacion[z] == "(")
                                {
                                    contar++;
                                }
                            }

                            if (contar == 1)  abierto = 1;

                        }
                         
                         }
                }
            }

        }
    
    }

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

                    }
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
                    }


                }
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


                }
                else
                {
                    pfin = pos;
                }

            } while ((pos < 19) && (temp1 != "\r") && (temp2 != "\r"));

          


            enviar.parentesis(operacion,pfin);
            final.imprimir(operacion);

            Console.Clear();
            byte posx = 5;
            for (int m = 0; m <= 19; m++)
            {
                Console.SetCursorPosition(posx, 6); Console.WriteLine(operacion[m]);
                posx += 1;
            }
            
        }
    }
}
