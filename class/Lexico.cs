using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M {
    class Lexico {
        private List<Token> listTokens;
        private int state;
        private String lexeme;

        public Lexico() {
            listTokens = new List<Token>();
        }

        public List<Token> scaner(String entry) {
            //fin de cadena
            entry += "$";
            //limpiar lista
            listTokens.Clear();
            //inicializamos los valores para comenzar a generar los tokens
            int row = 1, column = 1, count = 0, end = entry.Length;
            Token.States qState = Token.States.q1;
            //tomamos el primer valor de la cadena
            char character = entry[0];

            while(character.CompareTo('$') != 0 && count < end) {
                //vaciamos el contenido que tenga el lexema anterior
                //para generar un nuevo token
                lexeme = "";
                //el estado regresa a ser el inicial
                state = 0;

                while(state != -1) {
                    //el estado (-1) es un estado de fin de token o error
                    switch(state) {
                        case 0:
                            if (char.IsLetter(character) || character.CompareTo('_') == 0) {
                                //estado 1 variable
                                state = 1;
                                lexeme += character;
                            } else if (char.IsDigit(character)) {
                                //estado 2 entero
                                state = 2;
                                lexeme += character;
                            } else if (character.CompareTo('"') == 0) {
                                //estado 5 comillas
                                state = 5;
                                lexeme += character;
                            } else if (character.CompareTo('/') == 0) {
                                //estado 8 barra diagonal /
                                state = 8;
                                lexeme += character;
                            } else if (character.CompareTo('^') == 0) {
                                //estado 14 potencia ^
                                state = -1;
                                lexeme += character;
                                qState = Token.States.q14;
                            } else if (character.CompareTo('*') == 0) {
                                //estado 15 mul
                                state = -1;
                                lexeme += character;
                                qState = Token.States.q15;
                            } else if (character.CompareTo('+') == 0) {
                                //estado 16 sum
                                state = -1;
                                lexeme += character;
                                qState = Token.States.q16;
                            } else if (character.CompareTo('-') == 0) {
                                //estado 17 sub
                                state = -1;
                                lexeme += character;
                                qState = Token.States.q17;
                            } else if (character.CompareTo(':') == 0) {
                                //estado 18 dos puntos :
                                state = 18;
                                lexeme += character;
                            } else if (character.CompareTo(';') == 0) {
                                //estado 20 pyc
                                state = -1;
                                lexeme += character;
                                qState = Token.States.q20;
                            } else if (character.CompareTo('(') == 0) {
                                //estado 21 parentesis izq
                                state = -1;
                                lexeme += character;
                                qState = Token.States.q21;
                            } else if (character.CompareTo(')') == 0) {
                                //estado 22 parentesis der
                                state = -1;
                                lexeme += character;
                                qState = Token.States.q22;
                            } else if (character.CompareTo('{') == 0) {
                                //estado 23 llave izq
                                state = -1;
                                lexeme += character;
                                qState = Token.States.q23;
                            } else if (character.CompareTo('}') == 0) {
                                //estado 24 llave der
                                state = -1;
                                lexeme += character;
                                qState = Token.States.q24;
                            } else if (character.CompareTo('[') == 0) {
                                //estado 25 braquet izq
                                state = -1;
                                lexeme += character;
                                qState = Token.States.q25;
                            } else if (character.CompareTo(']') == 0) {
                                //estado 26 braquet der
                                state = -1;
                                lexeme += character;
                                qState = Token.States.q26;
                            } else if (isSpace(character)) {
                                state = -1;
                            } else {
                                state = -1;
                                lexeme += character;
                                qState = Token.States.qErr;
                            }
                            character = entry[++count];
                            column++;
                            break;
                        case 1:
                            if (char.IsLetter(character) || character.CompareTo('_') == 0 || char.IsDigit(character)) {
                                //se mantiene en este estado
                                lexeme += character;
                                character = entry[++count];
                                column++;
                            } else if (character.CompareTo('.') == 0) {
                                state = 30;
                                lexeme += character;
                                character = entry[++count];
                                column++;
                            } else {
                                state = -1;
                                qState = isReservedWord(lexeme);
                            }
                            break;
                        case 2:
                             if (char.IsDigit(character)) {
                                //se mantiene en el mismo estado
                                lexeme += character;
                                character = entry[++count];
                                column++;
                            } else if (character.CompareTo('.') == 0) {
                                //nos mevomos al estado 3
                                state = 3;
                                lexeme += character;
                                character = entry[++count];
                                column++;
                            } else if (char.IsLetter(character) || character.CompareTo('_') == 0 || character.CompareTo('"') == 0) {
                                //token de error
                                //estado error continuo
                                state = 30;
                                lexeme += character;
                                character = entry[++count];
                                column++;
                                qState = Token.States.qErr;
                            } else {
                                state = -1;
                                qState = Token.States.q2;
                            }
                            break;
                        case 3:
                            if (char.IsDigit(character)) {
                                //se cambia al estado 4
                                state = 4;
                                lexeme += character;
                                character = entry[++count];
                                column++;
                            } else if (char.IsLetter(character) || character.CompareTo('_') == 0 || character.CompareTo('"') == 0 || isSpace(character)) {
                                //token de error
                                //estado error continuo
                                state = 30;
                                lexeme += character;
                                character = entry[++count];
                                column++;
                                qState = Token.States.qErr;
                            } else if (character.CompareTo('$') == 0) {
                                //fin del archivo
                                state = -1;
                                qState = Token.States.qErr;
                            } else if (character.CompareTo('.') == 0) {
                                state = 30;
                                lexeme += character;
                                character = entry[++count];
                                column++;
                            } else {
                                state = -1;
                                qState = Token.States.q2;
                            }
                            break;
                        case 4:
                            if (char.IsDigit(character)) {
                                //se mantiene en el mismo estado
                                lexeme += character;
                                character = entry[++count];
                                column++;
                            } else if (char.IsLetter(character) || character.CompareTo('_') == 0 || character.CompareTo('"') == 0) {
                                //token de error
                                //estado error continuo
                                state = 30;
                                lexeme += character;
                                character = entry[++count];
                                column++;
                                qState = Token.States.qErr;
                            } else if (character.CompareTo('.') == 0) {
                                state = 30;
                                lexeme += character;
                                character = entry[++count];
                                column++;
                            } else {
                                state = -1;
                                qState = Token.States.q2;
                            }
                            break;
                        case 5:
                            if (character.CompareTo('"') == 0) {
                                //termina la cadena
                                state = -1;
                                lexeme += character;
                                character = entry[++count];
                                column++;
                                qState = Token.States.q7;
                            } else if(character.CompareTo('\n') != 0 && character.CompareTo('$') != 0) {
                                //si no es una comilla ni un salto de linea
                                //es un caracter de entrada
                                //se mantiene en el mismo estado
                                lexeme += character;
                                character = entry[++count];
                                column++;
                            } else {
                                //es un salto de linea
                                state = -1;
                                qState = Token.States.qErr;
                            }
                            break;
                        case 8:
                            if(character.CompareTo('/') == 0) {
                                //nos dirijimos al estado 9
                                state = 9;
                                lexeme += character;
                                character = entry[++count];
                                column++;
                            } else if(character.CompareTo('*') == 0) {
                                //nos dirijimos al estado 10
                                state = 10;
                                lexeme += character;
                                character = entry[++count];
                                column++;
                            } else {
                                //es un divisor
                                state = -1;
                                qState = Token.States.q8;
                            }
                            break;
                        case 9:
                            if(character.CompareTo('\n') == 0 || character.CompareTo('$') == 0) {
                                //con un salto de lina termina el comentario
                                state = -1;
                                qState = Token.States.q11;
                            } else {
                                lexeme += character;
                                character = entry[++count];
                                column++;
                            }
                            break;
                        case 10:
                            if (character.CompareTo('*') == 0) {
                                //con un salto de lina termina el comentario
                                state = 13;
                                lexeme += character;
                                character = entry[++count];
                                column++;
                            } else if(character.CompareTo('$') == 0) {
                                //no se termino el comentario
                                //generar error
                                state = -1;
                                qState = Token.States.qErr;
                            } else {
                                //el estado se mantiene
                                lexeme += character;
                                character = entry[++count];
                                column++;
                            }
                            break;
                        case 13:
                            if(character.CompareTo('/') == 0) {
                                //fin de comentario
                                state = -1;
                                lexeme += character;
                                character = entry[++count];
                                column++;
                                qState = Token.States.q11;
                            } else if (character.CompareTo('*') == 0) {
                                //estado se mantiene
                                lexeme += character;
                                character = entry[++count];
                                column++;
                            } else if(character.CompareTo('$') == 0) {
                                //no se termino el comentario
                                //generar error
                                state = -1;
                                qState = Token.States.qErr;
                            } else {
                                //regresamos al estado 10
                                state = 10;
                                lexeme += character;
                                character = entry[++count];
                                column++;
                            }
                            break;
                        case 18:
                            if (character.CompareTo('=') == 0) {
                                //operador de asignacion
                                state = -1;
                                lexeme += character;
                                character = entry[++count];
                                column++;
                                qState = Token.States.q19;
                            } else {
                                state = -1;
                                qState = Token.States.qErr;
                            }
                            break;
                        case 30:
                            if (char.IsLetter(character) || character.CompareTo('_') == 0 || character.CompareTo('.') == 0 || char.IsDigit(character)) {
                                //se mantiene en este estado
                                lexeme += character;
                                character = entry[++count];
                                column++;
                            } else {
                                state = -1;
                                qState = Token.States.qErr;
                            }
                            break;
                    }
                }

                //agregar token generado
                if(lexeme != "")
                    addToken(qState, row, column-lexeme.Length, count-lexeme.Length);
                //actualizar cambio de linea
                if (character.CompareTo('\n') == 0) {
                    column = 0;
                    row++;
                }


            }


            return listTokens;
        }



        private void addToken(Token.States state, int row, int column, int pos) {
            listTokens.Add(new Token(state, lexeme, row, column, pos));
        }


        Token.States isReservedWord(String cadena) {
            if (cadena == "int") {
                return Token.States.qInt;
            } else if (cadena == "pow") {
                return Token.States.qPow;
            } else if (cadena == "e") {
                return Token.States.qE;
            } else if (cadena == "pi") {
                return Token.States.qPi;
            } else if (cadena == "log") {
                return Token.States.qLog;
            } else if (cadena == "sin") {
                return Token.States.qSin;
            } else if (cadena == "cos") {
                return Token.States.qCos;
            } else if (cadena == "tan") {
                return Token.States.qTan;
            } else if (cadena == "del") {
                return Token.States.qDel;
            } else if (cadena == "list") {
                return Token.States.qList;
            } else if (cadena == "print") {
                return Token.States.qPrint;
            } else if (cadena == "input") {
                return Token.States.qInput;
            }
            return Token.States.q1;
        }

        bool isSpace(char c) {
            return c.CompareTo(' ') == 0 || c.CompareTo('\t') == 0 || c.CompareTo('\n') == 0;
        }

    }
}
