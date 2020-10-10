using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M {
    public class Token {
        private String lexeme;
        private String state;
        private int row, column, pos;
        private Token next;

        public Token(States state, String lexeme, int row, int column, int pos) {
            //metodo constructor
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
                    t = "var";
                    break;
                case States.q2:
                    t = "float";
                    break;
                case States.q4:
                    t = "float";
                    break;
                case States.q7:
                    t = "string";
                    break;
                case States.q8:
                    t = "div";
                    break;
                case States.q11:
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
                    t = "int";
                    break;
                case States.qPow:
                    t = "powTwo";
                    break;
                case States.qE:
                    t = "e";
                    break;
                case States.qPi:
                    t = "pi";
                    break;
                case States.qLog:
                    t = "log";
                    break;
                case States.qSin:
                    t = "sin";
                    break;
                case States.qCos:
                    t = "cos";
                    break;
                case States.qTan:
                    t = "tan";
                    break;
                case States.qDel:
                    t = "del";
                    break;
                case States.qList:
                    t = "list";
                    break;
                case States.qPrint:
                    t = "print";
                    break;
                case States.qInput:
                    t = "input";
                    break;
                case States.qFin:
                    t = "fin";
                    break;
                case States.qErr:
                    t = "error";
                    break;
            }

            return t;
        }

    }

}
