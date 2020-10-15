using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace M {
    public class Token {
        private String lexeme;
        private String state;
        private int row, column, pos;
        private Token next;
        private Color color;

        public Token(States state, String lexeme, int row, int column, int pos) {
            //metodo constructor
            color = Color.White;
            this.state = getStates(state);
            this.lexeme = lexeme;
            this.row = row;
            this.column = column;
            this.pos = pos;
            this.next = null;
        }

        public String Lexeme { get { return lexeme; } }
        public String State { get { return state; } }
        public int Row { get { return row; } }
        public int Column { get { return column; } }
        public int Pos { get { return pos; } }
        public Token Next { get { return next; } set { next = value; } }
        public Color Color { get { return color; } set { color = value; } }


        public enum States {
            q1,//variable
            q2,//numero(entero)
            q4,//numero(flotante)
            q7,//cadena
            q8,//divicion
            q11,//comentario
            q14,//potencia
            q15,//multiplicacion
            q16,//suma
            q17,//resta
            q18,//dos puntos(ternario(else))
            q19,//asignacion =
            q20,//punto y coma(pyc)
            q21,//parentesis izquierdo
            q22,//parentesis derecho
            q23,//llave izquierda
            q24,//llave derecha
            q25,//corchete izquierdo
            q26,//corchete derecho
            qInt,//elimina decimales de un numero
            qPow,//eleva al cuadrado
            qE,//euler
            qPi,//pi
            qLog,//logaritmo base 10
            qSin,//seno
            qCos,//coseno
            qTan,//tangente
            qDel,//elimina variable o limpia lista
            qList,//lista de variables generadas
            qPrint,//imprime en pantalla
            qInput,//recibe un valor numerico
            qErr,//token de error
            qFin,//token final
        }


        private String getStates(States state) {
            String t = "";

            switch (state) {
                case States.q1:
                    color = Color.LightSkyBlue;
                    t = "var";
                    break;
                case States.q2:
                case States.q4:
                    color = Color.FromArgb(43, 145, 175);
                    t = "float";
                    break;
                case States.q7:
                    color = Color.FromArgb(255, 181, 0);
                    t = "string";
                    break;
                case States.q8:
                    t = "div";
                    break;
                case States.q11:
                    color = Color.FromArgb(2, 183, 43);
                    t = "comment";
                    break;
                case States.q14:
                    t = "pow";
                    break;
                case States.q15:
                    t = "mul";
                    break;
                case States.q16:
                    t = "sum";
                    break;
                case States.q17:
                    t = "sub";
                    break;
                case States.q18:
                    t = "twoPoints";
                    break;
                case States.q19:
                    t = "assignment";
                    break;
                case States.q20:
                    t = "pyc";
                    break;
                case States.q21:
                    t = "leftParent";
                    break;
                case States.q22:
                    t = "rightParent";
                    break;
                case States.q23:
                    t = "leftKey";
                    break;
                case States.q24:
                    t = "rightKey";
                    break;
                case States.q25:
                    t = "leftBracket";
                    break;
                case States.q26:
                    t = "rightBracket";
                    break;
                case States.qInt:
                    color = Color.FromArgb(202, 121, 236);
                    t = "int";
                    break;
                case States.qPow:
                    color = Color.FromArgb(202, 121, 236);
                    t = "powTwo";
                    break;
                case States.qE:
                    color = Color.FromArgb(202, 121, 236);
                    t = "e";
                    break;
                case States.qPi:
                    color = Color.FromArgb(202, 121, 236);
                    t = "pi";
                    break;
                case States.qLog:
                    color = Color.FromArgb(202, 121, 236);
                    t = "log";
                    break;
                case States.qSin:
                    color = Color.FromArgb(202, 121, 236);
                    t = "sin";
                    break;
                case States.qCos:
                    color = Color.FromArgb(202, 121, 236);
                    t = "cos";
                    break;
                case States.qTan:
                    color = Color.FromArgb(202, 121, 236);
                    t = "tan";
                    break;
                case States.qDel:
                    color = Color.FromArgb(202, 121, 236);
                    t = "del";
                    break;
                case States.qList:
                    color = Color.FromArgb(202, 121, 236);
                    t = "list";
                    break;
                case States.qPrint:
                    color = Color.FromArgb(202, 121, 236);
                    t = "print";
                    break;
                case States.qInput:
                    color = Color.FromArgb(202, 121, 236);
                    t = "input";
                    break;
                case States.qFin:
                    t = "fin";
                    break;
                case States.qErr:
                    color = Color.Red;
                    t = "error";
                    break;
            }

            return t;
        }

    }

}
